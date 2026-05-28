namespace OrdreMission;

partial class EmailTemplateForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailTemplateForm));
        LblSujet = new Label();
        TxtSujet = new TextBox();
        LblCorps = new Label();
        TxtCorps = new TextBox();
        BtnReinit = new Button();
        BtnAnnuler = new Button();
        BtnOk = new Button();
        SuspendLayout();
        // 
        // LblSujet
        // 
        LblSujet.AutoSize = true;
        LblSujet.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblSujet.Location = new Point(12, 8);
        LblSujet.Name = "LblSujet";
        LblSujet.Size = new Size(47, 17);
        LblSujet.TabIndex = 1;
        LblSujet.Text = "Sujet :";
        // 
        // TxtSujet
        // 
        TxtSujet.Location = new Point(80, 5);
        TxtSujet.Name = "TxtSujet";
        TxtSujet.Size = new Size(568, 24);
        TxtSujet.TabIndex = 0;
        TxtSujet.Text = "Arbitrage de la rencontre du {jourCourt}, {equipe}";
        // 
        // LblCorps
        // 
        LblCorps.AutoSize = true;
        LblCorps.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblCorps.Location = new Point(12, 44);
        LblCorps.Name = "LblCorps";
        LblCorps.Size = new Size(51, 17);
        LblCorps.TabIndex = 2;
        LblCorps.Text = "Corps :";
        // 
        // TxtCorps
        // 
        TxtCorps.AcceptsReturn = true;
        TxtCorps.Font = new Font("Segoe UI", 9.5F);
        TxtCorps.Location = new Point(12, 64);
        TxtCorps.Multiline = true;
        TxtCorps.Name = "TxtCorps";
        TxtCorps.ScrollBars = ScrollBars.Vertical;
        TxtCorps.Size = new Size(636, 292);
        TxtCorps.TabIndex = 1;
        TxtCorps.Text = resources.GetString("TxtCorps.Text");
        // 
        // BtnReinit
        // 
        BtnReinit.Cursor = Cursors.Hand;
        BtnReinit.FlatStyle = FlatStyle.Flat;
        BtnReinit.ForeColor = Color.DarkRed;
        BtnReinit.Image = Properties.Resources.reset;
        BtnReinit.Location = new Point(232, 375);
        BtnReinit.Name = "BtnReinit";
        BtnReinit.Size = new Size(170, 41);
        BtnReinit.TabIndex = 2;
        BtnReinit.Text = "  &Réinitialiser";
        BtnReinit.TextAlign = ContentAlignment.MiddleRight;
        BtnReinit.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnReinit.Click += BtnReinit_Click;
        // 
        // BtnAnnuler
        // 
        BtnAnnuler.Cursor = Cursors.Hand;
        BtnAnnuler.DialogResult = DialogResult.Cancel;
        BtnAnnuler.FlatStyle = FlatStyle.Flat;
        BtnAnnuler.Image = Properties.Resources.cancel;
        BtnAnnuler.ImageAlign = ContentAlignment.MiddleLeft;
        BtnAnnuler.Padding    = new Padding(6, 0, 0, 0);
        BtnAnnuler.Location = new Point(12, 375);
        BtnAnnuler.Name = "BtnAnnuler";
        BtnAnnuler.Size = new Size(140, 41);
        BtnAnnuler.TabIndex = 3;
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
        BtnOk.Location = new Point(500, 375);
        BtnOk.Name = "BtnOk";
        BtnOk.Size = new Size(148, 41);
        BtnOk.TabIndex = 4;
        BtnOk.Text = "  &Enregistrer";
        BtnOk.TextAlign = ContentAlignment.MiddleRight;
        BtnOk.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnOk.UseVisualStyleBackColor = false;
        BtnOk.Click += BtnOk_Click;
        // 
        // EmailTemplateForm
        // 
        AcceptButton = BtnOk;
        CancelButton = BtnAnnuler;
        ClientSize = new Size(660, 435);
        Controls.Add(LblSujet);
        Controls.Add(TxtSujet);
        Controls.Add(LblCorps);
        Controls.Add(TxtCorps);
        Controls.Add(BtnReinit);
        Controls.Add(BtnAnnuler);
        Controls.Add(BtnOk);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "EmailTemplateForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Modèle d'email d'arbitrage";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label    LblSujet;
    private TextBox  TxtSujet;
    private Label    LblCorps;
    private TextBox  TxtCorps;
    private Button   BtnReinit;
    private Button   BtnAnnuler;
    private Button   BtnOk;
}
