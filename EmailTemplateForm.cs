/* EmailTemplateForm.cs
 * Éditeur du modèle d'email d'arbitrage.
 * Permet de personnaliser le sujet et le corps du mail envoyé aux clubs adverses.
 * Les modifications sont sauvegardées dans email_template.json à côté de l'EXE.
 */

namespace OrdreMission;

public partial class EmailTemplateForm : Form
{
    private readonly EmailTemplate _tpl;

    public EmailTemplateForm(EmailTemplate tpl)
    {
        _tpl = tpl;
        InitializeComponent();
        AppImages.AppliquerSauvegarde(BtnOk);
        AppImages.AppliquerAnnuler(BtnAnnuler);
        TxtSujet.Text = _tpl.SujetTemplate;
        TxtCorps.Text = _tpl.CorpsTemplate;
    }

    // ── Enregistrer ───────────────────────────────────────────────────────────

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        _tpl.SujetTemplate = TxtSujet.Text;
        _tpl.CorpsTemplate = TxtCorps.Text;
        _tpl.Save();
        DialogResult = DialogResult.OK;
        Close();
    }

    // ── Réinitialiser avec les valeurs par défaut ─────────────────────────────

    private void BtnReinit_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show(
                "Remettre le modèle par défaut ?\nLes modifications non enregistrées seront perdues.",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        var defaut = new EmailTemplate();
        TxtSujet.Text = defaut.SujetTemplate;
        TxtCorps.Text = defaut.CorpsTemplate;
    }

    // ── Annuler ───────────────────────────────────────────────────────────────

    private void BtnAnnuler_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
