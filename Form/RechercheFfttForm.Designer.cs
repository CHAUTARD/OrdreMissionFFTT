namespace OrdreMission;

partial class RechercheFfttForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        _ctsFetch?.Cancel();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        GrpCred = new GroupBox();
        MnuBar = new MenuStrip();
        MnuIdentifiants = new ToolStripMenuItem();
        LblApiId = new Label();
        TxtApiId = new TextBox();
        LblApiPwd = new Label();
        TxtApiPwd = new TextBox();
        BtnSauvegarderCred = new Button();
        LblCredEtat = new Label();
        LblCp = new Label();
        TxtCp = new TextBox();
        BtnRechercher = new Button();
        DgvClubs = new DataGridView();
        ColNom = new DataGridViewTextBoxColumn();
        ColNumero = new DataGridViewTextBoxColumn();
        GrpDetail = new GroupBox();
        LblDetail = new Label();
        LblStatus = new Label();
        BtnEmail = new Button();
        BtnFermer = new Button();
        GrpCred.SuspendLayout();
        MnuBar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DgvClubs).BeginInit();
        GrpDetail.SuspendLayout();
        SuspendLayout();
        // 
        // GrpCred
        // 
        GrpCred.Controls.Add(LblApiId);
        GrpCred.Controls.Add(TxtApiId);
        GrpCred.Controls.Add(LblApiPwd);
        GrpCred.Controls.Add(TxtApiPwd);
        GrpCred.Controls.Add(BtnSauvegarderCred);
        GrpCred.Controls.Add(LblCredEtat);
        GrpCred.Location = new Point(12, 36);
        GrpCred.Name = "GrpCred";
        GrpCred.Size = new Size(656, 59);
        GrpCred.TabIndex = 0;
        GrpCred.TabStop = false;
        GrpCred.Text = "Identifiants API FFTT Smartping";
        GrpCred.Visible = false;
        // 
        // MnuBar
        // 
        MnuBar.Items.AddRange(new ToolStripItem[] { MnuIdentifiants });
        MnuBar.Location = new Point(0, 0);
        MnuBar.Name = "MnuBar";
        MnuBar.Size = new Size(680, 24);
        MnuBar.TabIndex = 10;
        MnuBar.Text = "MnuBar";
        // 
        // MnuIdentifiants
        // 
        MnuIdentifiants.Name = "MnuIdentifiants";
        MnuIdentifiants.Size = new Size(160, 20);
        MnuIdentifiants.Text = "⚙ Identifiants API";
        MnuIdentifiants.Click += MnuIdentifiants_Click;
        // 
        // LblApiId
        // 
        LblApiId.AutoSize = true;
        LblApiId.Location = new Point(10, 24);
        LblApiId.Name = "LblApiId";
        LblApiId.Size = new Size(26, 17);
        LblApiId.TabIndex = 0;
        LblApiId.Text = "Id :";
        // 
        // TxtApiId
        // 
        TxtApiId.Location = new Point(40, 21);
        TxtApiId.MaxLength = 50;
        TxtApiId.Name = "TxtApiId";
        TxtApiId.Size = new Size(110, 24);
        TxtApiId.TabIndex = 0;
        // 
        // LblApiPwd
        // 
        LblApiPwd.AutoSize = true;
        LblApiPwd.Location = new Point(162, 24);
        LblApiPwd.Name = "LblApiPwd";
        LblApiPwd.Size = new Size(96, 17);
        LblApiPwd.TabIndex = 1;
        LblApiPwd.Text = "Mot de passe :";
        // 
        // TxtApiPwd
        // 
        TxtApiPwd.Location = new Point(258, 21);
        TxtApiPwd.MaxLength = 100;
        TxtApiPwd.Name = "TxtApiPwd";
        TxtApiPwd.PasswordChar = '●';
        TxtApiPwd.Size = new Size(140, 24);
        TxtApiPwd.TabIndex = 1;
        // 
        // BtnSauvegarderCred
        // 
        BtnSauvegarderCred.Cursor = Cursors.Hand;
        BtnSauvegarderCred.FlatStyle = FlatStyle.Flat;
        BtnSauvegarderCred.Location = new Point(408, 19);
        BtnSauvegarderCred.Name = "BtnSauvegarderCred";
        BtnSauvegarderCred.Size = new Size(110, 26);
        BtnSauvegarderCred.TabIndex = 3;
        BtnSauvegarderCred.Text = "Enregistrer";
        BtnSauvegarderCred.Click += BtnSauvegarderCred_Click;
        // 
        // LblCredEtat
        // 
        LblCredEtat.AutoSize = true;
        LblCredEtat.Location = new Point(10, 78);
        LblCredEtat.Name = "LblCredEtat";
        LblCredEtat.Size = new Size(0, 17);
        LblCredEtat.TabIndex = 5;
        // 
        // LblCp
        // 
        LblCp.AutoSize = true;
        LblCp.Location = new Point(15, 42);
        LblCp.Name = "LblCp";
        LblCp.Size = new Size(86, 17);
        LblCp.TabIndex = 1;
        LblCp.Text = "Code postal :";
        // 
        // TxtCp
        // 
        TxtCp.Location = new Point(115, 39);
        TxtCp.MaxLength = 5;
        TxtCp.Name = "TxtCp";
        TxtCp.Size = new Size(72, 24);
        TxtCp.TabIndex = 3;
        TxtCp.KeyDown += TxtCp_KeyDown;
        // 
        // BtnRechercher
        // 
        BtnRechercher.Cursor = Cursors.Hand;
        BtnRechercher.Enabled = false;
        BtnRechercher.FlatStyle = FlatStyle.Flat;
        BtnRechercher.Location = new Point(197, 37);
        BtnRechercher.Name = "BtnRechercher";
        BtnRechercher.Size = new Size(130, 28);
        BtnRechercher.TabIndex = 4;
        BtnRechercher.Text = "🔍 Rechercher";
        BtnRechercher.Click += BtnRechercher_Click;
        // 
        // DgvClubs
        // 
        DgvClubs.AllowUserToAddRows = false;
        DgvClubs.AllowUserToDeleteRows = false;
        DgvClubs.AllowUserToResizeRows = false;
        DgvClubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvClubs.BackgroundColor = Color.White;
        DgvClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DgvClubs.Columns.AddRange(new DataGridViewColumn[] { ColNom, ColNumero });
        DgvClubs.Location = new Point(15, 74);
        DgvClubs.MultiSelect = false;
        DgvClubs.Name = "DgvClubs";
        DgvClubs.ReadOnly = true;
        DgvClubs.RowHeadersVisible = false;
        DgvClubs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        DgvClubs.Size = new Size(656, 180);
        DgvClubs.TabIndex = 5;
        DgvClubs.SelectionChanged += DgvClubs_SelectionChanged;
        // 
        // ColNom
        // 
        ColNom.FillWeight = 82F;
        ColNom.HeaderText = "Nom du club";
        ColNom.Name = "ColNom";
        ColNom.ReadOnly = true;
        // 
        // ColNumero
        // 
        ColNumero.FillWeight = 18F;
        ColNumero.HeaderText = "N°";
        ColNumero.Name = "ColNumero";
        ColNumero.ReadOnly = true;
        // 
        // GrpDetail
        // 
        GrpDetail.Controls.Add(LblDetail);
        GrpDetail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        GrpDetail.Location = new Point(15, 262);
        GrpDetail.Name = "GrpDetail";
        GrpDetail.Size = new Size(656, 118);
        GrpDetail.TabIndex = 6;
        GrpDetail.TabStop = false;
        GrpDetail.Text = "Club sélectionné";
        // 
        // LblDetail
        // 
        LblDetail.Font = new Font("Segoe UI", 9F);
        LblDetail.Location = new Point(10, 20);
        LblDetail.Name = "LblDetail";
        LblDetail.Size = new Size(630, 92);
        LblDetail.TabIndex = 0;
        // 
        // LblStatus
        // 
        LblStatus.AutoSize = true;
        LblStatus.ForeColor = Color.FromArgb(40, 80, 160);
        LblStatus.Location = new Point(15, 388);
        LblStatus.Name = "LblStatus";
        LblStatus.Size = new Size(0, 17);
        LblStatus.TabIndex = 7;
        // 
        // BtnEmail
        // 
        BtnEmail.BackColor = Color.FromArgb(21, 101, 192);
        BtnEmail.Cursor = Cursors.Hand;
        BtnEmail.Enabled = false;
        BtnEmail.FlatAppearance.BorderSize = 0;
        BtnEmail.FlatStyle = FlatStyle.Flat;
        BtnEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        BtnEmail.ForeColor = Color.White;
        BtnEmail.Image = Properties.Resources.save1;
        BtnEmail.Location = new Point(15, 407);
        BtnEmail.Name = "BtnEmail";
        BtnEmail.Size = new Size(220, 44);
        BtnEmail.TabIndex = 6;
        BtnEmail.Text = "  &Envoyer l'email de confirmation de l'arbitrage";
        BtnEmail.TextAlign = ContentAlignment.MiddleRight;
        BtnEmail.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnEmail.UseVisualStyleBackColor = false;
        BtnEmail.Click += BtnEmail_Click;
        // 
        // BtnFermer
        // 
        BtnFermer.Cursor = Cursors.Hand;
        BtnFermer.FlatStyle = FlatStyle.Flat;
        BtnFermer.Image = Properties.Resources.cancel;
        BtnFermer.Location = new Point(527, 404);
        BtnFermer.Name = "BtnFermer";
        BtnFermer.Size = new Size(128, 47);
        BtnFermer.TabIndex = 7;
        BtnFermer.Text = "  &Fermer";
        BtnFermer.TextAlign = ContentAlignment.MiddleRight;
        BtnFermer.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnFermer.Click += BtnFermer_Click;
        // 
        // RechercheFfttForm
        // 
        CancelButton = BtnFermer;
        ClientSize = new Size(680, 463);
        Controls.Add(MnuBar);
        Controls.Add(GrpCred);
        Controls.Add(LblCp);
        Controls.Add(TxtCp);
        Controls.Add(BtnRechercher);
        Controls.Add(DgvClubs);
        Controls.Add(GrpDetail);
        Controls.Add(LblStatus);
        Controls.Add(BtnEmail);
        Controls.Add(BtnFermer);
        MainMenuStrip = MnuBar;
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RechercheFfttForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Recherche club FFTT — API Smartping";
        GrpCred.ResumeLayout(false);
        GrpCred.PerformLayout();
        MnuBar.ResumeLayout(false);
        MnuBar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)DgvClubs).EndInit();
        GrpDetail.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox                   GrpCred;
    private MenuStrip                  MnuBar;
    private ToolStripMenuItem          MnuIdentifiants;
    private Label                      LblApiId;
    private TextBox                    TxtApiId;
    private Label                      LblApiPwd;
    private TextBox                    TxtApiPwd;
    private Button                     BtnSauvegarderCred;
    private Label                      LblCredEtat;
    private Label                      LblCp;
    private TextBox                    TxtCp;
    private Button                     BtnRechercher;
    private DataGridView               DgvClubs;
    private DataGridViewTextBoxColumn  ColNom;
    private DataGridViewTextBoxColumn  ColNumero;
    private GroupBox                   GrpDetail;
    private Label                      LblDetail;
    private Label                      LblStatus;
    private Button                     BtnEmail;
    private Button                     BtnFermer;
}
