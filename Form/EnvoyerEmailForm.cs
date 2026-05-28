/* EnvoyerEmailForm.cs
 * Formulaire de composition et d'envoi d'un email vers un responsable de club FFTT.
 * Utilise MailKit (via EmailService) pour l'envoi SMTP direct.
 * Les paramètres SMTP sont lus depuis AppSettings (Outils > Paramètres).
 */
using OrdreMission.CS;

namespace OrdreMission;

public partial class EnvoyerEmailForm : Form
{
    public EnvoyerEmailForm(string emailDestinataire, string sujetParDefaut, string corpsParDefaut = "")
    {
        InitializeComponent();
        TxtA.Text     = emailDestinataire;
        TxtObjet.Text = sujetParDefaut;
        TxtCorps.Text = corpsParDefaut;
    }

    // ── Envoi via SMTP (MailKit) ───────────────────────────────────────────────

    private async void BtnEnvoyer_Click(object? sender, EventArgs e)
    {
        string to = TxtA.Text.Trim();
        if (string.IsNullOrWhiteSpace(to))
        {
            MessageBox.Show("L'adresse destinataire est obligatoire.",
                "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            TxtA.Focus();
            return;
        }

        BtnEnvoyer.Enabled = false;
        BtnAnnuler.Enabled = false;
        LblInfo.ForeColor  = SystemColors.ControlText;
        LblInfo.Text       = "⏳ Envoi en cours…";

        try
        {
            var cfg = AppSettings.Load();
            await EmailService.EnvoyerAsync(cfg, to, TxtObjet.Text.Trim(), TxtCorps.Text.Trim());
            LblInfo.ForeColor = Color.FromArgb(0, 130, 0);
            LblInfo.Text      = "✔ Email envoyé avec succès.";
            // Petite pause pour que l'utilisateur voie le message de succès
            await Task.Delay(900);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            LblInfo.Text = "";
            MessageBox.Show(
                "Impossible d'envoyer l'email :\n\n" + ex.Message,
                "Erreur d'envoi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            BtnEnvoyer.Enabled = true;
            BtnAnnuler.Enabled = true;
        }
    }

    // ── Copie de l'adresse ────────────────────────────────────────────────────

    private void BtnCopier_Click(object? sender, EventArgs e)
    {
        string addr = TxtA.Text.Trim();
        if (string.IsNullOrWhiteSpace(addr)) return;
        Clipboard.SetText(addr);
        LblInfo.ForeColor = Color.FromArgb(0, 130, 0);
        LblInfo.Text      = "✔ Adresse copiée dans le presse-papiers.";
    }

    private void BtnAnnuler_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
