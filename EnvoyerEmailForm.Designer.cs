namespace OrdreMission;

partial class EnvoyerEmailForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        LblA        = new Label();
        TxtA        = new TextBox();
        LblObjet    = new Label();
        TxtObjet    = new TextBox();
        LblCorps    = new Label();
        TxtCorps    = new TextBox();
        LblInfo     = new Label();
        BtnEnvoyer  = new Button();
        BtnCopier   = new Button();
        BtnAnnuler  = new Button();
        SuspendLayout();

        // ── LblA ─────────────────────────────────────────────────────────────────
        LblA.AutoSize = true;
        LblA.Font     = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblA.Location = new Point(12, 18);
        LblA.Name     = "LblA";
        LblA.Text     = "À :";

        // ── TxtA ─────────────────────────────────────────────────────────────────
        TxtA.Location = new Point(90, 15);
        TxtA.Name     = "TxtA";
        TxtA.Size     = new Size(426, 24);
        TxtA.TabIndex = 0;

        // ── LblObjet ─────────────────────────────────────────────────────────────
        LblObjet.AutoSize = true;
        LblObjet.Font     = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblObjet.Location = new Point(12, 52);
        LblObjet.Name     = "LblObjet";
        LblObjet.Text     = "Objet :";

        // ── TxtObjet ─────────────────────────────────────────────────────────────
        TxtObjet.Location = new Point(90, 49);
        TxtObjet.Name     = "TxtObjet";
        TxtObjet.Size     = new Size(426, 24);
        TxtObjet.TabIndex = 1;

        // ── LblCorps ─────────────────────────────────────────────────────────────
        LblCorps.AutoSize = true;
        LblCorps.Font     = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblCorps.Location = new Point(12, 88);
        LblCorps.Name     = "LblCorps";
        LblCorps.Text     = "Corps :";

        // ── TxtCorps ─────────────────────────────────────────────────────────────
        TxtCorps.AcceptsReturn = true;
        TxtCorps.Location      = new Point(12, 108);
        TxtCorps.Multiline     = true;
        TxtCorps.Name          = "TxtCorps";
        TxtCorps.ScrollBars    = ScrollBars.Vertical;
        TxtCorps.Size          = new Size(504, 175);
        TxtCorps.TabIndex      = 2;

        // ── LblInfo ──────────────────────────────────────────────────────────────
        LblInfo.AutoSize  = true;
        LblInfo.ForeColor = Color.FromArgb(0, 130, 0);
        LblInfo.Location  = new Point(12, 292);
        LblInfo.Name      = "LblInfo";
        LblInfo.Text      = "";

        // ── BtnCopier ────────────────────────────────────────────────────────────
        BtnCopier.Cursor    = Cursors.Hand;
        BtnCopier.FlatStyle = FlatStyle.Flat;
        BtnCopier.Location  = new Point(12, 314);
        BtnCopier.Name      = "BtnCopier";
        BtnCopier.Size      = new Size(150, 32);
        BtnCopier.TabIndex  = 3;
        BtnCopier.Text      = "📋 Copier l'adresse";
        BtnCopier.Click    += BtnCopier_Click;

        // ── BtnEnvoyer ───────────────────────────────────────────────────────────
        BtnEnvoyer.BackColor                 = Color.FromArgb(21, 101, 192);
        BtnEnvoyer.Cursor                    = Cursors.Hand;
        BtnEnvoyer.FlatAppearance.BorderSize = 0;
        BtnEnvoyer.FlatStyle                 = FlatStyle.Flat;
        BtnEnvoyer.Font                      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        BtnEnvoyer.ForeColor                 = Color.White;
        BtnEnvoyer.Location                  = new Point(172, 314);
        BtnEnvoyer.Name                      = "BtnEnvoyer";
        BtnEnvoyer.Size                      = new Size(182, 32);
        BtnEnvoyer.TabIndex                  = 4;
        BtnEnvoyer.Text                      = "✉  Ouvrir le client mail";
        BtnEnvoyer.UseVisualStyleBackColor   = false;
        BtnEnvoyer.Click                    += BtnEnvoyer_Click;

        // ── BtnAnnuler ───────────────────────────────────────────────────────────
        BtnAnnuler.Cursor       = Cursors.Hand;
        BtnAnnuler.DialogResult = DialogResult.Cancel;
        BtnAnnuler.FlatStyle    = FlatStyle.Flat;
        BtnAnnuler.Location     = new Point(364, 314);
        BtnAnnuler.Name         = "BtnAnnuler";
        BtnAnnuler.Size         = new Size(152, 32);
        BtnAnnuler.TabIndex     = 5;
        BtnAnnuler.Text         = "Annuler";
        BtnAnnuler.Click       += BtnAnnuler_Click;

        // ── EnvoyerEmailForm ──────────────────────────────────────────────────────
        AcceptButton    = BtnEnvoyer;
        CancelButton    = BtnAnnuler;
        ClientSize      = new Size(528, 360);
        Controls.Add(LblA);
        Controls.Add(TxtA);
        Controls.Add(LblObjet);
        Controls.Add(TxtObjet);
        Controls.Add(LblCorps);
        Controls.Add(TxtCorps);
        Controls.Add(LblInfo);
        Controls.Add(BtnCopier);
        Controls.Add(BtnEnvoyer);
        Controls.Add(BtnAnnuler);
        Font            = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;
        MinimizeBox     = false;
        Name            = "EnvoyerEmailForm";
        StartPosition   = FormStartPosition.CenterParent;
        Text            = "Envoyer un email";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label   LblA;
    private TextBox TxtA;
    private Label   LblObjet;
    private TextBox TxtObjet;
    private Label   LblCorps;
    private TextBox TxtCorps;
    private Label   LblInfo;
    private Button  BtnEnvoyer;
    private Button  BtnCopier;
    private Button  BtnAnnuler;
}
