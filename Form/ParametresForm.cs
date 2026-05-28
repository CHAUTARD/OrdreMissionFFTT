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
        TxtAzureMapsKey.Text     = _cfg.OrsApiKey;
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

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        _cfg.IndemFixe = NudIndemFixe.Value;
        _cfg.TauxKm    = NudTauxKm.Value;

        _cfg.AdresseNumero      = TxtNumero.Text.Trim();
        _cfg.AdresseRue         = TxtRue.Text.Trim();
        _cfg.AdresseCodePostal  = TxtCp.Text.Trim();
        _cfg.AdresseVille       = TxtVille.Text.Trim();

        _cfg.NomArbitre                  = TxtNomArbitre.Text.Trim();
        _cfg.NomResponsableNominations   = TxtNomNominations.Text.Trim();
        _cfg.EmailResponsableNominations = TxtEmailNominations.Text.Trim();
        _cfg.TelResponsableNominations   = TxtTelNominations.Text.Trim();
        _cfg.OrsApiKey                   = TxtAzureMapsKey.Text.Trim();

        // SMTP
        _cfg.SmtpHost     = TxtSmtpHost.Text.Trim();
        _cfg.SmtpPort     = (int)NudSmtpPort.Value;
        _cfg.SmtpSsl      = ChkSmtpSsl.Checked;
        _cfg.SmtpUser     = TxtSmtpUser.Text.Trim();
        _cfg.SmtpPassword = TxtSmtpPassword.Text;   // pas de Trim() sur le mot de passe
        _cfg.SmtpFrom     = TxtSmtpFrom.Text.Trim();
        _cfg.Save();
    }
}
