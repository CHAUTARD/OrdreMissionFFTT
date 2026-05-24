using System.Diagnostics;
using System.Globalization;

namespace OrdreMission;

public partial class Form1 : Form
{
    private static readonly CultureInfo Fr = CultureInfo.GetCultureInfo("fr-FR");

    private AppSettings _cfg = AppSettings.Load();
    private string?     _signaturePath;

    public Form1()
    {
        InitializeComponent();

        ApplyParams();
        RestoreLastState();
        Recalculate();
    }


    // ── Calcul automatique du total ───────────────────────────────────────────

    private void RestoreLastState()
    {
        if (!string.IsNullOrWhiteSpace(_cfg.DernierSource) && File.Exists(_cfg.DernierSource))
        {
            TxtSource.Text = _cfg.DernierSource;
            SetStatus("Dernier fichier restauré : " + Path.GetFileName(_cfg.DernierSource));
        }
        if (_cfg.DernierPeage > 0) NudPeage.Value = _cfg.DernierPeage;
        if (_cfg.DernierKm    > 0) NudKm.Value    = _cfg.DernierKm;

        TxtCompOpposant.Text    = _cfg.DernierOpposant;
        TxtCompDate.Text        = _cfg.DerniereDate;
        TxtCompHeure.Text       = _cfg.DerniereHeure;
        TxtCompAdresse.Text     = _cfg.DerniereAdresse;
        TxtCompResponsable.Text = _cfg.DernierResponsable;
    }

    private void ApplyParams()
    {
        LblIndemFixeVal.Text = _cfg.IndemFixe.ToString("0.00", Fr) + " €";
        LblKmTaux.Text       = "kms  ×  " + _cfg.TauxKm.ToString("0.00", Fr) + " €";
    }

    private void Recalculate()
    {
        decimal total = NudPeage.Value + _cfg.IndemFixe + NudKm.Value * _cfg.TauxKm;
        LblTotal.Text = total.ToString("0.00", Fr) + " €";
    }

    // ── Handlers d'événements ─────────────────────────────────────────────────

    private void BtnSource_Click(object? sender, EventArgs e) => BrowseSource();
    private void BtnOutput_Click(object? sender, EventArgs e) => BrowseOutput();
    private void BtnReset_Click(object? sender, EventArgs e)  => ResetForm();
    private void NudPeage_ValueChanged(object? sender, EventArgs e) => Recalculate();
    private void NudKm_ValueChanged(object? sender, EventArgs e)    => Recalculate();
    private void BtnParams_Click(object? sender, EventArgs e)       => OpenParametres();
    private void BtnImport_Click(object? sender, EventArgs e) => ImportSignature();
    private void BtnClear_Click(object? sender, EventArgs e)  => ClearSignature();
    private void BtnGen_Click(object? sender, EventArgs e)    => Generate();
    private void BtnPos_Click(object? sender, EventArgs e)    => OpenPositions();
    private void BtnOpen_Click(object? sender, EventArgs e)   => OpenOutputPdf();

    // ── Remise à zéro du formulaire ───────────────────────────────────────────

