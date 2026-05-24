/* SignatureForm.cs
 * Formulaire de gestion de la signature (image PNG/JPG/BMP/GIF).
 * Ouvert depuis Outils › Signature…
 * La propriété SignaturePath expose le chemin retenu après clic sur Enregistrer.
 */

namespace OrdreMission;

public partial class SignatureForm : Form
{
    private string? _signaturePath;

    /// <summary>Chemin de l'image de signature sélectionnée (null si effacée).</summary>
    public string? SignaturePath => _signaturePath;

    public SignatureForm(string? signaturePathCourant)
    {
        InitializeComponent();

        // Recharger la signature si elle était déjà configurée
        if (!string.IsNullOrEmpty(signaturePathCourant) && File.Exists(signaturePathCourant))
        {
            _signaturePath     = signaturePathCourant;
            PicSig.Image       = Image.FromFile(signaturePathCourant);
            LblSigHint.Visible = false;
        }
    }

    // ── Importer une image ────────────────────────────────────────────────────

    private void BtnImport_Click(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title  = "Importer l'image de signature",
            Filter = "Images (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif",
        };
        if (dlg.ShowDialog() != DialogResult.OK) return;

        PicSig.Image?.Dispose();
        _signaturePath     = dlg.FileName;
        PicSig.Image       = Image.FromFile(dlg.FileName);
        LblSigHint.Visible = false;
    }

    // ── Effacer la signature ──────────────────────────────────────────────────

    private void BtnClear_Click(object? sender, EventArgs e)
    {
        PicSig.Image?.Dispose();
        PicSig.Image       = null;
        _signaturePath     = null;
        LblSigHint.Visible = true;
    }

    // ── Valider / Annuler ─────────────────────────────────────────────────────

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void BtnAnnuler_Click(object? sender, EventArgs e)
    {
        // Remettre l'image précédente si l'utilisateur annule
        PicSig.Image?.Dispose();
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
