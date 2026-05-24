namespace OrdreMission;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        PicSig.Image?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        GrpPdf = new GroupBox();
        LblSourceLabel = new Label();
        TxtSource = new TextBox();
        BtnSource = new Button();
        LblOutputLabel = new Label();
        TxtOutput = new TextBox();
        BtnOutput = new Button();
        BtnParams = new Button();
        GrpComp = new GroupBox();
        LblCompOpposant = new Label();
        TxtCompOpposant = new TextBox();
        LblCompDate = new Label();
        TxtCompDate = new TextBox();
        LblCompHeure = new Label();
        TxtCompHeure = new TextBox();
        LblCompAdresse = new Label();
        TxtCompAdresse = new TextBox();
        LblCompResponsable = new Label();
        TxtCompResponsable = new TextBox();
        GrpIndem = new GroupBox();
        TblFinancier = new TableLayoutPanel();
        LblHdrIndemFix = new Label();
        LblHdrPeages = new Label();
        LblHdrDepl = new Label();
        LblHdrTotal = new Label();
        LblIndemFixeVal = new Label();
        PnlPeage = new Panel();
        NudPeage = new NumericUpDown();
        LblEuroPeage = new Label();
        PnlDep = new Panel();
        NudKm = new NumericUpDown();
        LblKmTaux = new Label();
        LblTotal = new Label();
        GrpRap = new GroupBox();
        TblRapport = new TableLayoutPanel();
        LblRapHdr0 = new Label();
        LblRapHdr1 = new Label();
        LblRapLbl1 = new Label();
        PnlRapAccueil = new Panel();
        TxtRapAccueil = new TextBox();
        LblRapLbl2 = new Label();
        PnlRapEquip = new Panel();
        TxtRapEquip = new TextBox();
        GrpSig = new GroupBox();
        PicSig = new PictureBox();
        LblSigHint = new Label();
        BtnImport = new Button();
        BtnClear = new Button();
        LblSigFmt = new Label();
        BtnGen = new Button();
        BtnReset = new Button();
        BtnPos = new Button();
        BtnOpen = new Button();
        PnlStatus = new Panel();
        LblStatus = new Label();
        GrpPdf.SuspendLayout();
        GrpComp.SuspendLayout();
        GrpIndem.SuspendLayout();
        TblFinancier.SuspendLayout();
        PnlPeage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NudPeage).BeginInit();
        PnlDep.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NudKm).BeginInit();
        GrpRap.SuspendLayout();
        TblRapport.SuspendLayout();
        PnlRapAccueil.SuspendLayout();
        PnlRapEquip.SuspendLayout();
        GrpSig.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PicSig).BeginInit();
        PnlStatus.SuspendLayout();
        SuspendLayout();
        // 
        // GrpPdf
        // 
        GrpPdf.Controls.Add(LblSourceLabel);
        GrpPdf.Controls.Add(TxtSource);
        GrpPdf.Controls.Add(BtnSource);
        GrpPdf.Controls.Add(LblOutputLabel);
        GrpPdf.Controls.Add(TxtOutput);
        GrpPdf.Controls.Add(BtnOutput);
        GrpPdf.Location = new Point(12, 10);
        GrpPdf.Name = "GrpPdf";
        GrpPdf.Size = new Size(644, 90);
        GrpPdf.TabIndex = 0;
        GrpPdf.TabStop = false;
        GrpPdf.Text = "Fichier PDF";
        // 
        // LblSourceLabel
        // 
        LblSourceLabel.AutoSize = true;
        LblSourceLabel.Location = new Point(10, 27);
        LblSourceLabel.Name = "LblSourceLabel";
        LblSourceLabel.Size = new Size(55, 17);
        LblSourceLabel.TabIndex = 0;
        LblSourceLabel.Text = "Source :";
        // 
        // TxtSource
        // 
        TxtSource.Location = new Point(72, 24);
        TxtSource.Name = "TxtSource";
        TxtSource.PlaceholderText = "Sélectionner le PDF de la convocation…";
        TxtSource.Size = new Size(443, 24);
        TxtSource.TabIndex = 1;
        // 
        // BtnSource
        // 
        BtnSource.Cursor = Cursors.Hand;
        BtnSource.FlatStyle = FlatStyle.Flat;
        BtnSource.Location = new Point(534, 23);
        BtnSource.Name = "BtnSource";
        BtnSource.Size = new Size(100, 26);
        BtnSource.TabIndex = 2;
        BtnSource.Text = "&Parcourir…";
        BtnSource.Click += BtnSource_Click;
        // 
        // LblOutputLabel
        // 
        LblOutputLabel.AutoSize = true;
        LblOutputLabel.Location = new Point(10, 59);
        LblOutputLabel.Name = "LblOutputLabel";
        LblOutputLabel.Size = new Size(49, 17);
        LblOutputLabel.TabIndex = 3;
        LblOutputLabel.Text = "Sortie :";
        // 
        // TxtOutput
        // 
        TxtOutput.Location = new Point(72, 56);
        TxtOutput.Name = "TxtOutput";
        TxtOutput.PlaceholderText = "PDF généré (laissez vide pour nommer automatiquement)…";
        TxtOutput.Size = new Size(443, 24);
        TxtOutput.TabIndex = 4;
        // 
        // BtnOutput
        // 
        BtnOutput.Cursor = Cursors.Hand;
        BtnOutput.FlatStyle = FlatStyle.Flat;
        BtnOutput.Location = new Point(534, 56);
        BtnOutput.Name = "BtnOutput";
        BtnOutput.Size = new Size(100, 26);
        BtnOutput.TabIndex = 5;
        BtnOutput.Text = "Parcourir…";
        BtnOutput.Click += BtnOutput_Click;
        // 
        // BtnParams
        // 
        BtnParams.Cursor = Cursors.Hand;
        BtnParams.FlatStyle = FlatStyle.Flat;
        BtnParams.Location = new Point(662, 1);
        BtnParams.Name = "BtnParams";
        BtnParams.Size = new Size(35, 33);
        BtnParams.TabIndex = 9;
        BtnParams.Text = "⚙";
        BtnParams.Click += BtnParams_Click;
        // 
        // GrpComp
        // 
        GrpComp.Controls.Add(LblCompOpposant);
        GrpComp.Controls.Add(TxtCompOpposant);
        GrpComp.Controls.Add(LblCompDate);
        GrpComp.Controls.Add(TxtCompDate);
        GrpComp.Controls.Add(LblCompHeure);
        GrpComp.Controls.Add(TxtCompHeure);
        GrpComp.Controls.Add(LblCompAdresse);
        GrpComp.Controls.Add(TxtCompAdresse);
        GrpComp.Controls.Add(LblCompResponsable);
        GrpComp.Controls.Add(TxtCompResponsable);
        GrpComp.Location = new Point(12, 110);
        GrpComp.Name = "GrpComp";
        GrpComp.Size = new Size(660, 100);
        GrpComp.TabIndex = 10;
        GrpComp.TabStop = false;
        GrpComp.Text = "Compétition";
        // 
        // LblCompOpposant
        // 
        LblCompOpposant.AutoSize = true;
        LblCompOpposant.Location = new Point(8, 28);
        LblCompOpposant.Name = "LblCompOpposant";
        LblCompOpposant.Size = new Size(73, 17);
        LblCompOpposant.TabIndex = 0;
        LblCompOpposant.Text = "Opposant :";
        // 
        // TxtCompOpposant
        // 
        TxtCompOpposant.Location = new Point(87, 25);
        TxtCompOpposant.Name = "TxtCompOpposant";
        TxtCompOpposant.PlaceholderText = "Nom du club…";
        TxtCompOpposant.Size = new Size(271, 24);
        TxtCompOpposant.TabIndex = 1;
        // 
        // LblCompDate
        // 
        LblCompDate.AutoSize = true;
        LblCompDate.Location = new Point(366, 32);
        LblCompDate.Name = "LblCompDate";
        LblCompDate.Size = new Size(18, 17);
        LblCompDate.TabIndex = 2;
        LblCompDate.Text = "le";
        // 
        // TxtCompDate
        // 
        TxtCompDate.Location = new Point(395, 25);
        TxtCompDate.Name = "TxtCompDate";
        TxtCompDate.PlaceholderText = "jj/mm/aaaa";
        TxtCompDate.Size = new Size(120, 24);
        TxtCompDate.TabIndex = 3;
        // 
        // LblCompHeure
        // 
        LblCompHeure.AutoSize = true;
        LblCompHeure.Location = new Point(534, 32);
        LblCompHeure.Name = "LblCompHeure";
        LblCompHeure.Size = new Size(15, 17);
        LblCompHeure.TabIndex = 4;
        LblCompHeure.Text = "à";
        // 
        // TxtCompHeure
        // 
        TxtCompHeure.Location = new Point(558, 25);
        TxtCompHeure.Name = "TxtCompHeure";
        TxtCompHeure.PlaceholderText = "hh:mm";
        TxtCompHeure.Size = new Size(80, 24);
        TxtCompHeure.TabIndex = 5;
        // 
        // LblCompAdresse
        // 
        LblCompAdresse.AutoSize = true;
        LblCompAdresse.Location = new Point(8, 62);
        LblCompAdresse.Name = "LblCompAdresse";
        LblCompAdresse.Size = new Size(92, 17);
        LblCompAdresse.TabIndex = 6;
        LblCompAdresse.Text = "Adresse salle :";
        // 
        // TxtCompAdresse
        // 
        TxtCompAdresse.Location = new Point(110, 59);
        TxtCompAdresse.Name = "TxtCompAdresse";
        TxtCompAdresse.PlaceholderText = "Adresse complète…";
        TxtCompAdresse.Size = new Size(248, 24);
        TxtCompAdresse.TabIndex = 7;
        // 
        // LblCompResponsable
        // 
        LblCompResponsable.AutoSize = true;
        LblCompResponsable.Location = new Point(366, 62);
        LblCompResponsable.Name = "LblCompResponsable";
        LblCompResponsable.Size = new Size(90, 17);
        LblCompResponsable.TabIndex = 8;
        LblCompResponsable.Text = "Responsable :";
        // 
        // TxtCompResponsable
        // 
        TxtCompResponsable.Location = new Point(455, 59);
        TxtCompResponsable.Name = "TxtCompResponsable";
        TxtCompResponsable.PlaceholderText = "Nom du responsable…";
        TxtCompResponsable.Size = new Size(185, 24);
        TxtCompResponsable.TabIndex = 9;
        // 
        // GrpIndem
        // 
        GrpIndem.Controls.Add(TblFinancier);
        GrpIndem.Location = new Point(12, 220);
        GrpIndem.Name = "GrpIndem";
        GrpIndem.Size = new Size(660, 108);
        GrpIndem.TabIndex = 1;
        GrpIndem.TabStop = false;
        GrpIndem.Text = "Indemnités";
        // 
        // TblFinancier
        // 
        TblFinancier.BackColor = Color.FromArgb(90, 90, 90);
        TblFinancier.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        TblFinancier.ColumnCount = 4;
        TblFinancier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        TblFinancier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        TblFinancier.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        TblFinancier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
        TblFinancier.Controls.Add(LblHdrIndemFix, 0, 0);
        TblFinancier.Controls.Add(LblHdrPeages, 1, 0);
        TblFinancier.Controls.Add(LblHdrDepl, 2, 0);
        TblFinancier.Controls.Add(LblHdrTotal, 3, 0);
        TblFinancier.Controls.Add(LblIndemFixeVal, 0, 1);
        TblFinancier.Controls.Add(PnlPeage, 1, 1);
        TblFinancier.Controls.Add(PnlDep, 2, 1);
        TblFinancier.Controls.Add(LblTotal, 3, 1);
        TblFinancier.Location = new Point(8, 23);
        TblFinancier.Name = "TblFinancier";
        TblFinancier.RowCount = 2;
        TblFinancier.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        TblFinancier.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        TblFinancier.Size = new Size(630, 76);
        TblFinancier.TabIndex = 0;
        // 
        // LblHdrIndemFix
        // 
        LblHdrIndemFix.BackColor = Color.FromArgb(215, 215, 215);
        LblHdrIndemFix.Dock = DockStyle.Fill;
        LblHdrIndemFix.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        LblHdrIndemFix.Location = new Point(4, 1);
        LblHdrIndemFix.Name = "LblHdrIndemFix";
        LblHdrIndemFix.Size = new Size(124, 28);
        LblHdrIndemFix.TabIndex = 0;
        LblHdrIndemFix.Text = "INDEMNITE FIXE";
        LblHdrIndemFix.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LblHdrPeages
        // 
        LblHdrPeages.BackColor = Color.FromArgb(215, 215, 215);
        LblHdrPeages.Dock = DockStyle.Fill;
        LblHdrPeages.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        LblHdrPeages.Location = new Point(135, 1);
        LblHdrPeages.Name = "LblHdrPeages";
        LblHdrPeages.Size = new Size(124, 28);
        LblHdrPeages.TabIndex = 1;
        LblHdrPeages.Text = "PEAGES";
        LblHdrPeages.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LblHdrDepl
        // 
        LblHdrDepl.BackColor = Color.FromArgb(215, 215, 215);
        LblHdrDepl.Dock = DockStyle.Fill;
        LblHdrDepl.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        LblHdrDepl.Location = new Point(266, 1);
        LblHdrDepl.Name = "LblHdrDepl";
        LblHdrDepl.Size = new Size(241, 28);
        LblHdrDepl.TabIndex = 2;
        LblHdrDepl.Text = "DEPLACEMENT";
        LblHdrDepl.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LblHdrTotal
        // 
        LblHdrTotal.BackColor = Color.FromArgb(215, 215, 215);
        LblHdrTotal.Dock = DockStyle.Fill;
        LblHdrTotal.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        LblHdrTotal.Location = new Point(514, 1);
        LblHdrTotal.Name = "LblHdrTotal";
        LblHdrTotal.Size = new Size(112, 28);
        LblHdrTotal.TabIndex = 3;
        LblHdrTotal.Text = "TOTAL";
        LblHdrTotal.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LblIndemFixeVal
        // 
        LblIndemFixeVal.BackColor = Color.White;
        LblIndemFixeVal.Dock = DockStyle.Fill;
        LblIndemFixeVal.Font = new Font("Segoe UI", 9.5F);
        LblIndemFixeVal.Location = new Point(4, 30);
        LblIndemFixeVal.Name = "LblIndemFixeVal";
        LblIndemFixeVal.Size = new Size(124, 46);
        LblIndemFixeVal.TabIndex = 4;
        LblIndemFixeVal.Text = "25,00 €";
        LblIndemFixeVal.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PnlPeage
        // 
        PnlPeage.BackColor = Color.White;
        PnlPeage.Controls.Add(NudPeage);
        PnlPeage.Controls.Add(LblEuroPeage);
        PnlPeage.Dock = DockStyle.Fill;
        PnlPeage.Location = new Point(135, 33);
        PnlPeage.Name = "PnlPeage";
        PnlPeage.Size = new Size(124, 40);
        PnlPeage.TabIndex = 5;
        // 
        // NudPeage
        // 
        NudPeage.DecimalPlaces = 2;
        NudPeage.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        NudPeage.Location = new Point(8, 11);
        NudPeage.Maximum = new decimal(new int[] { 999999, 0, 0, 131072 });
        NudPeage.Name = "NudPeage";
        NudPeage.Size = new Size(82, 24);
        NudPeage.TabIndex = 0;
        NudPeage.ValueChanged += NudPeage_ValueChanged;
        // 
        // LblEuroPeage
        // 
        LblEuroPeage.AutoSize = true;
        LblEuroPeage.Location = new Point(95, 14);
        LblEuroPeage.Name = "LblEuroPeage";
        LblEuroPeage.Size = new Size(15, 17);
        LblEuroPeage.TabIndex = 1;
        LblEuroPeage.Text = "€";
        // 
        // PnlDep
        // 
        PnlDep.BackColor = Color.White;
        PnlDep.Controls.Add(NudKm);
        PnlDep.Controls.Add(LblKmTaux);
        PnlDep.Dock = DockStyle.Fill;
        PnlDep.Location = new Point(266, 33);
        PnlDep.Name = "PnlDep";
        PnlDep.Size = new Size(241, 40);
        PnlDep.TabIndex = 6;
        // 
        // NudKm
        // 
        NudKm.Location = new Point(8, 11);
        NudKm.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        NudKm.Name = "NudKm";
        NudKm.Size = new Size(68, 24);
        NudKm.TabIndex = 0;
        NudKm.ValueChanged += NudKm_ValueChanged;
        // 
        // LblKmTaux
        // 
        LblKmTaux.AutoSize = true;
        LblKmTaux.Font = new Font("Segoe UI", 9F);
        LblKmTaux.Location = new Point(81, 14);
        LblKmTaux.Name = "LblKmTaux";
        LblKmTaux.Size = new Size(79, 15);
        LblKmTaux.TabIndex = 1;
        LblKmTaux.Text = "kms  ×  0,30 €";
        // 
        // LblTotal
        // 
        LblTotal.BackColor = Color.White;
        LblTotal.Dock = DockStyle.Fill;
        LblTotal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        LblTotal.ForeColor = Color.FromArgb(13, 71, 161);
        LblTotal.Location = new Point(514, 30);
        LblTotal.Name = "LblTotal";
        LblTotal.Size = new Size(112, 46);
        LblTotal.TabIndex = 7;
        LblTotal.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // GrpRap
        // 
        GrpRap.Controls.Add(TblRapport);
        GrpRap.Location = new Point(12, 338);
        GrpRap.Name = "GrpRap";
        GrpRap.Size = new Size(660, 172);
        GrpRap.TabIndex = 2;
        GrpRap.TabStop = false;
        GrpRap.Text = "Rapport de Juge Arbitre";
        // 
        // TblRapport
        // 
        TblRapport.BackColor = Color.FromArgb(90, 90, 90);
        TblRapport.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        TblRapport.ColumnCount = 2;
        TblRapport.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 162F));
        TblRapport.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        TblRapport.Controls.Add(LblRapHdr0, 0, 0);
        TblRapport.Controls.Add(LblRapHdr1, 1, 0);
        TblRapport.Controls.Add(LblRapLbl1, 0, 1);
        TblRapport.Controls.Add(PnlRapAccueil, 1, 1);
        TblRapport.Controls.Add(LblRapLbl2, 0, 2);
        TblRapport.Controls.Add(PnlRapEquip, 1, 2);
        TblRapport.Location = new Point(8, 23);
        TblRapport.Name = "TblRapport";
        TblRapport.RowCount = 3;
        TblRapport.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        TblRapport.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        TblRapport.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        TblRapport.Size = new Size(630, 138);
        TblRapport.TabIndex = 0;
        // 
        // LblRapHdr0
        // 
        LblRapHdr0.BackColor = Color.FromArgb(200, 218, 255);
        LblRapHdr0.Dock = DockStyle.Fill;
        LblRapHdr0.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        LblRapHdr0.Location = new Point(4, 1);
        LblRapHdr0.Name = "LblRapHdr0";
        LblRapHdr0.Padding = new Padding(4, 0, 4, 0);
        LblRapHdr0.Size = new Size(156, 30);
        LblRapHdr0.TabIndex = 0;
        LblRapHdr0.Text = "Rapport du Juge Arbitre";
        LblRapHdr0.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LblRapHdr1
        // 
        LblRapHdr1.BackColor = Color.FromArgb(225, 232, 255);
        LblRapHdr1.Dock = DockStyle.Fill;
        LblRapHdr1.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        LblRapHdr1.Location = new Point(167, 1);
        LblRapHdr1.Name = "LblRapHdr1";
        LblRapHdr1.Padding = new Padding(4, 0, 4, 0);
        LblRapHdr1.Size = new Size(459, 30);
        LblRapHdr1.TabIndex = 1;
        LblRapHdr1.Text = "remplir si vous rencontrez des problèmes";
        LblRapHdr1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LblRapLbl1
        // 
        LblRapLbl1.BackColor = Color.FromArgb(225, 235, 255);
        LblRapLbl1.Dock = DockStyle.Fill;
        LblRapLbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblRapLbl1.ForeColor = Color.FromArgb(25, 65, 145);
        LblRapLbl1.Location = new Point(4, 32);
        LblRapLbl1.Name = "LblRapLbl1";
        LblRapLbl1.Padding = new Padding(6, 0, 0, 0);
        LblRapLbl1.Size = new Size(156, 52);
        LblRapLbl1.TabIndex = 2;
        LblRapLbl1.Text = "Accueil, ambiance";
        LblRapLbl1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // PnlRapAccueil
        // 
        PnlRapAccueil.BackColor = Color.White;
        PnlRapAccueil.Controls.Add(TxtRapAccueil);
        PnlRapAccueil.Dock = DockStyle.Fill;
        PnlRapAccueil.Location = new Point(167, 35);
        PnlRapAccueil.Name = "PnlRapAccueil";
        PnlRapAccueil.Padding = new Padding(3);
        PnlRapAccueil.Size = new Size(459, 46);
        PnlRapAccueil.TabIndex = 3;
        // 
        // TxtRapAccueil
        // 
        TxtRapAccueil.BackColor = Color.White;
        TxtRapAccueil.BorderStyle = BorderStyle.None;
        TxtRapAccueil.Dock = DockStyle.Fill;
        TxtRapAccueil.Font = new Font("Segoe UI", 9F);
        TxtRapAccueil.Location = new Point(3, 3);
        TxtRapAccueil.Multiline = true;
        TxtRapAccueil.Name = "TxtRapAccueil";
        TxtRapAccueil.Size = new Size(453, 40);
        TxtRapAccueil.TabIndex = 0;
        // 
        // LblRapLbl2
        // 
        LblRapLbl2.BackColor = Color.FromArgb(225, 235, 255);
        LblRapLbl2.Dock = DockStyle.Fill;
        LblRapLbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblRapLbl2.ForeColor = Color.FromArgb(25, 65, 145);
        LblRapLbl2.Location = new Point(4, 85);
        LblRapLbl2.Name = "LblRapLbl2";
        LblRapLbl2.Padding = new Padding(6, 0, 0, 0);
        LblRapLbl2.Size = new Size(156, 52);
        LblRapLbl2.TabIndex = 4;
        LblRapLbl2.Text = "Équipements, salle, …";
        LblRapLbl2.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // PnlRapEquip
        // 
        PnlRapEquip.BackColor = Color.White;
        PnlRapEquip.Controls.Add(TxtRapEquip);
        PnlRapEquip.Dock = DockStyle.Fill;
        PnlRapEquip.Location = new Point(167, 88);
        PnlRapEquip.Name = "PnlRapEquip";
        PnlRapEquip.Padding = new Padding(3);
        PnlRapEquip.Size = new Size(459, 46);
        PnlRapEquip.TabIndex = 5;
        // 
        // TxtRapEquip
        // 
        TxtRapEquip.BackColor = Color.White;
        TxtRapEquip.BorderStyle = BorderStyle.None;
        TxtRapEquip.Dock = DockStyle.Fill;
        TxtRapEquip.Font = new Font("Segoe UI", 9F);
        TxtRapEquip.Location = new Point(3, 3);
        TxtRapEquip.Multiline = true;
        TxtRapEquip.Name = "TxtRapEquip";
        TxtRapEquip.Size = new Size(453, 40);
        TxtRapEquip.TabIndex = 0;
        // 
        // GrpSig
        // 
        GrpSig.Controls.Add(PicSig);
        GrpSig.Controls.Add(LblSigHint);
        GrpSig.Controls.Add(BtnImport);
        GrpSig.Controls.Add(BtnClear);
        GrpSig.Controls.Add(LblSigFmt);
        GrpSig.Location = new Point(12, 520);
        GrpSig.Name = "GrpSig";
        GrpSig.Size = new Size(415, 118);
        GrpSig.TabIndex = 3;
        GrpSig.TabStop = false;
        GrpSig.Text = "Signature";
        // 
        // PicSig
        // 
        PicSig.BackColor = Color.White;
        PicSig.BorderStyle = BorderStyle.FixedSingle;
        PicSig.Location = new Point(8, 24);
        PicSig.Name = "PicSig";
        PicSig.Size = new Size(220, 64);
        PicSig.SizeMode = PictureBoxSizeMode.Zoom;
        PicSig.TabIndex = 0;
        PicSig.TabStop = false;
        // 
        // LblSigHint
        // 
        LblSigHint.AutoSize = true;
        LblSigHint.ForeColor = Color.Silver;
        LblSigHint.Location = new Point(12, 48);
        LblSigHint.Name = "LblSigHint";
        LblSigHint.Size = new Size(154, 17);
        LblSigHint.TabIndex = 1;
        LblSigHint.Text = "(aucune image importée)";
        // 
        // BtnImport
        // 
        BtnImport.Cursor = Cursors.Hand;
        BtnImport.FlatStyle = FlatStyle.Flat;
        BtnImport.Location = new Point(244, 24);
        BtnImport.Name = "BtnImport";
        BtnImport.Size = new Size(148, 30);
        BtnImport.TabIndex = 2;
        BtnImport.Text = "&Importer image…";
        BtnImport.Click += BtnImport_Click;
        // 
        // BtnClear
        // 
        BtnClear.Cursor = Cursors.Hand;
        BtnClear.FlatStyle = FlatStyle.Flat;
        BtnClear.ForeColor = Color.DarkRed;
        BtnClear.Location = new Point(244, 62);
        BtnClear.Name = "BtnClear";
        BtnClear.Size = new Size(80, 26);
        BtnClear.TabIndex = 3;
        BtnClear.Text = "Effacer";
        BtnClear.Click += BtnClear_Click;
        // 
        // LblSigFmt
        // 
        LblSigFmt.AutoSize = true;
        LblSigFmt.Font = new Font("Segoe UI", 7.5F);
        LblSigFmt.ForeColor = Color.Gray;
        LblSigFmt.Location = new Point(8, 96);
        LblSigFmt.Name = "LblSigFmt";
        LblSigFmt.Size = new Size(136, 12);
        LblSigFmt.TabIndex = 4;
        LblSigFmt.Text = "Formats : PNG, JPG, BMP, GIF";
        // 
        // BtnGen
        // 
        BtnGen.BackColor = Color.FromArgb(21, 101, 192);
        BtnGen.Cursor = Cursors.Hand;
        BtnGen.FlatAppearance.BorderSize = 0;
        BtnGen.FlatStyle = FlatStyle.Flat;
        BtnGen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        BtnGen.ForeColor = Color.White;
        BtnGen.Location = new Point(462, 594);
        BtnGen.Name = "BtnGen";
        BtnGen.Size = new Size(210, 44);
        BtnGen.TabIndex = 4;
        BtnGen.Text = "▶ &Générer le PDF complété";
        BtnGen.UseVisualStyleBackColor = false;
        BtnGen.Click += BtnGen_Click;
        // 
        // BtnReset
        // 
        BtnReset.Cursor = Cursors.Hand;
        BtnReset.FlatStyle = FlatStyle.Flat;
        BtnReset.ForeColor = Color.DarkRed;
        BtnReset.Location = new Point(462, 530);
        BtnReset.Name = "BtnReset";
        BtnReset.Size = new Size(210, 44);
        BtnReset.TabIndex = 11;
        BtnReset.Text = "🗑 &Effacer";
        BtnReset.Click += BtnReset_Click;
        // 
        // BtnPos
        // 
        BtnPos.Cursor = Cursors.Hand;
        BtnPos.FlatStyle = FlatStyle.Flat;
        BtnPos.Location = new Point(96, 657);
        BtnPos.Name = "BtnPos";
        BtnPos.Size = new Size(221, 44);
        BtnPos.TabIndex = 5;
        BtnPos.Text = "Positions P&DF…";
        BtnPos.Click += BtnPos_Click;
        // 
        // BtnOpen
        // 
        BtnOpen.Cursor = Cursors.Hand;
        BtnOpen.FlatStyle = FlatStyle.Flat;
        BtnOpen.Location = new Point(378, 657);
        BtnOpen.Name = "BtnOpen";
        BtnOpen.Size = new Size(221, 44);
        BtnOpen.TabIndex = 6;
        BtnOpen.Text = "📂  &Ouvrir PDF généré";
        BtnOpen.Click += BtnOpen_Click;
        // 
        // PnlStatus
        // 
        PnlStatus.BackColor = Color.FromArgb(224, 231, 246);
        PnlStatus.Controls.Add(LblStatus);
        PnlStatus.Dock = DockStyle.Bottom;
        PnlStatus.Location = new Point(0, 707);
        PnlStatus.Name = "PnlStatus";
        PnlStatus.Size = new Size(697, 28);
        PnlStatus.TabIndex = 7;
        // 
        // LblStatus
        // 
        LblStatus.AutoSize = true;
        LblStatus.ForeColor = Color.FromArgb(40, 60, 120);
        LblStatus.Location = new Point(10, 7);
        LblStatus.Name = "LblStatus";
        LblStatus.Size = new Size(34, 17);
        LblStatus.TabIndex = 0;
        LblStatus.Text = "Prêt.";
        // 
        // Form1
        // 
        BackColor = Color.FromArgb(244, 246, 251);
        ClientSize = new Size(697, 735);
        Controls.Add(GrpPdf);
        Controls.Add(GrpComp);
        Controls.Add(GrpIndem);
        Controls.Add(GrpRap);
        Controls.Add(GrpSig);
        Controls.Add(BtnGen);
        Controls.Add(BtnReset);
        Controls.Add(BtnParams);
        Controls.Add(BtnPos);
        Controls.Add(BtnOpen);
        Controls.Add(PnlStatus);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Convocation JA — Compléter le PDF";
        GrpPdf.ResumeLayout(false);
        GrpPdf.PerformLayout();
        GrpComp.ResumeLayout(false);
        GrpComp.PerformLayout();
        GrpIndem.ResumeLayout(false);
        TblFinancier.ResumeLayout(false);
        PnlPeage.ResumeLayout(false);
        PnlPeage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NudPeage).EndInit();
        PnlDep.ResumeLayout(false);
        PnlDep.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NudKm).EndInit();
        GrpRap.ResumeLayout(false);
        TblRapport.ResumeLayout(false);
        PnlRapAccueil.ResumeLayout(false);
        PnlRapAccueil.PerformLayout();
        PnlRapEquip.ResumeLayout(false);
        PnlRapEquip.PerformLayout();
        GrpSig.ResumeLayout(false);
        GrpSig.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PicSig).EndInit();
        PnlStatus.ResumeLayout(false);
        PnlStatus.PerformLayout();
        ResumeLayout(false);
    }

    // ── Déclarations des champs ───────────────────────────────────────────────
    private GroupBox          GrpPdf;
    private Label             LblSourceLabel;
    private TextBox           TxtSource;
    private Button            BtnSource;
    private Label             LblOutputLabel;
    private TextBox           TxtOutput;
    private Button            BtnOutput;

    private GroupBox          GrpComp;
    private Label             LblCompOpposant;
    private TextBox           TxtCompOpposant;
    private Label             LblCompDate;
    private TextBox           TxtCompDate;
    private Label             LblCompHeure;
    private TextBox           TxtCompHeure;
    private Label             LblCompAdresse;
    private TextBox           TxtCompAdresse;
    private Label             LblCompResponsable;
    private TextBox           TxtCompResponsable;

    private GroupBox          GrpIndem;
    private TableLayoutPanel  TblFinancier;
    private Label             LblHdrIndemFix;
    private Label             LblHdrPeages;
    private Label             LblHdrDepl;
    private Label             LblHdrTotal;
    private Label             LblIndemFixeVal;
    private Panel             PnlPeage;
    private NumericUpDown     NudPeage;
    private Label             LblEuroPeage;
    private Panel             PnlDep;
    private NumericUpDown     NudKm;
    private Label             LblKmTaux;
    private Label             LblTotal;

    private GroupBox         GrpRap;
    private TableLayoutPanel TblRapport;
    private Label            LblRapHdr0;
    private Label            LblRapHdr1;
    private Label            LblRapLbl1;
    private Panel            PnlRapAccueil;
    private TextBox          TxtRapAccueil;
    private Label            LblRapLbl2;
    private Panel            PnlRapEquip;
    private TextBox          TxtRapEquip;

    private GroupBox   GrpSig;
    private PictureBox PicSig;
    private Label      LblSigHint;
    private Button     BtnImport;
    private Button     BtnClear;
    private Label      LblSigFmt;

    private Button BtnGen;
    private Button BtnReset;
    private Button BtnParams;
    private Button BtnPos;
    private Button BtnOpen;

    private Panel PnlStatus;
    private Label LblStatus;
}
