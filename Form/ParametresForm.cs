using OrdreMission.CS;

namespace OrdreMission;

public partial class ParametresForm : Form
{
    private readonly AppSettings _cfg;

    public ParametresForm(AppSettings cfg)
    {
        _cfg = cfg;
        InitializeComponent();
        AppImages.AppliquerSauvegarde(BtnOk);
        AppImages.AppliquerAnnuler(BtnCancel);
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
        _cfg.Save();
    }
}
