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
        GrpVars = new GroupBox();
        LblVarsCol1 = new Label();
        LblVarsCol2 = new Label();
        LblSujet = new Label();
        TxtSujet = new TextBox();
        LblCorps = new Label();
        TxtCorps = new TextBox();
        BtnReinit = new Button();
        BtnAnnuler = new Button();
        BtnOk = new Button();
        GrpVars.SuspendLayout();
        SuspendLayout();
        // 
        // GrpVars
        // 
        GrpVars.Controls.Add(LblVarsCol1);
        GrpVars.Controls.Add(LblVarsCol2);
        GrpVars.Location = new Point(12, 8);
        GrpVars.Name = "GrpVars";
        GrpVars.Size = new Size(636, 80);
        GrpVars.TabIndex = 0;
        GrpVars.TabStop = false;
        GrpVars.Text = "Variables disponibles";
        // 
        // LblVarsCol1
        // 
        LblVarsCol1.Font      = new Font("Consolas", 8.5F);
        LblVarsCol1.ForeColor = Color.FromArgb(30, 60, 120);
        LblVarsCol1.Location  = new Point(6, 20);
        LblVarsCol1.Name      = "LblVarsCol1";
        LblVarsCol1.Size      = new Size(312, 54);
        LblVarsCol1.TabIndex  = 0;
        LblVarsCol1.Text      = "  {jourCourt}  : «Samedi 15/12/2026»\r\n  {jourLong}   : «samedi 15 décembre 2026»\r\n  {heure}       : «16h00»";
        // 
        // LblVarsCol2
        // 
        LblVarsCol2.Font      = new Font("Consolas", 8.5F);
        LblVarsCol2.ForeColor = Color.FromArgb(30, 60, 120);
        LblVarsCol2.Location  = new Point(324, 20);
        LblVarsCol2.Name      = "LblVarsCol2";
        LblVarsCol2.Size      = new Size(306, 54);
        LblVarsCol2.TabIndex  = 1;
        LblVarsCol2.Text      = "  {nomArbitre} : votre nom\r\n  {equipe}      : CP PAVILLY 1";
        // 
        // LblSujet
        // 
        LblSujet.AutoSize = true;
        LblSujet.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblSujet.Location = new Point(12, 113);
        LblSujet.Name = "LblSujet";
        LblSujet.Size = new Size(47, 17);
        LblSujet.TabIndex = 1;
        LblSujet.Text = "Sujet :";
        // 
        // TxtSujet
        // 
        TxtSujet.Location = new Point(80, 110);
        TxtSujet.Name = "TxtSujet";
        TxtSujet.Size = new Size(568, 24);
        TxtSujet.TabIndex = 0;
        // 
        // LblCorps
        // 
        LblCorps.AutoSize = true;
        LblCorps.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblCorps.Location = new Point(12, 149);
        LblCorps.Name = "LblCorps";
        LblCorps.Size = new Size(51, 17);
        LblCorps.TabIndex = 2;
        LblCorps.Text = "Corps :";
        // 
        // TxtCorps
        // 
        TxtCorps.AcceptsReturn = true;
        TxtCorps.Font = new Font("Segoe UI", 9.5F);
        TxtCorps.Location = new Point(12, 169);
        TxtCorps.Multiline = true;
        TxtCorps.Name = "TxtCorps";
        TxtCorps.ScrollBars = ScrollBars.Vertical;
        TxtCorps.Size = new Size(636, 270);
        TxtCorps.TabIndex = 1;
        // 
        // BtnReinit
        // 
        BtnReinit.Cursor = Cursors.Hand;
        BtnReinit.FlatStyle = FlatStyle.Flat;
        BtnReinit.ForeColor = Color.DarkRed;
        BtnReinit.Image = Properties.Resources.reset;
        BtnReinit.Location = new Point(12, 451);
        BtnReinit.Name = "BtnReinit";
        BtnReinit.Size = new Size(170, 41);
        BtnReinit.TabIndex = 2;
        BtnReinit.Text = "Réinitialiser";
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
        BtnAnnuler.Location = new Point(341, 451);
        BtnAnnuler.Name = "BtnAnnuler";
        BtnAnnuler.Size = new Size(140, 41);
        BtnAnnuler.TabIndex = 3;
        BtnAnnuler.Text = "Annuler";
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
        BtnOk.Location = new Point(500, 451);
        BtnOk.Name = "BtnOk";
        BtnOk.Size = new Size(148, 41);
        BtnOk.TabIndex = 4;
        BtnOk.Text = "Enregistrer";
        BtnOk.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnOk.UseVisualStyleBackColor = false;
        BtnOk.Click += BtnOk_Click;
        // 
        // EmailTemplateForm
        // 
        AcceptButton = BtnOk;
        CancelButton = BtnAnnuler;
        ClientSize = new Size(660, 504);
        Controls.Add(GrpVars);
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
        GrpVars.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox GrpVars;
    private Label    LblVarsCol1;
    private Label    LblVarsCol2;
    private Label    LblSujet;
    private TextBox  TxtSujet;
    private Label    LblCorps;
    private TextBox  TxtCorps;
    private Button   BtnReinit;
    private Button   BtnAnnuler;
    private Button   BtnOk;
}
