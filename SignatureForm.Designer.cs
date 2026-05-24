namespace OrdreMission;

partial class SignatureForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        GrpSig    = new GroupBox();
        PicSig    = new PictureBox();
        LblSigHint = new Label();
        BtnImport = new Button();
        BtnClear  = new Button();
        LblSigFmt = new Label();
        BtnAnnuler = new Button();
        BtnOk      = new Button();
        GrpSig.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PicSig).BeginInit();
        SuspendLayout();

        // ── GrpSig ────────────────────────────────────────────────────────────
        GrpSig.Controls.Add(PicSig);
        GrpSig.Controls.Add(LblSigHint);
        GrpSig.Controls.Add(BtnImport);
        GrpSig.Controls.Add(BtnClear);
        GrpSig.Controls.Add(LblSigFmt);
        GrpSig.Location = new Point(12, 12);
        GrpSig.Name     = "GrpSig";
        GrpSig.Size     = new Size(406, 118);
        GrpSig.TabStop  = false;
        GrpSig.Text     = "Signature";

        // ── PicSig ────────────────────────────────────────────────────────────
        PicSig.BackColor   = Color.White;
        PicSig.BorderStyle = BorderStyle.FixedSingle;
        PicSig.Location    = new Point(8, 24);
        PicSig.Name        = "PicSig";
        PicSig.Size        = new Size(220, 64);
        PicSig.SizeMode    = PictureBoxSizeMode.Zoom;
        PicSig.TabStop     = false;

        // ── LblSigHint ────────────────────────────────────────────────────────
        LblSigHint.AutoSize  = true;
        LblSigHint.ForeColor = Color.Silver;
        LblSigHint.Location  = new Point(12, 48);
        LblSigHint.Name      = "LblSigHint";
        LblSigHint.Text      = "(aucune image importée)";

        // ── BtnImport ─────────────────────────────────────────────────────────
        BtnImport.Cursor    = Cursors.Hand;
        BtnImport.FlatStyle = FlatStyle.Flat;
        BtnImport.Location  = new Point(244, 24);
        BtnImport.Name      = "BtnImport";
        BtnImport.Size      = new Size(148, 30);
        BtnImport.TabIndex  = 0;
        BtnImport.Text      = "&Importer image…";
        BtnImport.Click    += BtnImport_Click;

        // ── BtnClear ──────────────────────────────────────────────────────────
        BtnClear.Cursor    = Cursors.Hand;
        BtnClear.FlatStyle = FlatStyle.Flat;
        BtnClear.ForeColor = Color.DarkRed;
        BtnClear.Location  = new Point(244, 62);
        BtnClear.Name      = "BtnClear";
        BtnClear.Size      = new Size(80, 26);
        BtnClear.TabIndex  = 1;
        BtnClear.Text      = "Effacer";
        BtnClear.Click    += BtnClear_Click;

        // ── LblSigFmt ─────────────────────────────────────────────────────────
        LblSigFmt.AutoSize  = true;
        LblSigFmt.Font      = new Font("Segoe UI", 7.5F);
        LblSigFmt.ForeColor = Color.Gray;
        LblSigFmt.Location  = new Point(8, 96);
        LblSigFmt.Name      = "LblSigFmt";
        LblSigFmt.Text      = "Formats : PNG, JPG, BMP, GIF";

        // ── BtnAnnuler ────────────────────────────────────────────────────────
        BtnAnnuler.Cursor       = Cursors.Hand;
        BtnAnnuler.DialogResult = DialogResult.Cancel;
        BtnAnnuler.FlatStyle    = FlatStyle.Flat;
        BtnAnnuler.Location     = new Point(184, 142);
        BtnAnnuler.Name         = "BtnAnnuler";
        BtnAnnuler.Size         = new Size(110, 32);
        BtnAnnuler.TabIndex     = 2;
        BtnAnnuler.Text         = "Annuler";
        BtnAnnuler.Click       += BtnAnnuler_Click;

        // ── BtnOk ─────────────────────────────────────────────────────────────
        BtnOk.BackColor                 = Color.FromArgb(21, 101, 192);
        BtnOk.Cursor                    = Cursors.Hand;
        BtnOk.FlatAppearance.BorderSize = 0;
        BtnOk.FlatStyle                 = FlatStyle.Flat;
        BtnOk.Font                      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        BtnOk.ForeColor                 = Color.White;
        BtnOk.Location                  = new Point(302, 142);
        BtnOk.Name                      = "BtnOk";
        BtnOk.Size                      = new Size(116, 32);
        BtnOk.TabIndex                  = 3;
        BtnOk.Text                      = "Enregistrer";
        BtnOk.UseVisualStyleBackColor   = false;
        BtnOk.Click                    += BtnOk_Click;

        // ── SignatureForm ──────────────────────────────────────────────────────
        AcceptButton    = BtnOk;
        CancelButton    = BtnAnnuler;
        ClientSize      = new Size(430, 186);
        Controls.Add(GrpSig);
        Controls.Add(BtnAnnuler);
        Controls.Add(BtnOk);
        Font            = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;
        MinimizeBox     = false;
        Name            = "SignatureForm";
        StartPosition   = FormStartPosition.CenterParent;
        Text            = "Signature";
        GrpSig.ResumeLayout(false);
        GrpSig.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PicSig).EndInit();
        ResumeLayout(false);
    }

    private GroupBox   GrpSig;
    private PictureBox PicSig;
    private Label      LblSigHint;
    private Button     BtnImport;
    private Button     BtnClear;
    private Label      LblSigFmt;
    private Button     BtnAnnuler;
    private Button     BtnOk;
}
