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
        Grp = new GroupBox();
        LblIndemLbl = new Label();
        NudIndemFixe = new NumericUpDown();
        LblEuroIndem = new Label();
        LblTauxLbl = new Label();
        NudTauxKm = new NumericUpDown();
        LblEuroKm = new Label();
        GrpAddr = new GroupBox();
        LblNumeroLbl = new Label();
        TxtNumero = new TextBox();
        LblRueLbl = new Label();
        TxtRue = new TextBox();
        LblCpLbl = new Label();
        TxtCp = new TextBox();
        LblVilleLbl = new Label();
        TxtVille = new TextBox();
        BtnOk = new Button();
        BtnCancel = new Button();
        Grp.SuspendLayout();
        GrpAddr.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NudIndemFixe).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NudTauxKm).BeginInit();
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
        Grp.Size = new Size(396, 118);
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
        GrpAddr.Location = new Point(12, 138);
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
        // BtnOk
        //
        BtnOk.BackColor = Color.FromArgb(21, 101, 192);
        BtnOk.DialogResult = DialogResult.OK;
        BtnOk.FlatAppearance.BorderSize = 0;
        BtnOk.FlatStyle = FlatStyle.Flat;
        BtnOk.ForeColor = Color.White;
        BtnOk.Location = new Point(12, 252);
        BtnOk.Name = "BtnOk";
        BtnOk.Size = new Size(106, 30);
        BtnOk.TabIndex = 4;
        BtnOk.Text = "Enregistrer";
        BtnOk.UseVisualStyleBackColor = false;
        BtnOk.Click += BtnOk_Click;
        // 
        // BtnCancel
        // 
        BtnCancel.DialogResult = DialogResult.Cancel;
        BtnCancel.FlatStyle = FlatStyle.Flat;
        BtnCancel.Location = new Point(328, 252);
        BtnCancel.Name = "BtnCancel";
        BtnCancel.Size = new Size(80, 30);
        BtnCancel.TabIndex = 5;
        BtnCancel.Text = "Annuler";
        // 
        // ParametresForm
        // 
        AcceptButton = BtnOk;
        CancelButton = BtnCancel;
        ClientSize = new Size(420, 294);
        Controls.Add(Grp);
        Controls.Add(GrpAddr);
        Controls.Add(BtnOk);
        Controls.Add(BtnCancel);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ParametresForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Paramètres";
        Grp.ResumeLayout(false);
        Grp.PerformLayout();
        GrpAddr.ResumeLayout(false);
        GrpAddr.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NudIndemFixe).EndInit();
        ((System.ComponentModel.ISupportInitialize)NudTauxKm).EndInit();
        ResumeLayout(false);
    }

    private GroupBox Grp;
    private Label         LblIndemLbl;
    private NumericUpDown NudIndemFixe;
    private Label         LblEuroIndem;
    private Label         LblTauxLbl;
    private NumericUpDown NudTauxKm;
    private Label         LblEuroKm;

    private GroupBox GrpAddr;
    private Label    LblNumeroLbl;
    private TextBox  TxtNumero;
    private Label    LblRueLbl;
    private TextBox  TxtRue;
    private Label    LblCpLbl;
    private TextBox  TxtCp;
    private Label    LblVilleLbl;
    private TextBox  TxtVille;

    private Button BtnOk;
    private Button BtnCancel;
}
