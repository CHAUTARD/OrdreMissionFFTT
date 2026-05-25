/* EnvoyerOmForm.cs
 * Formulaire d'envoi de l'ordre de mission complété au responsable des nominations.
 *
 * Prérequis (tous obligatoires pour activer le bouton Envoyer) :
 *   - Email du responsable des nominations renseigné dans les Paramètres
 *   - Corps du message non vide
 *   - Fichier PDF de l'ordre de mission existant sur le disque
 *
 * Utilise MAPI Windows pour ouvrir le client mail par défaut avec la PJ pré-attachée.
 */

namespace OrdreMission;

public partial class EnvoyerOmForm : Form
{
    private readonly AppSettings _cfg;

    public EnvoyerOmForm(AppSettings cfg, string pdfPath, string opposant, string date)
    {
        _cfg = cfg;
        InitializeComponent();

        // ── Infos destinataire (lecture seule) ───────────────────────────────
        LblNomVal.Text   = string.IsNullOrWhiteSpace(_cfg.NomResponsableNominations)
                               ? "(non renseigné)" : _cfg.NomResponsableNominations;
        LblEmailVal.Text = string.IsNullOrWhiteSpace(_cfg.EmailResponsableNominations)
                               ? "(non renseigné)" : _cfg.EmailResponsableNominations;
        LblTelVal.Text   = string.IsNullOrWhiteSpace(_cfg.TelResponsableNominations)
                               ? "" : _cfg.TelResponsableNominations;

        // ── Sujet pré-rempli ─────────────────────────────────────────────────
        string sujetBase = string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(opposant)
            ? "Ordre de mission"
            : $"Ordre de mission du {date} — {opposant}";
        TxtSujet.Text = sujetBase;

        // ── Corps pré-rempli ─────────────────────────────────────────────────
        string nom = string.IsNullOrWhiteSpace(_cfg.NomResponsableNominations)
            ? "" : $" {_cfg.NomResponsableNominations.Split(' ')[0]}";   // prénom
        string arbitre = string.IsNullOrWhiteSpace(_cfg.NomArbitre) ? "" : _cfg.NomArbitre;

        string rencontre = (string.IsNullOrWhiteSpace(opposant) || string.IsNullOrWhiteSpace(date))
            ? "la rencontre"
            : $"la rencontre contre {opposant} du {date}";

        TxtCorps.Text =
            $"Bonjour{nom},\r\n\r\n" +
            $"Veuillez trouver ci-joint mon ordre de mission pour {rencontre}.\r\n\r\n" +
            $"Cordialement,\r\n" +
            $"{arbitre}";

        // ── Pièce jointe ─────────────────────────────────────────────────────
        TxtPj.Text = pdfPath;

        ActualiserValidation();
    }

    // ── Validation ────────────────────────────────────────────────────────────

    private void ActualiserValidation()
    {
        var erreurs = new System.Text.StringBuilder();

        if (string.IsNullOrWhiteSpace(_cfg.EmailResponsableNominations))
            erreurs.AppendLine("• Email du responsable des nominations manquant (Outils › Paramètres).");

        if (string.IsNullOrWhiteSpace(TxtCorps.Text))
            erreurs.AppendLine("• Le corps du message est vide.");

        string pj = TxtPj.Text.Trim();
        if (string.IsNullOrWhiteSpace(pj))
            erreurs.AppendLine("• Aucune pièce jointe sélectionnée.");
        else if (!File.Exists(pj))
            erreurs.AppendLine("• Le fichier PDF joint est introuvable.");

        bool ok = erreurs.Length == 0;
        BtnEnvoyer.Enabled = ok;

        if (ok)
        {
            LblEtat.ForeColor = Color.FromArgb(0, 130, 0);
            LblEtat.Text      = "✔  Prêt à envoyer.";
        }
        else
        {
            LblEtat.ForeColor = Color.DarkRed;
            LblEtat.Text      = erreurs.ToString().TrimEnd();
        }
    }

    // ── Parcourir PDF ─────────────────────────────────────────────────────────

    private void BtnParcourirPj_Click(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title  = "Sélectionner l'ordre de mission PDF",
            Filter = "Fichiers PDF (*.pdf)|*.pdf",
        };
        if (!string.IsNullOrWhiteSpace(TxtPj.Text) &&
            Directory.Exists(Path.GetDirectoryName(TxtPj.Text)))
            dlg.InitialDirectory = Path.GetDirectoryName(TxtPj.Text);

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            TxtPj.Text = dlg.FileName;
            ActualiserValidation();
        }
    }

    // ── Corps modifié ─────────────────────────────────────────────────────────

    private void TxtCorps_TextChanged(object? sender, EventArgs e) => ActualiserValidation();

    // ── Envoyer ───────────────────────────────────────────────────────────────

    private void BtnEnvoyer_Click(object? sender, EventArgs e)
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            MapiHelper.OuvrirAvecPj(
                destinataireEmail: _cfg.EmailResponsableNominations,
                destinataireNom:   _cfg.NomResponsableNominations,
                sujet:             TxtSujet.Text.Trim(),
                corps:             TxtCorps.Text,
                cheminPj:          TxtPj.Text.Trim());

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Impossible d'ouvrir le client de messagerie :\n\n" + ex.Message +
                "\n\nVérifiez qu'un client mail (Outlook, Thunderbird…) est configuré comme client par défaut.",
                "Erreur d'envoi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    // ── Annuler ───────────────────────────────────────────────────────────────

    private void BtnAnnuler_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
