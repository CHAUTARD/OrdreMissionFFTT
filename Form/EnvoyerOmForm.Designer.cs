namespace OrdreMission;

partial class EnvoyerOmForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvoyerOmForm));
        GrpDestinataire = new GroupBox();
        LblNomLbl = new Label();
        LblNomVal = new Label();
        LblEmailLbl = new Label();
        LblEmailVal = new Label();
        LblTelLbl = new Label();
        LblTelVal = new Label();
        LblSujetLbl = new Label();
        TxtSujet = new TextBox();
        LblCorpsLbl = new Label();
        TxtCorps = new TextBox();
        GrpPj = new GroupBox();
        TxtPj = new TextBox();
        BtnParcourirPj = new Button();
        LblEtat = new Label();
        BtnEnvoyer = new Button();
        BtnAnnuler = new Button();
        GrpDestinataire.SuspendLayout();
        GrpPj.SuspendLayout();
        SuspendLayout();
        // 
        // GrpDestinataire
        // 
        GrpDestinataire.Controls.Add(LblNomLbl);
        GrpDestinataire.Controls.Add(LblNomVal);
        GrpDestinataire.Controls.Add(LblEmailLbl);
        GrpDestinataire.Controls.Add(LblEmailVal);
        GrpDestinataire.Controls.Add(LblTelLbl);
        GrpDestinataire.Controls.Add(LblTelVal);
        GrpDestinataire.Location = new Point(12, 10);
        GrpDestinataire.Name = "GrpDestinataire";
        GrpDestinataire.Size = new Size(556, 94);
        GrpDestinataire.TabIndex = 0;
        GrpDestinataire.TabStop = false;
        GrpDestinataire.Text = "Destinataire — Responsable des nominations";
        // 
        // LblNomLbl
        // 
        LblNomLbl.AutoSize = true;
        LblNomLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblNomLbl.Location = new Point(10, 24);
        LblNomLbl.Name = "LblNomLbl";
        LblNomLbl.Size = new Size(40, 15);
        LblNomLbl.TabIndex = 0;
        LblNomLbl.Text = "Nom :";
        // 
        // LblNomVal
        // 
        LblNomVal.AutoSize = true;
        LblNomVal.Location = new Point(80, 24);
        LblNomVal.Name = "LblNomVal";
        LblNomVal.Size = new Size(0, 17);
        LblNomVal.TabIndex = 1;
        // 
        // LblEmailLbl
        // 
        LblEmailLbl.AutoSize = true;
        LblEmailLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblEmailLbl.Location = new Point(10, 50);
        LblEmailLbl.Name = "LblEmailLbl";
        LblEmailLbl.Size = new Size(42, 15);
        LblEmailLbl.TabIndex = 2;
        LblEmailLbl.Text = "Email :";
        // 
        // LblEmailVal
        // 
        LblEmailVal.AutoSize = true;
        LblEmailVal.Location = new Point(80, 50);
        LblEmailVal.Name = "LblEmailVal";
        LblEmailVal.Size = new Size(0, 17);
        LblEmailVal.TabIndex = 3;
        // 
        // LblTelLbl
        // 
        LblTelLbl.AutoSize = true;
        LblTelLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblTelLbl.Location = new Point(10, 72);
        LblTelLbl.Name = "LblTelLbl";
        LblTelLbl.Size = new Size(32, 15);
        LblTelLbl.TabIndex = 4;
        LblTelLbl.Text = "Tél. :";
        // 
        // LblTelVal
        // 
        LblTelVal.AutoSize = true;
        LblTelVal.Location = new Point(80, 72);
        LblTelVal.Name = "LblTelVal";
        LblTelVal.Size = new Size(0, 17);
        LblTelVal.TabIndex = 5;
        // 
        // LblSujetLbl
        // 
        LblSujetLbl.AutoSize = true;
        LblSujetLbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblSujetLbl.Location = new Point(12, 120);
        LblSujetLbl.Name = "LblSujetLbl";
        LblSujetLbl.Size = new Size(47, 17);
        LblSujetLbl.TabIndex = 1;
        LblSujetLbl.Text = "Sujet :";
        // 
        // TxtSujet
        // 
        TxtSujet.Location = new Point(72, 117);
        TxtSujet.Name = "TxtSujet";
        TxtSujet.Size = new Size(496, 24);
        TxtSujet.TabIndex = 0;
        TxtSujet.Text = "Ordre de mission du {date} — {opposant}";
        // 
        // LblCorpsLbl
        // 
        LblCorpsLbl.AutoSize = true;
        LblCorpsLbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        LblCorpsLbl.Location = new Point(12, 156);
        LblCorpsLbl.Name = "LblCorpsLbl";
        LblCorpsLbl.Size = new Size(69, 17);
        LblCorpsLbl.TabIndex = 2;
        LblCorpsLbl.Text = "Message :";
        // 
        // TxtCorps
        // 
        TxtCorps.AcceptsReturn = true;
        TxtCorps.Location = new Point(12, 176);
        TxtCorps.Multiline = true;
        TxtCorps.Name = "TxtCorps";
        TxtCorps.ScrollBars = ScrollBars.Vertical;
        TxtCorps.Size = new Size(556, 160);
        TxtCorps.TabIndex = 1;
        TxtCorps.Text = "Bonjour {nom},\r\n\r\nVeuillez trouver ci-joint mon ordre de mission pour {rencontre}.\r\n\r\nCordialement,\r\n {arbitre}";
        TxtCorps.TextChanged += TxtCorps_TextChanged;
        // 
        // GrpPj
        // 
        GrpPj.Controls.Add(TxtPj);
        GrpPj.Controls.Add(BtnParcourirPj);
        GrpPj.Location = new Point(12, 346);
        GrpPj.Name = "GrpPj";
        GrpPj.Size = new Size(556, 58);
        GrpPj.TabIndex = 3;
        GrpPj.TabStop = false;
        GrpPj.Text = "Pièce jointe";
        // 
        // TxtPj
        // 
        TxtPj.BackColor = SystemColors.Control;
        TxtPj.Location = new Point(10, 24);
        TxtPj.Name = "TxtPj";
        TxtPj.PlaceholderText = "Ordre de mission rempli en PDF";
        TxtPj.ReadOnly = true;
        TxtPj.Size = new Size(420, 24);
        TxtPj.TabIndex = 0;
        TxtPj.TabStop = false;
        // 
        // BtnParcourirPj
        // 
        BtnParcourirPj.Cursor = Cursors.Hand;
        BtnParcourirPj.FlatStyle = FlatStyle.Flat;
        BtnParcourirPj.Location = new Point(436, 22);
        BtnParcourirPj.Name = "BtnParcourirPj";
        BtnParcourirPj.Size = new Size(110, 26);
        BtnParcourirPj.TabIndex = 2;
        BtnParcourirPj.Text = "Parcourir…";
        BtnParcourirPj.Click += BtnParcourirPj_Click;
        // 
        // LblEtat
        // 
        LblEtat.BorderStyle = BorderStyle.Fixed3D;
        LblEtat.Location = new Point(12, 414);
        LblEtat.Name = "LblEtat";
        LblEtat.Size = new Size(556, 36);
        LblEtat.TabIndex = 0;
        // 
        // BtnEnvoyer
        // 
        BtnEnvoyer.BackColor = Color.FromArgb(21, 101, 192);
        BtnEnvoyer.Cursor = Cursors.Hand;
        BtnEnvoyer.Enabled = false;
        BtnEnvoyer.FlatAppearance.BorderSize = 0;
        BtnEnvoyer.FlatStyle = FlatStyle.Flat;
        BtnEnvoyer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        BtnEnvoyer.ForeColor = Color.White;
        BtnEnvoyer.Image = Properties.Resources.email;
        BtnEnvoyer.Location = new Point(396, 465);
        BtnEnvoyer.Name = "BtnEnvoyer";
        BtnEnvoyer.Size = new Size(172, 43);
        BtnEnvoyer.TabIndex = 3;
        BtnEnvoyer.Text = "  &Envoyer l'ordre de mission";
        BtnEnvoyer.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnEnvoyer.UseVisualStyleBackColor = false;
        BtnEnvoyer.Click += BtnEnvoyer_Click;
        // 
        // BtnAnnuler
        // 
        BtnAnnuler.Cursor = Cursors.Hand;
        BtnAnnuler.DialogResult = DialogResult.Cancel;
        BtnAnnuler.FlatStyle = FlatStyle.Flat;
        BtnAnnuler.Image = Properties.Resources.cancel;
        BtnAnnuler.Location = new Point(12, 465);
        BtnAnnuler.Name = "BtnAnnuler";
        BtnAnnuler.Size = new Size(148, 43);
        BtnAnnuler.TabIndex = 4;
        BtnAnnuler.Text = "  &Annuler";
        BtnAnnuler.TextAlign = ContentAlignment.MiddleRight;
        BtnAnnuler.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnAnnuler.Click += BtnAnnuler_Click;
        // 
        // EnvoyerOmForm
        // 
        AcceptButton = BtnEnvoyer;
        CancelButton = BtnAnnuler;
        ClientSize = new Size(580, 520);
        Controls.Add(GrpDestinataire);
        Controls.Add(LblSujetLbl);
        Controls.Add(TxtSujet);
        Controls.Add(LblCorpsLbl);
        Controls.Add(TxtCorps);
        Controls.Add(GrpPj);
        Controls.Add(LblEtat);
        Controls.Add(BtnAnnuler);
        Controls.Add(BtnEnvoyer);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "EnvoyerOmForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Envoyer l'ordre de mission au responsable des nominations";
        GrpDestinataire.ResumeLayout(false);
        GrpDestinataire.PerformLayout();
        GrpPj.ResumeLayout(false);
        GrpPj.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox GrpDestinataire;
    private Label    LblNomLbl;
    private Label    LblNomVal;
    private Label    LblEmailLbl;
    private Label    LblEmailVal;
    private Label    LblTelLbl;
    private Label    LblTelVal;
    private Label    LblSujetLbl;
    private TextBox  TxtSujet;
    private Label    LblCorpsLbl;
    private TextBox  TxtCorps;
    private GroupBox GrpPj;
    private TextBox  TxtPj;
    private Button   BtnParcourirPj;
    private Label    LblEtat;
    private Button   BtnAnnuler;
    private Button   BtnEnvoyer;
}
