namespace OrdreMission;

partial class ParametresForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametresForm));
        Grp = new GroupBox();
        LblIndemLbl = new Label();
        NudIndemFixe = new NumericUpDown();
        LblEuroIndem = new Label();
        LblTauxLbl = new Label();
        NudTauxKm = new NumericUpDown();
        LblEuroKm = new Label();
        LblNomArbitreLbl = new Label();
        TxtNomArbitre = new TextBox();
        GrpAddr = new GroupBox();
        LblNumeroLbl = new Label();
        TxtNumero = new TextBox();
        LblRueLbl = new Label();
        TxtRue = new TextBox();
        LblCpLbl = new Label();
        TxtCp = new TextBox();
        LblVilleLbl = new Label();
        TxtVille = new TextBox();
        GrpNominations = new GroupBox();
        LblNomNominationsLbl = new Label();
        TxtNomNominations = new TextBox();
        LblEmailNominationsLbl = new Label();
        TxtEmailNominations = new TextBox();
        LblTelNominationsLbl = new Label();
        TxtTelNominations = new TextBox();
        GrpAzureMaps = new GroupBox();
        LblAzureMapsLbl = new Label();
        TxtAzureMapsKey = new TextBox();
        BtnOk = new Button();
        BtnCancel = new Button();
        Grp.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NudIndemFixe).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NudTauxKm).BeginInit();
        GrpAddr.SuspendLayout();
        GrpNominations.SuspendLayout();
        GrpAzureMaps.SuspendLayout();
        SuspendLayout();
        // 
        // Grp
        // 
        Grp.Controls.Add(LblIndemLbl);
        Grp.Controls.Add(NudIndemFixe);
        Grp.Controls.Add(LblEuroIndem);
        Grp.Controls.Add(LblTauxLbl);
        Grp.Controls.Add(NudTauxKm);
        Grp.Controls.Add(LblEuroKm);
        Grp.Location = new Point(12, 10);
        Grp.Name = "Grp";
        Grp.Size = new Size(396, 106);
        Grp.TabIndex = 0;
        Grp.TabStop = false;
        Grp.Text = "Montants réglementaires";
        // 
        // LblIndemLbl
        // 
        LblIndemLbl.AutoSize = true;
        LblIndemLbl.Location = new Point(12, 28);
        LblIndemLbl.Name = "LblIndemLbl";
        LblIndemLbl.Size = new Size(89, 15);
        LblIndemLbl.TabIndex = 0;
        LblIndemLbl.Text = "Indemnité fixe :";
        // 
        // NudIndemFixe
        // 
        NudIndemFixe.DecimalPlaces = 2;
        NudIndemFixe.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        NudIndemFixe.Location = new Point(188, 24);
        NudIndemFixe.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        NudIndemFixe.Name = "NudIndemFixe";
        NudIndemFixe.Size = new Size(80, 23);
        NudIndemFixe.TabIndex = 1;
        // 
        // LblEuroIndem
        // 
        LblEuroIndem.AutoSize = true;
        LblEuroIndem.Location = new Point(273, 28);
        LblEuroIndem.Name = "LblEuroIndem";
        LblEuroIndem.Size = new Size(13, 15);
        LblEuroIndem.TabIndex = 2;
        LblEuroIndem.Text = "€";
        // 
        // LblTauxLbl
        // 
        LblTauxLbl.AutoSize = true;
        LblTauxLbl.Location = new Point(12, 70);
        LblTauxLbl.Name = "LblTauxLbl";
        LblTauxLbl.Size = new Size(107, 15);
        LblTauxLbl.TabIndex = 3;
        LblTauxLbl.Text = "Taux kilométrique :";
        // 
        // NudTauxKm
        // 
        NudTauxKm.DecimalPlaces = 2;
        NudTauxKm.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
        NudTauxKm.Location = new Point(188, 66);
        NudTauxKm.Maximum = new decimal(new int[] { 999, 0, 0, 131072 });
        NudTauxKm.Name = "NudTauxKm";
        NudTauxKm.Size = new Size(80, 23);
        NudTauxKm.TabIndex = 4;
        // 
        // LblEuroKm
        // 
        LblEuroKm.AutoSize = true;
        LblEuroKm.Location = new Point(273, 70);
        LblEuroKm.Name = "LblEuroKm";
        LblEuroKm.Size = new Size(41, 15);
        LblEuroKm.TabIndex = 5;
        LblEuroKm.Text = "€ / km";
        // 
        // LblNomArbitreLbl
        // 
        LblNomArbitreLbl.AutoSize = true;
        LblNomArbitreLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblNomArbitreLbl.Location = new Point(20, 124);
        LblNomArbitreLbl.Name = "LblNomArbitreLbl";
        LblNomArbitreLbl.Size = new Size(53, 15);
        LblNomArbitreLbl.TabIndex = 20;
        LblNomArbitreLbl.Text = "Arbitre :";
        // 
        // TxtNomArbitre
        // 
        TxtNomArbitre.Location = new Point(79, 121);
        TxtNomArbitre.MaxLength = 80;
        TxtNomArbitre.Name = "TxtNomArbitre";
        TxtNomArbitre.PlaceholderText = "Prénom NOM";
        TxtNomArbitre.Size = new Size(315, 23);
        TxtNomArbitre.TabIndex = 21;
        // 
        // GrpAddr
        // 
        GrpAddr.Controls.Add(LblNumeroLbl);
        GrpAddr.Controls.Add(TxtNumero);
        GrpAddr.Controls.Add(LblRueLbl);
        GrpAddr.Controls.Add(TxtRue);
        GrpAddr.Controls.Add(LblCpLbl);
        GrpAddr.Controls.Add(TxtCp);
        GrpAddr.Controls.Add(LblVilleLbl);
        GrpAddr.Controls.Add(TxtVille);
        GrpAddr.Location = new Point(12, 152);
        GrpAddr.Name = "GrpAddr";
        GrpAddr.Size = new Size(396, 100);
        GrpAddr.TabIndex = 3;
        GrpAddr.TabStop = false;
        GrpAddr.Text = "Adresse de départ";
        // 
        // LblNumeroLbl
        // 
        LblNumeroLbl.AutoSize = true;
        LblNumeroLbl.Location = new Point(10, 28);
        LblNumeroLbl.Name = "LblNumeroLbl";
        LblNumeroLbl.Size = new Size(27, 15);
        LblNumeroLbl.TabIndex = 0;
        LblNumeroLbl.Text = "N° :";
        // 
        // TxtNumero
        // 
        TxtNumero.Location = new Point(42, 24);
        TxtNumero.Name = "TxtNumero";
        TxtNumero.Size = new Size(55, 23);
        TxtNumero.TabIndex = 1;
        // 
        // LblRueLbl
        // 
        LblRueLbl.AutoSize = true;
        LblRueLbl.Location = new Point(108, 28);
        LblRueLbl.Name = "LblRueLbl";
        LblRueLbl.Size = new Size(33, 15);
        LblRueLbl.TabIndex = 2;
        LblRueLbl.Text = "Rue :";
        // 
        // TxtRue
        // 
        TxtRue.Location = new Point(145, 24);
        TxtRue.Name = "TxtRue";
        TxtRue.Size = new Size(238, 23);
        TxtRue.TabIndex = 3;
        // 
        // LblCpLbl
        // 
        LblCpLbl.AutoSize = true;
        LblCpLbl.Location = new Point(10, 64);
        LblCpLbl.Name = "LblCpLbl";
        LblCpLbl.Size = new Size(76, 15);
        LblCpLbl.TabIndex = 4;
        LblCpLbl.Text = "Code postal :";
        // 
        // TxtCp
        // 
        TxtCp.Location = new Point(114, 60);
        TxtCp.Name = "TxtCp";
        TxtCp.Size = new Size(80, 23);
        TxtCp.TabIndex = 5;
        // 
        // LblVilleLbl
        // 
        LblVilleLbl.AutoSize = true;
        LblVilleLbl.Location = new Point(205, 64);
        LblVilleLbl.Name = "LblVilleLbl";
        LblVilleLbl.Size = new Size(35, 15);
        LblVilleLbl.TabIndex = 6;
        LblVilleLbl.Text = "Ville :";
        // 
        // TxtVille
        // 
        TxtVille.Location = new Point(244, 60);
        TxtVille.Name = "TxtVille";
        TxtVille.Size = new Size(140, 23);
        TxtVille.TabIndex = 7;
        // 
        // GrpNominations
        // 
        GrpNominations.Controls.Add(LblNomNominationsLbl);
        GrpNominations.Controls.Add(TxtNomNominations);
        GrpNominations.Controls.Add(LblEmailNominationsLbl);
        GrpNominations.Controls.Add(TxtEmailNominations);
        GrpNominations.Controls.Add(LblTelNominationsLbl);
        GrpNominations.Controls.Add(TxtTelNominations);
        GrpNominations.Location = new Point(12, 258);
        GrpNominations.Name = "GrpNominations";
        GrpNominations.Size = new Size(396, 116);
        GrpNominations.TabIndex = 6;
        GrpNominations.TabStop = false;
        GrpNominations.Text = "Responsable des nominations";
        // 
        // LblNomNominationsLbl
        // 
        LblNomNominationsLbl.AutoSize = true;
        LblNomNominationsLbl.Location = new Point(10, 28);
        LblNomNominationsLbl.Name = "LblNomNominationsLbl";
        LblNomNominationsLbl.Size = new Size(40, 15);
        LblNomNominationsLbl.TabIndex = 0;
        LblNomNominationsLbl.Text = "Nom :";
        // 
        // TxtNomNominations
        // 
        TxtNomNominations.Location = new Point(114, 24);
        TxtNomNominations.Name = "TxtNomNominations";
        TxtNomNominations.PlaceholderText = "Prénom NOM";
        TxtNomNominations.Size = new Size(268, 23);
        TxtNomNominations.TabIndex = 1;
        // 
        // LblEmailNominationsLbl
        // 
        LblEmailNominationsLbl.AutoSize = true;
        LblEmailNominationsLbl.Location = new Point(10, 60);
        LblEmailNominationsLbl.Name = "LblEmailNominationsLbl";
        LblEmailNominationsLbl.Size = new Size(42, 15);
        LblEmailNominationsLbl.TabIndex = 2;
        LblEmailNominationsLbl.Text = "Email :";
        // 
        // TxtEmailNominations
        // 
        TxtEmailNominations.Location = new Point(114, 56);
        TxtEmailNominations.Name = "TxtEmailNominations";
        TxtEmailNominations.PlaceholderText = "responsable@ligue.fftt.fr";
        TxtEmailNominations.Size = new Size(268, 23);
        TxtEmailNominations.TabIndex = 3;
        // 
        // LblTelNominationsLbl
        // 
        LblTelNominationsLbl.AutoSize = true;
        LblTelNominationsLbl.Location = new Point(10, 92);
        LblTelNominationsLbl.Name = "LblTelNominationsLbl";
        LblTelNominationsLbl.Size = new Size(67, 15);
        LblTelNominationsLbl.TabIndex = 4;
        LblTelNominationsLbl.Text = "Téléphone :";
        // 
        // TxtTelNominations
        // 
        TxtTelNominations.Location = new Point(114, 88);
        TxtTelNominations.Name = "TxtTelNominations";
        TxtTelNominations.PlaceholderText = "06 00 00 00 00";
        TxtTelNominations.Size = new Size(160, 23);
        TxtTelNominations.TabIndex = 5;
        // 
        // GrpAzureMaps
        // 
        GrpAzureMaps.Controls.Add(LblAzureMapsLbl);
        GrpAzureMaps.Controls.Add(TxtAzureMapsKey);
        GrpAzureMaps.Location = new Point(12, 380);
        GrpAzureMaps.Name = "GrpAzureMaps";
        GrpAzureMaps.Size = new Size(396, 55);
        GrpAzureMaps.TabIndex = 7;
        GrpAzureMaps.TabStop = false;
        GrpAzureMaps.Text = "OpenRouteService (calcul d'itinéraire)";
        // 
        // LblAzureMapsLbl
        // 
        LblAzureMapsLbl.AutoSize = true;
        LblAzureMapsLbl.Location = new Point(10, 24);
        LblAzureMapsLbl.Name = "LblAzureMapsLbl";
        LblAzureMapsLbl.Size = new Size(51, 15);
        LblAzureMapsLbl.TabIndex = 0;
        LblAzureMapsLbl.Text = "Clé API :";
        // 
        // TxtAzureMapsKey
        // 
        TxtAzureMapsKey.Location = new Point(138, 20);
        TxtAzureMapsKey.Name = "TxtAzureMapsKey";
        TxtAzureMapsKey.PlaceholderText = "Votre clé Azure Maps…";
        TxtAzureMapsKey.Size = new Size(244, 23);
        TxtAzureMapsKey.TabIndex = 1;
        // 
        // BtnOk
        // 
        BtnOk.BackColor = Color.FromArgb(21, 101, 192);
        BtnOk.DialogResult = DialogResult.OK;
        BtnOk.FlatAppearance.BorderSize = 0;
        BtnOk.FlatStyle = FlatStyle.Flat;
        BtnOk.ForeColor = Color.White;
        BtnOk.Image = Properties.Resources.save1;
        BtnOk.ImageAlign = ContentAlignment.MiddleLeft;
        BtnOk.Padding    = new Padding(6, 0, 0, 0);
        BtnOk.Location = new Point(285, 448);
        BtnOk.Name = "BtnOk";
        BtnOk.Size = new Size(123, 38);
        BtnOk.TabIndex = 7;
        BtnOk.Text = "  &Enregistrer";
        BtnOk.TextAlign = ContentAlignment.MiddleRight;
        BtnOk.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnOk.UseVisualStyleBackColor = false;
        BtnOk.Click += BtnOk_Click;
        // 
        // BtnCancel
        // 
        BtnCancel.DialogResult = DialogResult.Cancel;
        BtnCancel.FlatStyle = FlatStyle.Flat;
        BtnCancel.Image = Properties.Resources.cancel;
        BtnCancel.ImageAlign = ContentAlignment.MiddleLeft;
        BtnCancel.Padding    = new Padding(6, 0, 0, 0);
        BtnCancel.Location = new Point(10, 448);
        BtnCancel.Name = "BtnCancel";
        BtnCancel.Size = new Size(121, 38);
        BtnCancel.TabIndex = 8;
        BtnCancel.Text = "  &Annuler";
        BtnCancel.TextAlign = ContentAlignment.MiddleRight;
        BtnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
        // 
        // ParametresForm
        // 
        AcceptButton = BtnOk;
        CancelButton = BtnCancel;
        ClientSize = new Size(420, 496);
        Controls.Add(LblNomArbitreLbl);
        Controls.Add(TxtNomArbitre);
        Controls.Add(Grp);
        Controls.Add(GrpAddr);
        Controls.Add(GrpNominations);
        Controls.Add(GrpAzureMaps);
        Controls.Add(BtnOk);
        Controls.Add(BtnCancel);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ParametresForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Paramètres";
        Grp.ResumeLayout(false);
        Grp.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NudIndemFixe).EndInit();
        ((System.ComponentModel.ISupportInitialize)NudTauxKm).EndInit();
        GrpAddr.ResumeLayout(false);
        GrpAddr.PerformLayout();
        GrpNominations.ResumeLayout(false);
        GrpNominations.PerformLayout();
        GrpAzureMaps.ResumeLayout(false);
        GrpAzureMaps.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox Grp;
    private Label         LblIndemLbl;
    private NumericUpDown NudIndemFixe;
    private Label         LblEuroIndem;
    private Label         LblTauxLbl;
    private NumericUpDown NudTauxKm;
    private Label         LblEuroKm;

    private Label    LblNomArbitreLbl;
    private TextBox  TxtNomArbitre;
    private GroupBox GrpAddr;
    private Label    LblNumeroLbl;
    private TextBox  TxtNumero;
    private Label    LblRueLbl;
    private TextBox  TxtRue;
    private Label    LblCpLbl;
    private TextBox  TxtCp;
    private Label    LblVilleLbl;
    private TextBox  TxtVille;

    private GroupBox GrpNominations;
    private GroupBox GrpAzureMaps;
    private Label    LblAzureMapsLbl;
    private TextBox  TxtAzureMapsKey;
    private Label    LblNomNominationsLbl;
    private TextBox  TxtNomNominations;
    private Label    LblEmailNominationsLbl;
    private TextBox  TxtEmailNominations;
    private Label    LblTelNominationsLbl;
    private TextBox  TxtTelNominations;

    private Button BtnOk;
    private Button BtnCancel;
}
