using OrdreMission.CS;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OrdreMission;

public partial class Form1 : Form
{
    private static readonly CultureInfo Fr = CultureInfo.GetCultureInfo("fr-FR");

    private AppSettings    _cfg      = AppSettings.Load();
    private EmailTemplate  _emailTpl = EmailTemplate.Load();
    private string?        _signaturePath;

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
        if (_cfg.DernierPeage > 0) NudPeage.Value = _cfg.DernierPeage;
        if (_cfg.DernierKm    > 0) NudKm.Value    = _cfg.DernierKm;

        // Valeurs de la dernière session (fallback si le PDF n'est pas lisible)
        TxtCompOpposant.Text = _cfg.DernierOpposant;
        TxtCompDate.Text     = _cfg.DerniereDate;
        TxtCompHeure.Text    = _cfg.DerniereHeure;
        TxtCompAdresse.Text  = _cfg.DerniereAdresse;

        if (!string.IsNullOrWhiteSpace(_cfg.DernierSource) && File.Exists(_cfg.DernierSource))
        {
            TxtSource.Text = _cfg.DernierSource;

            // Relecture du PDF pour mettre à jour les infos compétition
            var info = PdfService.ReadCompetitionInfo(_cfg.DernierSource, _cfg);
            if (!string.IsNullOrWhiteSpace(info.Opposant)) TxtCompOpposant.Text = info.Opposant;
            if (!string.IsNullOrWhiteSpace(info.Date))     TxtCompDate.Text     = info.Date;
            if (!string.IsNullOrWhiteSpace(info.Heure))    TxtCompHeure.Text    = info.Heure;
            if (!string.IsNullOrWhiteSpace(info.Adresse))  TxtCompAdresse.Text  = info.Adresse;

            bool luOk = !string.IsNullOrWhiteSpace(info.Opposant) || !string.IsNullOrWhiteSpace(info.Date);
            SetStatus(luOk
                ? "PDF restauré : " + Path.GetFileName(_cfg.DernierSource) + " — infos compétition mises à jour."
                : "PDF restauré : " + Path.GetFileName(_cfg.DernierSource) + " — infos issues de la dernière session.");
        }
    }

    private void ApplyParams()
    {
        LblIndemFixeVal.Text = _cfg.IndemFixe.ToString("0.00", Fr) + " €";
        LblKmTaux.Text       = "kms  ×  " + _cfg.TauxKm.ToString("0.00", Fr) + " €";
    }

    private void Recalculate()
    {
        decimal montantKm = NudKm.Value * _cfg.TauxKm;
        decimal total     = NudPeage.Value + _cfg.IndemFixe + montantKm;
        LblDureeTrajet.Text = montantKm.ToString("0.00", Fr) + " €";
        LblTotal.Text       = total.ToString("0.00", Fr) + " €";
    }

    // ── Handlers d'événements ─────────────────────────────────────────────────

    private void BtnSource_Click(object? sender, EventArgs e) => BrowseSource();
    private void BtnOutput_Click(object? sender, EventArgs e) => BrowseOutput();
    private void BtnReset_Click(object? sender, EventArgs e)  => ResetForm();
    private void NudPeage_ValueChanged(object? sender, EventArgs e) => Recalculate();
    private void NudKm_ValueChanged(object? sender, EventArgs e)    => Recalculate();
    private void BtnGen_Click(object? sender, EventArgs e)      => Generate();
    private void BtnOpen_Click(object? sender, EventArgs e)     => OpenOutputPdf();
    private void BtnEnvoyerOM_Click(object? sender, EventArgs e) => OuvrirEnvoyerOm();
    private void BtnRechercheFftt_Click(object? sender, EventArgs e) => OuvrirRechercheFftt();
    private void BtnItineraire_Click(object? sender, EventArgs e)    => _ = CalculerItineraireAsync();

    // ── Handlers menu ─────────────────────────────────────────────────────────
    private void MnuFichierQuitter_Click(object? sender, EventArgs e)  => Application.Exit();
    private void MnuOutilsParams_Click(object? sender, EventArgs e)    => OpenParametres();
    private void MnuOutilsPositions_Click(object? sender, EventArgs e) => OpenPositions();
    private void MnuOutilsEmail_Click(object? sender, EventArgs e)     => OpenEmailTemplate();
    private void MnuOutilsRecherche_Click(object? sender, EventArgs e) => OuvrirRechercheFftt();
    private void MnuOutilsSignature_Click(object? sender, EventArgs e) => OuvrirSignature();
    private void MnuAideAPropos_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(
            "Convocation JA — Compléter le PDF\n" +
            "Version 1.00\n\n" +
            "Outil d'aide à la saisie pour les Juges Arbitres FFTT.\n" +
            "Complète automatiquement les PDFs de convocation\n" +
            "et facilite la communication avec les clubs adverses.\n\n" +
            "Auteur : Patrick CHAUTARD\n" +
            "© Copyright 2026 — patrick.chautard@free.fr",
            "À propos de Convocation JA", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

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

        // Indemnités
        NudPeage.Value = 0;
        NudKm.Value    = 0;

        // Rapports
        TxtRapAccueil.Text = "";
        TxtRapEquip.Text   = "";

        LblItineraire.Text      = "🗺️  —";
        LblItineraire.ForeColor = SystemColors.ControlText;
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
        var info = PdfService.ReadCompetitionInfo(dlg.FileName, _cfg);
        if (!string.IsNullOrWhiteSpace(info.Opposant))    TxtCompOpposant.Text    = info.Opposant;
        if (!string.IsNullOrWhiteSpace(info.Date))        TxtCompDate.Text        = info.Date;
        if (!string.IsNullOrWhiteSpace(info.Heure))       TxtCompHeure.Text       = info.Heure;
        if (!string.IsNullOrWhiteSpace(info.Adresse))     TxtCompAdresse.Text     = info.Adresse;

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

    private void OuvrirSignature()
    {
        using var dlg = new SignatureForm(_signaturePath);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        _signaturePath = dlg.SignaturePath;
        SetStatus(_signaturePath is not null
            ? "Signature enregistrée : " + Path.GetFileName(_signaturePath)
            : "Signature effacée.");
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
            _cfg.Save();
            decimal totalFrais = peage + _cfg.IndemFixe + km * _cfg.TauxKm;

            string rapAccueil  = TxtRapAccueil.Text.Trim();
            string rapEquip    = TxtRapEquip.Text.Trim();
            string opposant    = TxtCompOpposant.Text.Trim();
            string date        = TxtCompDate.Text.Trim();
            string heure       = TxtCompHeure.Text.Trim();
            string adresse     = TxtCompAdresse.Text.Trim();

            PdfService.Generate(
                TxtSource.Text.Trim(), output,
                peage, km, totalFrais,
                _signaturePath,
                rapAccueil, rapEquip,
                opposant, date, heure, adresse,
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

    private void OpenEmailTemplate()
    {
        using var dlg = new EmailTemplateForm(_emailTpl);
        if (dlg.ShowDialog(this) == DialogResult.OK)
            SetStatus("Modèle d'email enregistré.");
    }

    private void OuvrirEnvoyerOm()
    {
        using var dlg = new EnvoyerOmForm(
            _cfg,
            TxtOutput.Text.Trim(),
            TxtCompOpposant.Text.Trim(),
            TxtCompDate.Text.Trim());
        if (dlg.ShowDialog(this) == DialogResult.OK)
            SetStatus("Ordre de mission envoyé au responsable des nominations.");
    }


    // ── Calcul d'itinéraire ───────────────────────────────────────────────────

    private async Task CalculerItineraireAsync()
    {
        string adresseArrivee = TxtCompAdresse.Text.Trim();
        if (string.IsNullOrWhiteSpace(adresseArrivee))
        {
            MessageBox.Show(
                "Veuillez saisir l'adresse de la salle de compétition.",
                "Adresse manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(_cfg.OrsApiKey))
        {
            MessageBox.Show(
                "Clé API OpenRouteService non configurée." + Environment.NewLine
                + "Renseignez-la dans Outils > Paramètres > OpenRouteService.",
                "Clé manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string adresseDepart = BuildAdresseDepart();
        if (string.IsNullOrWhiteSpace(adresseDepart))
        {
            MessageBox.Show(
                "Veuillez renseigner votre adresse de départ dans Outils > Paramètres.",
                "Adresse de départ manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        BtnItineraire.Enabled   = false;
        LblItineraire.Text      = "⏳ Calcul en cours…";
        LblItineraire.ForeColor = SystemColors.ControlText;
        SetStatus("Calcul de l'itinéraire…");
        Cursor = Cursors.WaitCursor;

        try
        {
            var (km, minutes) = await RoutingService.CalculerAsync(adresseDepart, adresseArrivee, _cfg.OrsApiKey);

            int    h     = minutes / 60;
            int    min   = minutes % 60;
            string duree = h > 0 ? $"{h}h{min:D2}" : $"{minutes} min";

            LblItineraire.Text      = $"🚘  {km:0.0} km — {duree} ";
            LblItineraire.ForeColor = Color.FromArgb(0, 100, 0);

            // Proposer de mettre à jour le nombre de km dans les indemnités
            decimal kmArrondi      = (decimal)Math.Ceiling(km);
            decimal kmAllerRetour  = kmArrondi * 2;   // aller + retour
            if (NudKm.Value != kmAllerRetour)
            {
                string msg = $"Itinéraire calculé : {km:0.0} km — {duree} Approximatif"
                           + Environment.NewLine + Environment.NewLine
                           + $"Mettre à jour le champ km des indemnités ({kmAllerRetour:0} km aller-retour) ?";
                var rep = MessageBox.Show(msg,
                    "Itinéraire", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (rep == DialogResult.Yes)
                {
                    NudKm.Value = kmAllerRetour;
                    Recalculate();
                    SetStatus($"Itinéraire : {km:0.0} km (× 2 = {kmAllerRetour:0} km A/R) — {duree} — indemnités mises à jour.");
                }
                else
                {
                    SetStatus($"Itinéraire : {km:0.0} km — {duree}.");
                }
            }
            else
            {
                SetStatus($"Itinéraire : {km:0.0} km — {duree}.");
            }
        }
        catch (HttpRequestException ex)
        {
            LblItineraire.Text      = "⛔ Erreur réseau";
            LblItineraire.ForeColor = Color.DarkRed;
            SetStatus("Erreur réseau : " + ex.Message);
        }
        catch (Exception ex)
        {
            LblItineraire.Text      = "⛔ " + ex.Message;
            LblItineraire.ForeColor = Color.DarkRed;
            SetStatus("Erreur itinéraire : " + ex.Message);
        }
        finally
        {
            BtnItineraire.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    /// <summary>Construit l'adresse de départ à partir des paramètres.</summary>
    private string BuildAdresseDepart()
    {
        string num   = _cfg.AdresseNumero.Trim();
        string rue   = _cfg.AdresseRue.Trim();
        string cp    = _cfg.AdresseCodePostal.Trim();
        string ville = _cfg.AdresseVille.Trim();

        var parts = new List<string>();
        if (!string.IsNullOrEmpty(num) && !string.IsNullOrEmpty(rue))
            parts.Add(num + " " + rue);
        else if (!string.IsNullOrEmpty(rue))
            parts.Add(rue);
        if (!string.IsNullOrEmpty(cp))    parts.Add(cp);
        if (!string.IsNullOrEmpty(ville)) parts.Add(ville);

        return string.Join(", ", parts);
    }

    // ── Recherche FFTT ────────────────────────────────────────────────────────

    private void OuvrirRechercheFftt()
    {
        // Extrait le code postal (5 chiffres) depuis l'adresse saisie
        string adresse = TxtCompAdresse.Text.Trim();
        var match = Regex.Match(adresse, @"\b(\d{5})\b");
        string cp = match.Success ? match.Value : "";

        using var form = new RechercheFfttForm(
            cp,
            TxtCompOpposant.Text.Trim(),
            TxtCompDate.Text.Trim(),
            TxtCompHeure.Text.Trim(),
            _cfg,
            _emailTpl);
        form.ShowDialog(this);
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
