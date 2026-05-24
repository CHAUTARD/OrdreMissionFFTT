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
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        _cfg.IndemFixe = NudIndemFixe.Value;
        _cfg.TauxKm    = NudTauxKm.Value;

        _cfg.AdresseNumero      = TxtNumero.Text.Trim();
        _cfg.AdresseRue         = TxtRue.Text.Trim();
        _cfg.AdresseCodePostal  = TxtCp.Text.Trim();
        _cfg.AdresseVille       = TxtVille.Text.Trim();
        _cfg.Save();
    }
}
