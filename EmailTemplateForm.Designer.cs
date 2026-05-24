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
        LblVars = new Label();
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
        GrpVars.Controls.Add(LblVars);
        GrpVars.Location = new Point(12, 8);
        GrpVars.Name = "GrpVars";
        GrpVars.Size = new Size(636, 82);
        GrpVars.TabIndex = 0;
        GrpVars.TabStop = false;
        GrpVars.Text = "Variables disponibles";
        // 
        // LblVars
        // 
        LblVars.Dock = DockStyle.Fill;
        LblVars.Font = new Font("Consolas", 8.5F);
        LblVars.ForeColor = Color.FromArgb(30, 60, 120);
        LblVars.Location = new Point(3, 20);
        LblVars.Name = "LblVars";
        LblVars.Size = new Size(630, 59);
        LblVars.TabIndex = 0;
        LblVars.Text = "  {jourCourt}  ex : «Samedi 15/12/2026»\r\n  {jourLong}  ex : «samedi 15 décembre 2026»\r\n  {heure}       ex : «16h00»                             \r\n  {nomArbitre}  ex : votre nom";
        // 
        // LblSujet
        // 
        LblSujet.AutoSize = true;
        LblSujet.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblSujet.Location = new Point(15, 105);
        LblSujet.Name = "LblSujet";
        LblSujet.Size = new Size(47, 17);
        LblSujet.TabIndex = 1;
        LblSujet.Text = "Sujet :";
        // 
        // TxtSujet
        // 
        TxtSujet.Location = new Point(83, 102);
        TxtSujet.Name = "TxtSujet";
        TxtSujet.Size = new Size(568, 24);
        TxtSujet.TabIndex = 0;
        // 
        // LblCorps
        // 
        LblCorps.AutoSize = true;
        LblCorps.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblCorps.Location = new Point(15, 141);
        LblCorps.Name = "LblCorps";
        LblCorps.Size = new Size(51, 17);
        LblCorps.TabIndex = 2;
        LblCorps.Text = "Corps :";
        // 
        // TxtCorps
        // 
        TxtCorps.AcceptsReturn = true;
        TxtCorps.Font = new Font("Segoe UI", 9.5F);
        TxtCorps.Location = new Point(15, 161);
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
        BtnReinit.Location = new Point(15, 443);
        BtnReinit.Name = "BtnReinit";
        BtnReinit.Size = new Size(170, 30);
        BtnReinit.TabIndex = 2;
        BtnReinit.Text = "↺  Réinitialiser";
        BtnReinit.Click += BtnReinit_Click;
        // 
        // BtnAnnuler
        // 
        BtnAnnuler.Cursor = Cursors.Hand;
        BtnAnnuler.DialogResult = DialogResult.Cancel;
        BtnAnnuler.FlatStyle = FlatStyle.Flat;
        BtnAnnuler.Location = new Point(355, 443);
        BtnAnnuler.Name = "BtnAnnuler";
        BtnAnnuler.Size = new Size(140, 30);
        BtnAnnuler.TabIndex = 3;
        BtnAnnuler.Text = "Annuler";
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
        BtnOk.Location = new Point(503, 443);
        BtnOk.Name = "BtnOk";
        BtnOk.Size = new Size(148, 30);
        BtnOk.TabIndex = 4;
        BtnOk.Text = "Enregistrer";
        BtnOk.UseVisualStyleBackColor = false;
        BtnOk.Click += BtnOk_Click;
        // 
        // EmailTemplateForm
        // 
        AcceptButton = BtnOk;
        CancelButton = BtnAnnuler;
        ClientSize = new Size(660, 486);
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
    private Label    LblVars;
    private Label    LblSujet;
    private TextBox  TxtSujet;
    private Label    LblCorps;
    private TextBox  TxtCorps;
    private Button   BtnReinit;
    private Button   BtnAnnuler;
    private Button   BtnOk;
}