    private void ResetForm()
    {
        if (MessageBox.Show(
                "Effacer tous les champs (PDF source, compétition, indemnités, rapports) ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        // Fichier PDF
        TxtSource.Text = "";
        TxtOutput.Text = "";

        // Compétition
        TxtCompOpposant.Text    = "";
        TxtCompDate.Text        = "";
        TxtCompHeure.Text       = "";
        TxtCompAdresse.Text     = "";
        TxtCompResponsable.Text = "";

        // Indemnités
        NudPeage.Value = 0;
        NudKm.Value    = 0;

        // Rapports
        TxtRapAccueil.Text = "";
        TxtRapEquip.Text   = "";

        SetStatus("Formulaire remis à zéro.");
    }

    // ── Navigation fichiers ───────────────────────────────────────────────────

    private void BrowseSource()
    {
        using var dlg = new OpenFileDialog
        {
            Title  = "Sélectionner le PDF de la convocation",
            Filter = "Fichiers PDF (*.pdf)|*.pdf",
        };
        if (dlg.ShowDialog() != DialogResult.OK) return;

        TxtSource.Text = dlg.FileName;
        if (string.IsNullOrWhiteSpace(TxtOutput.Text))
        {
            string name = Path.GetFileNameWithoutExtension(dlg.FileName);
            TxtOutput.Text = Path.Combine(GetPdfOutputDir(), name + "_complete.pdf");
        }
        SetStatus("PDF source : " + Path.GetFileName(dlg.FileName) + " — lecture en cours…");
        Application.DoEvents();

        // Lecture automatique des infos compétition depuis le PDF
        var info = PdfService.ReadCompetitionInfo(dlg.FileName, _cfg.Page);
        if (!string.IsNullOrWhiteSpace(info.Opposant))    TxtCompOpposant.Text    = info.Opposant;
        if (!string.IsNullOrWhiteSpace(info.Date))        TxtCompDate.Text        = info.Date;
        if (!string.IsNullOrWhiteSpace(info.Heure))       TxtCompHeure.Text       = info.Heure;
        if (!string.IsNullOrWhiteSpace(info.Adresse))     TxtCompAdresse.Text     = info.Adresse;
        if (!string.IsNullOrWhiteSpace(info.Responsable)) TxtCompResponsable.Text = info.Responsable;

        bool luOk = !string.IsNullOrWhiteSpace(info.Opposant) || !string.IsNullOrWhiteSpace(info.Date);
        SetStatus(luOk
            ? "PDF source : " + Path.GetFileName(dlg.FileName) + " — infos compétition lues."
            : "PDF source : " + Path.GetFileName(dlg.FileName) + " — aucune info compétition détectée (à saisir manuellement).");
    }

    private void BrowseOutput()
    {
        using var dlg = new SaveFileDialog
        {
            Title      = "Enregistrer le PDF complété",
            Filter     = "Fichiers PDF (*.pdf)|*.pdf",
            DefaultExt = "pdf",
            FileName   = "convocation_complétée.pdf",
        };
        dlg.InitialDirectory = GetPdfOutputDir();
        if (dlg.ShowDialog() == DialogResult.OK)
            TxtOutput.Text = dlg.FileName;
    }

    // ── Signature ─────────────────────────────────────────────────────────────

    private void ImportSignature()
    {
        using var dlg = new OpenFileDialog
        {
            Title  = "Importer l'image de signature",
            Filter = "Images (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif",
        };
        if (dlg.ShowDialog() != DialogResult.OK) return;

        _signaturePath     = dlg.FileName;
        PicSig.Image       = Image.FromFile(dlg.FileName);
        LblSigHint.Visible = false;
        SetStatus("Signature importée : " + Path.GetFileName(dlg.FileName));
    }

    private void ClearSignature()
    {
        PicSig.Image?.Dispose();
        PicSig.Image       = null;
        _signaturePath     = null;
        LblSigHint.Visible = true;
        SetStatus("Signature effacée.");
    }

    // ── Génération PDF ────────────────────────────────────────────────────────

    private void Generate()
    {
        if (string.IsNullOrWhiteSpace(TxtSource.Text))
        {
            MessageBox.Show("Veuillez sélectionner un fichier PDF source.",
                "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!File.Exists(TxtSource.Text))
        {
            MessageBox.Show("Fichier PDF source introuvable :\n" + TxtSource.Text,
                "Fichier introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string output = TxtOutput.Text.Trim();
        if (string.IsNullOrWhiteSpace(output))
        {
            string name = Path.GetFileNameWithoutExtension(TxtSource.Text);
            output = Path.Combine(GetPdfOutputDir(), name + "_complete.pdf");
            TxtOutput.Text = output;
        }

        if (string.Equals(TxtSource.Text.Trim(), output, StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Le fichier de sortie ne peut pas être identique au fichier source.",
                "Conflit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            SetStatus("Génération en cours…");
            Cursor = Cursors.WaitCursor;

            decimal peage = NudPeage.Value;
            decimal km    = NudKm.Value;

            // Mémoriser l'état pour la prochaine session
            _cfg.DernierSource      = TxtSource.Text.Trim();
            _cfg.DernierPeage       = peage;
            _cfg.DernierKm          = km;
            _cfg.DernierOpposant    = TxtCompOpposant.Text.Trim();
            _cfg.DerniereDate       = TxtCompDate.Text.Trim();
            _cfg.DerniereHeure      = TxtCompHeure.Text.Trim();
            _cfg.DerniereAdresse    = TxtCompAdresse.Text.Trim();
            _cfg.DernierResponsable = TxtCompResponsable.Text.Trim();
            _cfg.Save();
            decimal totalFrais = peage + _cfg.IndemFixe + km * _cfg.TauxKm;

            string rapAccueil  = TxtRapAccueil.Text.Trim();
            string rapEquip    = TxtRapEquip.Text.Trim();
            string opposant    = TxtCompOpposant.Text.Trim();
            string date        = TxtCompDate.Text.Trim();
            string heure       = TxtCompHeure.Text.Trim();
            string adresse     = TxtCompAdresse.Text.Trim();
            string responsable = TxtCompResponsable.Text.Trim();

            PdfService.Generate(
                TxtSource.Text.Trim(), output,
                peage, km, totalFrais,
                _signaturePath,
                rapAccueil, rapEquip,
                opposant, date, heure, adresse, responsable,
                _cfg);

            SetStatus($"✔  PDF généré : {Path.GetFileName(output)}");
            if (MessageBox.Show(
                    $"PDF généré avec succès !\n\n{output}\n\nOuvrir maintenant ?",
                    "Succès", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
                OpenOutputPdf();
        }
        catch (Exception ex)
        {
            SetStatus("Erreur : " + ex.Message);
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Type    : " + ex.GetType().FullName);
            sb.AppendLine("Message : " + ex.Message);
            if (ex.InnerException != null)
            {
                sb.AppendLine();
                sb.AppendLine("Cause   : " + ex.InnerException.GetType().FullName);
                sb.AppendLine("         " + ex.InnerException.Message);
            }
            sb.AppendLine();
            sb.AppendLine("=== Stack Trace ===");
            sb.AppendLine(ex.StackTrace);
            MessageBox.Show(sb.ToString(), "Erreur de génération",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    // ── Ouvrir le PDF / Dialogue positions ────────────────────────────────────

    private void OpenOutputPdf()
    {
        string path = TxtOutput.Text.Trim();
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
        {
            MessageBox.Show("Aucun PDF généré trouvé.", "Fichier introuvable",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try { Process.Start(new ProcessStartInfo(path) { UseShellExecute = true }); }
        catch (Exception ex)
        {
            MessageBox.Show("Impossible d'ouvrir le fichier :\n" + ex.Message,
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OpenParametres()
    {
        using var dlg = new ParametresForm(_cfg);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            ApplyParams();
            Recalculate();
            SetStatus($"Paramètres enregistrés — Indem. fixe : {_cfg.IndemFixe:0.00} €  |  Taux km : {_cfg.TauxKm:0.00} €");
        }
    }

    private void OpenPositions()
    {
        using var dlg = new PositionsForm(_cfg);
        if (dlg.ShowDialog(this) == DialogResult.OK)
            SetStatus("Positions mises à jour.");
    }

    // ── Utilitaire ────────────────────────────────────────────────────────────

    private void SetStatus(string msg) => LblStatus.Text = msg;

    /// <summary>Retourne le dossier PDF/ à côté de l'EXE, en le créant si nécessaire.</summary>
    private static string GetPdfOutputDir()
    {
        string dir = Path.Combine(AppContext.BaseDirectory, "PDF");
        Directory.CreateDirectory(dir);
        return dir;
    }
}
