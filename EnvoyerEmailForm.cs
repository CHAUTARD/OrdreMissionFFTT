/* EnvoyerEmailForm.cs
 * Formulaire de composition d'un email vers un responsable de club FFTT.
 * Utilise mailto: pour ouvrir le client de messagerie par défaut de l'utilisateur.
 */
using System.Diagnostics;

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

    // Ouvre le client mail par défaut via un lien mailto:
    private void BtnEnvoyer_Click(object? sender, EventArgs e)
    {
        string to      = TxtA.Text.Trim();
        string subject = TxtObjet.Text.Trim();
        string body    = TxtCorps.Text.Trim();

        if (string.IsNullOrWhiteSpace(to))
        {
            MessageBox.Show("L'adresse destinataire est obligatoire.",
                "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            TxtA.Focus();
            return;
        }

        // Construction du lien mailto: (RFC 6068)
        string mailto = "mailto:"
            + Uri.EscapeDataString(to)
            + "?subject=" + Uri.EscapeDataString(subject)
            + "&body="    + Uri.EscapeDataString(body);

        try
        {
            Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Impossible d'ouvrir le client de messagerie :\n" + ex.Message,
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Copie l'adresse email dans le presse-papiers
    private void BtnCopier_Click(object? sender, EventArgs e)
    {
        string addr = TxtA.Text.Trim();
        if (string.IsNullOrWhiteSpace(addr)) return;
        Clipboard.SetText(addr);
        LblInfo.Text = "✔ Adresse copiée dans le presse-papiers.";
    }

    private void BtnAnnuler_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
