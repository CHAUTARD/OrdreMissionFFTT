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
        GrpCred           = new GroupBox();
        LblApiId          = new Label();
        TxtApiId          = new TextBox();
        LblApiPwd         = new Label();
        TxtApiPwd         = new TextBox();
        BtnSauvegarderCred = new Button();
        LblNomArb         = new Label();
        TxtNomArb         = new TextBox();
        LblCredEtat       = new Label();
        LblCredLien       = new LinkLabel();
        LblCp             = new Label();
        TxtCp             = new TextBox();
        BtnRechercher     = new Button();
        DgvClubs          = new DataGridView();
        ColNom            = new DataGridViewTextBoxColumn();
        ColNumero         = new DataGridViewTextBoxColumn();
        GrpDetail         = new GroupBox();
        LblDetail         = new Label();
        LblStatus         = new Label();
        BtnEmail          = new Button();
        BtnFermer         = new Button();
        GrpCred.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DgvClubs).BeginInit();
        GrpDetail.SuspendLayout();
        SuspendLayout();

        // ── GrpCred ──────────────────────────────────────────────────────────
        GrpCred.Controls.Add(LblApiId);
        GrpCred.Controls.Add(TxtApiId);
        GrpCred.Controls.Add(LblApiPwd);
        GrpCred.Controls.Add(TxtApiPwd);
        GrpCred.Controls.Add(BtnSauvegarderCred);
        GrpCred.Controls.Add(LblNomArb);
        GrpCred.Controls.Add(TxtNomArb);
        GrpCred.Controls.Add(LblCredEtat);
        GrpCred.Controls.Add(LblCredLien);
        GrpCred.Location  = new Point(12, 12);
        GrpCred.Name      = "GrpCred";
        GrpCred.Size      = new Size(656, 104);
        GrpCred.TabStop   = false;
        GrpCred.Text      = "Identifiants API FFTT Smartping";

        // ── LblApiId ─────────────────────────────────────────────────────────
        LblApiId.AutoSize = true;
        LblApiId.Location = new Point(10, 24);
        LblApiId.Name     = "LblApiId";
        LblApiId.Text     = "Id :";

        // ── TxtApiId ─────────────────────────────────────────────────────────
        TxtApiId.Location  = new Point(40, 21);
        TxtApiId.MaxLength = 50;
        TxtApiId.Name      = "TxtApiId";
        TxtApiId.Size      = new Size(110, 24);
        TxtApiId.TabIndex  = 0;

        // ── LblApiPwd ────────────────────────────────────────────────────────
        LblApiPwd.AutoSize = true;
        LblApiPwd.Location = new Point(162, 24);
        LblApiPwd.Name     = "LblApiPwd";
        LblApiPwd.Text     = "Mot de passe :";

        // ── TxtApiPwd ────────────────────────────────────────────────────────
        TxtApiPwd.Location     = new Point(258, 21);
        TxtApiPwd.MaxLength    = 100;
        TxtApiPwd.Name         = "TxtApiPwd";
        TxtApiPwd.PasswordChar = '●';
        TxtApiPwd.Size         = new Size(140, 24);
        TxtApiPwd.TabIndex     = 1;

        // ── BtnSauvegarderCred ───────────────────────────────────────────────
        BtnSauvegarderCred.Cursor    = Cursors.Hand;
        BtnSauvegarderCred.FlatStyle = FlatStyle.Flat;
        BtnSauvegarderCred.Location  = new Point(408, 19);
        BtnSauvegarderCred.Name      = "BtnSauvegarderCred";
        BtnSauvegarderCred.Size      = new Size(110, 26);
        BtnSauvegarderCred.TabIndex  = 3;
        BtnSauvegarderCred.Text      = "Enregistrer";
        BtnSauvegarderCred.Click    += BtnSauvegarderCred_Click;

        // ── LblNomArb ────────────────────────────────────────────────────────
        LblNomArb.AutoSize = true;
        LblNomArb.Location = new Point(10, 52);
        LblNomArb.Name     = "LblNomArb";
        LblNomArb.Text     = "Nom arbitre :";

        // ── TxtNomArb ────────────────────────────────────────────────────────
        TxtNomArb.Location  = new Point(100, 49);
        TxtNomArb.MaxLength = 100;
        TxtNomArb.Name      = "TxtNomArb";
        TxtNomArb.Size      = new Size(220, 24);
        TxtNomArb.TabIndex  = 2;

        // ── LblCredEtat ──────────────────────────────────────────────────────
        LblCredEtat.AutoSize = true;
        LblCredEtat.Location = new Point(10, 78);
        LblCredEtat.Name     = "LblCredEtat";
        LblCredEtat.Text     = "";

        // ── LblCredLien ──────────────────────────────────────────────────────
        LblCredLien.AutoSize    = true;
        LblCredLien.Location    = new Point(528, 78);
        LblCredLien.Name        = "LblCredLien";
        LblCredLien.Text        = "Obtenir des identifiants";
        LblCredLien.LinkClicked += LblCredLien_LinkClicked;

        // ── LblCp ────────────────────────────────────────────────────────────
        LblCp.AutoSize = true;
        LblCp.Location = new Point(12, 130);
        LblCp.Name     = "LblCp";
        LblCp.Text     = "Code postal :";

        // ── TxtCp ────────────────────────────────────────────────────────────
        TxtCp.Location  = new Point(112, 127);
        TxtCp.MaxLength = 5;
        TxtCp.Name      = "TxtCp";
        TxtCp.Size      = new Size(72, 24);
        TxtCp.TabIndex  = 3;
        TxtCp.KeyDown  += TxtCp_KeyDown;

        // ── BtnRechercher ─────────────────────────────────────────────────────
        BtnRechercher.Cursor    = Cursors.Hand;
        BtnRechercher.Enabled   = false;
        BtnRechercher.FlatStyle = FlatStyle.Flat;
        BtnRechercher.Location  = new Point(194, 125);
        BtnRechercher.Name      = "BtnRechercher";
        BtnRechercher.Size      = new Size(130, 28);
        BtnRechercher.TabIndex  = 4;
        BtnRechercher.Text      = "🔍 Rechercher";
        BtnRechercher.Click    += BtnRechercher_Click;

        // ── DgvClubs ──────────────────────────────────────────────────────────
        DgvClubs.AllowUserToAddRows            = false;
        DgvClubs.AllowUserToDeleteRows         = false;
        DgvClubs.AllowUserToResizeRows         = false;
        DgvClubs.AutoSizeColumnsMode           = DataGridViewAutoSizeColumnsMode.Fill;
        DgvClubs.BackgroundColor               = Color.White;
        DgvClubs.ColumnHeadersHeightSizeMode   = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DgvClubs.Columns.AddRange(ColNom, ColNumero);
        DgvClubs.Location                      = new Point(12, 162);
        DgvClubs.MultiSelect                   = false;
        DgvClubs.Name                          = "DgvClubs";
        DgvClubs.ReadOnly                      = true;
        DgvClubs.RowHeadersVisible             = false;
        DgvClubs.SelectionMode                 = DataGridViewSelectionMode.FullRowSelect;
        DgvClubs.Size                          = new Size(656, 180);
        DgvClubs.TabIndex                      = 5;
        DgvClubs.SelectionChanged             += DgvClubs_SelectionChanged;

        ColNom.HeaderText  = "Nom du club";
        ColNom.Name        = "ColNom";
        ColNom.FillWeight  = 82;
        ColNom.ReadOnly    = true;

        ColNumero.HeaderText = "N°";
        ColNumero.Name       = "ColNumero";
        ColNumero.FillWeight = 18;
        ColNumero.ReadOnly   = true;

        // ── GrpDetail ─────────────────────────────────────────────────────────
        GrpDetail.Controls.Add(LblDetail);
        GrpDetail.Font     = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        GrpDetail.Location = new Point(12, 350);
        GrpDetail.Name     = "GrpDetail";
        GrpDetail.Size     = new Size(656, 118);
        GrpDetail.TabStop  = false;
        GrpDetail.Text     = "Club sélectionné";

        // ── LblDetail ─────────────────────────────────────────────────────────
        LblDetail.Font     = new Font("Segoe UI", 9F);
        LblDetail.Location = new Point(10, 20);
        LblDetail.Name     = "LblDetail";
        LblDetail.Size     = new Size(630, 92);

        // ── LblStatus ─────────────────────────────────────────────────────────
        LblStatus.AutoSize  = true;
        LblStatus.ForeColor = Color.FromArgb(40, 80, 160);
        LblStatus.Location  = new Point(12, 476);
        LblStatus.Name      = "LblStatus";
        LblStatus.Text      = "";

        // ── BtnEmail ──────────────────────────────────────────────────────────
        BtnEmail.BackColor                 = Color.FromArgb(21, 101, 192);
        BtnEmail.Cursor                    = Cursors.Hand;
        BtnEmail.Enabled                   = false;
        BtnEmail.FlatAppearance.BorderSize = 0;
        BtnEmail.FlatStyle                 = FlatStyle.Flat;
        BtnEmail.Font                      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        BtnEmail.ForeColor                 = Color.White;
        BtnEmail.Location                  = new Point(376, 500);
        BtnEmail.Name                      = "BtnEmail";
        BtnEmail.Size                      = new Size(180, 34);
        BtnEmail.TabIndex                  = 6;
        BtnEmail.Text                      = "✉  Envoyer un email";
        BtnEmail.Click                    += BtnEmail_Click;

        // ── BtnFermer ─────────────────────────────────────────────────────────
        BtnFermer.Cursor    = Cursors.Hand;
        BtnFermer.FlatStyle = FlatStyle.Flat;
        BtnFermer.Location  = new Point(566, 500);
        BtnFermer.Name      = "BtnFermer";
        BtnFermer.Size      = new Size(102, 34);
        BtnFermer.TabIndex  = 7;
        BtnFermer.Text      = "Fermer";
        BtnFermer.Click    += BtnFermer_Click;

        // ── RechercheFfttForm ─────────────────────────────────────────────────
        CancelButton    = BtnFermer;
        ClientSize      = new Size(680, 548);
        Controls.Add(GrpCred);
        Controls.Add(LblCp);
        Controls.Add(TxtCp);
        Controls.Add(BtnRechercher);
        Controls.Add(DgvClubs);
        Controls.Add(GrpDetail);
        Controls.Add(LblStatus);
        Controls.Add(BtnEmail);
        Controls.Add(BtnFermer);
        Font            = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;
        MinimizeBox     = false;
        Name            = "RechercheFfttForm";
        StartPosition   = FormStartPosition.CenterParent;
        Text            = "Recherche club FFTT — API Smartping";

        GrpCred.ResumeLayout(false);
        GrpCred.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)DgvClubs).EndInit();
        GrpDetail.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox                   GrpCred;
    private Label                      LblApiId;
    private TextBox                    TxtApiId;
    private Label                      LblApiPwd;
    private TextBox                    TxtApiPwd;
    private Button                     BtnSauvegarderCred;
    private Label                      LblNomArb;
    private TextBox                    TxtNomArb;
    private Label                      LblCredEtat;
    private LinkLabel                  LblCredLien;
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
