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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignatureForm));
        BtnAnnuler = new Button();
        BtnOk = new Button();
        PicSig = new PictureBox();
        BtnImport = new Button();
        BtnClear = new Button();
        LblSigFmt = new Label();
        ((System.ComponentModel.ISupportInitialize)PicSig).BeginInit();
        SuspendLayout();
        // 
        // BtnAnnuler
        // 
        BtnAnnuler.Cursor = Cursors.Hand;
        BtnAnnuler.DialogResult = DialogResult.Cancel;
        BtnAnnuler.FlatStyle = FlatStyle.Flat;
        BtnAnnuler.Image = Properties.Resources.cancel;
        BtnAnnuler.ImageAlign = ContentAlignment.MiddleLeft;
        BtnAnnuler.Padding    = new Padding(6, 0, 0, 0);
        BtnAnnuler.Location = new Point(23, 125);
        BtnAnnuler.Name = "BtnAnnuler";
        BtnAnnuler.Size = new Size(110, 41);
        BtnAnnuler.TabIndex = 2;
        BtnAnnuler.Text = "  &Annuler";
        BtnAnnuler.TextAlign = ContentAlignment.MiddleRight;
        BtnAnnuler.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnAnnuler.Click += BtnAnnuler_Click;
        // 
        // BtnOk
        // 
        BtnOk.BackColor = Color.FromArgb(21, 101, 192);
        BtnOk.Cursor = Cursors.Hand;
        BtnOk.FlatAppearance.BorderSize = 0;
        BtnOk.FlatStyle = FlatStyle.Flat;
        BtnOk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        BtnOk.ForeColor = Color.White;
        BtnOk.Image = Properties.Resources.save1;
        BtnOk.ImageAlign = ContentAlignment.MiddleLeft;
        BtnOk.Padding    = new Padding(6, 0, 0, 0);
        BtnOk.Location = new Point(302, 128);
        BtnOk.Name = "BtnOk";
        BtnOk.Size = new Size(116, 41);
        BtnOk.TabIndex = 3;
        BtnOk.Text = "  &Enregistrer";
        BtnOk.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnOk.UseVisualStyleBackColor = false;
        BtnOk.Click += BtnOk_Click;
        // 
        // PicSig
        // 
        PicSig.BackColor = Color.White;
        PicSig.BorderStyle = BorderStyle.FixedSingle;
        PicSig.Location = new Point(23, 23);
        PicSig.Name = "PicSig";
        PicSig.Size = new Size(220, 64);
        PicSig.SizeMode = PictureBoxSizeMode.Zoom;
        PicSig.TabIndex = 4;
        PicSig.TabStop = false;
        // 
        // BtnImport
        // 
        BtnImport.Cursor = Cursors.Hand;
        BtnImport.FlatStyle = FlatStyle.Flat;
        BtnImport.Image = Properties.Resources.importation_de_fichiers;
        BtnImport.Location = new Point(259, 12);
        BtnImport.Name = "BtnImport";
        BtnImport.Size = new Size(159, 41);
        BtnImport.TabIndex = 5;
        BtnImport.Text = "  &Importer image";
        BtnImport.TextAlign = ContentAlignment.MiddleRight;
        BtnImport.TextImageRelation = TextImageRelation.ImageBeforeText;
        // 
        // BtnClear
        // 
        BtnClear.Cursor = Cursors.Hand;
        BtnClear.FlatStyle = FlatStyle.Flat;
        BtnClear.ForeColor = Color.DarkRed;
        BtnClear.Image = Properties.Resources.corbeille;
        BtnClear.Location = new Point(259, 61);
        BtnClear.Name = "BtnClear";
        BtnClear.Size = new Size(159, 38);
        BtnClear.TabIndex = 6;
        BtnClear.Text = "   &Effacer";
        BtnClear.TextAlign = ContentAlignment.MiddleRight;
        BtnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
        // 
        // LblSigFmt
        // 
        LblSigFmt.AutoSize = true;
        LblSigFmt.Font = new Font("Segoe UI", 7.5F);
        LblSigFmt.ForeColor = Color.Gray;
        LblSigFmt.Location = new Point(23, 95);
        LblSigFmt.Name = "LblSigFmt";
        LblSigFmt.Size = new Size(136, 12);
        LblSigFmt.TabIndex = 7;
        LblSigFmt.Text = "Formats : PNG, JPG, BMP, GIF";
        // 
        // SignatureForm
        // 
        AcceptButton = BtnOk;
        CancelButton = BtnAnnuler;
        ClientSize = new Size(430, 181);
        Controls.Add(PicSig);
        Controls.Add(BtnImport);
        Controls.Add(BtnClear);
        Controls.Add(LblSigFmt);
        Controls.Add(BtnAnnuler);
        Controls.Add(BtnOk);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SignatureForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Signature";
        ((System.ComponentModel.ISupportInitialize)PicSig).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    private Button     BtnAnnuler;
    private Button     BtnOk;
    private PictureBox PicSig;
    private Button BtnImport;
    private Button BtnClear;
    private Label LblSigFmt;
}
