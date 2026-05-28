using OrdreMission.CS;

namespace OrdreMission;

public partial class ParametresForm : Form
{
    private readonly AppSettings _cfg;

    public ParametresForm(AppSettings cfg)
    {
        _cfg = cfg;

        InitializeComponent();

        LoadValues();
    }

    private void LoadValues()
    {
        NudIndemFixe.Value = _cfg.IndemFixe;
        NudTauxKm.Value    = _cfg.TauxKm;

        TxtNumero.Text = _cfg.AdresseNumero;
        TxtRue.Text    = _cfg.AdresseRue;
        TxtCp.Text     = _cfg.AdresseCodePostal;
        TxtVille.Text  = _cfg.AdresseVille;

        TxtNomArbitre.Text         = _cfg.NomArbitre;
        TxtNomNominations.Text   = _cfg.NomResponsableNominations;
        TxtAzureMapsKey.Text     = _cfg.MapboxApiKey;
        TxtEmailNominations.Text = _cfg.EmailResponsableNominations;
        TxtTelNominations.Text   = _cfg.TelResponsableNominations;

        // SMTP
        TxtSmtpHost.Text        = _cfg.SmtpHost;
        NudSmtpPort.Value       = _cfg.SmtpPort;
        ChkSmtpSsl.Checked      = _cfg.SmtpSsl;
        TxtSmtpUser.Text        = _cfg.SmtpUser;
        TxtSmtpPassword.Text    = _cfg.SmtpPassword;
        TxtSmtpFrom.Text        = _cfg.SmtpFrom;
    }

    // ── Sauvegarde globale (ferme la fenêtre) ─────────────────────────────────

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        SauverMontants();
        SauverArbitre();
        SauverNominations();
        SauverItineraire();
        SauverSmtp();
        _cfg.Save();
    }

    // ── Sauvegarde par onglet (ne ferme pas la fenêtre) ───────────────────────

    private async void BtnSauverMontants_Click(object? sender, EventArgs e)
    {
        SauverMontants(); _cfg.Save();
        await NotifierSauvegarde(BtnSauverMontants);
    }

    private async void BtnSauverArbitre_Click(object? sender, EventArgs e)
    {
        SauverArbitre(); _cfg.Save();
        await NotifierSauvegarde(BtnSauverArbitre);
    }

    private async void BtnSauverNominations_Click(object? sender, EventArgs e)
    {
        SauverNominations(); _cfg.Save();
        await NotifierSauvegarde(BtnSauverNominations);
    }

    private async void BtnSauverItineraire_Click(object? sender, EventArgs e)
    {
        SauverItineraire(); _cfg.Save();
        await NotifierSauvegarde(BtnSauverItineraire);
    }

    private async void BtnSauverSmtp_Click(object? sender, EventArgs e)
    {
        SauverSmtp(); _cfg.Save();
        await NotifierSauvegarde(BtnSauverSmtp);
    }

    // ── Méthodes de lecture des champs par groupe ─────────────────────────────

    private void SauverMontants()
    {
        _cfg.IndemFixe = NudIndemFixe.Value;
        _cfg.TauxKm    = NudTauxKm.Value;
    }

    private void SauverArbitre()
    {
        _cfg.NomArbitre        = TxtNomArbitre.Text.Trim();
        _cfg.AdresseNumero     = TxtNumero.Text.Trim();
        _cfg.AdresseRue        = TxtRue.Text.Trim();
        _cfg.AdresseCodePostal = TxtCp.Text.Trim();
        _cfg.AdresseVille      = TxtVille.Text.Trim();
    }

    private void SauverNominations()
    {
        _cfg.NomResponsableNominations   = TxtNomNominations.Text.Trim();
        _cfg.EmailResponsableNominations = TxtEmailNominations.Text.Trim();
        _cfg.TelResponsableNominations   = TxtTelNominations.Text.Trim();
    }

    private void SauverItineraire()
    {
        _cfg.MapboxApiKey = TxtAzureMapsKey.Text.Trim();
    }

    private void SauverSmtp()
    {
        _cfg.SmtpHost     = TxtSmtpHost.Text.Trim();
        _cfg.SmtpPort     = (int)NudSmtpPort.Value;
        _cfg.SmtpSsl      = ChkSmtpSsl.Checked;
        _cfg.SmtpUser     = TxtSmtpUser.Text.Trim();
        _cfg.SmtpPassword = TxtSmtpPassword.Text;   // pas de Trim() sur le mot de passe
        _cfg.SmtpFrom     = TxtSmtpFrom.Text.Trim();
    }

    // ── Retour visuel sur les boutons Sauvegarder ─────────────────────────────

    private static async Task NotifierSauvegarde(Button btn)
    {
        string texte = btn.Text;
        btn.Enabled  = false;
        btn.Text     = "✔ Sauvegardé !";
        await Task.Delay(1500);
        btn.Text     = texte;
        btn.Enabled  = true;
    }
}