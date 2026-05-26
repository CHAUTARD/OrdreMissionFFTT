namespace OrdreMission;

partial class Form1
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        MenuPrincipal = new MenuStrip();
        MnuFichier = new ToolStripMenuItem();
        MnuFichierQuitter = new ToolStripMenuItem();
        MnuOutils = new ToolStripMenuItem();
        MnuOutilsParams = new ToolStripMenuItem();
        MnuOutilsPositions = new ToolStripMenuItem();
        MnuOutilsSep1 = new ToolStripSeparator();
        MnuOutilsEmail = new ToolStripMenuItem();
        MnuOutilsRecherche = new ToolStripMenuItem();
        MnuOutilsSep2 = new ToolStripSeparator();
        MnuOutilsSignature = new ToolStripMenuItem();
        MnuAide = new ToolStripMenuItem();
        MnuAideAPropos = new ToolStripMenuItem();
        GrpPdf = new GroupBox();
        LblSourceLabel = new Label();
        TxtSource = new TextBox();
        BtnSource = new Button();
        LblOutputLabel = new Label();
        TxtOutput = new TextBox();
        BtnOutput = new Button();
        GrpComp = new GroupBox();
        LblCompOpposant = new Label();
        TxtCompOpposant = new TextBox();
        LblCompDate = new Label();
        TxtCompDate = new TextBox();
        LblCompHeure = new Label();
        TxtCompHeure = new TextBox();
        LblCompAdresse = new Label();
        TxtCompAdresse = new TextBox();
        BtnRechercheFftt = new Button();
        LblItineraire = new Label();
        BtnItineraire = new Button();
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
        LblDureeTrajet = new Label();
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
        BtnGen = new Button();
        BtnReset = new Button();
        BtnOpen = new Button();
        BtnEnvoyerOM = new Button();
        StatusPrincipal = new StatusStrip();
        LblStatus = new ToolStripStatusLabel();
        MenuPrincipal.SuspendLayout();
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
        StatusPrincipal.SuspendLayout();
        SuspendLayout();
        // 
        // MenuPrincipal
        // 
        MenuPrincipal.Items.AddRange(new ToolStripItem[] { MnuFichier, MnuOutils, MnuAide });
        MenuPrincipal.Location = new Point(0, 0);
        MenuPrincipal.Name = "MenuPrincipal";
        MenuPrincipal.Size = new Size(697, 24);
        MenuPrincipal.TabIndex = 99;
        MenuPrincipal.Text = "MenuPrincipal";
        // 
        // MnuFichier
        // 
        MnuFichier.DropDownItems.AddRange(new ToolStripItem[] { MnuFichierQuitter });
        MnuFichier.Name = "MnuFichier";
        MnuFichier.Size = new Size(54, 20);
        MnuFichier.Text = "&Fichier";
        // 
        // MnuFichierQuitter
        // 
        MnuFichierQuitter.Name = "MnuFichierQuitter";
        MnuFichierQuitter.ShortcutKeys = Keys.Alt | Keys.F4;
        MnuFichierQuitter.Size = new Size(153, 22);
        MnuFichierQuitter.Text = "&Quitter";
        MnuFichierQuitter.Click += MnuFichierQuitter_Click;
        // 
        // MnuOutils
        // 
        MnuOutils.DropDownItems.AddRange(new ToolStripItem[] { MnuOutilsParams, MnuOutilsPositions, MnuOutilsSep1, MnuOutilsEmail, MnuOutilsRecherche, MnuOutilsSep2, MnuOutilsSignature });
        MnuOutils.Name = "MnuOutils";
        MnuOutils.Size = new Size(50, 20);
        MnuOutils.Text = "&Outils";
        // 
        // MnuOutilsParams
        // 
        MnuOutilsParams.Image = Properties.Resources.parametre;
        MnuOutilsParams.Name = "MnuOutilsParams";
        MnuOutilsParams.Size = new Size(195, 22);
        MnuOutilsParams.Text = "&Paramètres…";
        MnuOutilsParams.Click += MnuOutilsParams_Click;
        // 
        // MnuOutilsPositions
        // 
        MnuOutilsPositions.Image = Properties.Resources.location;
        MnuOutilsPositions.Name = "MnuOutilsPositions";
        MnuOutilsPositions.Size = new Size(195, 22);
        MnuOutilsPositions.Text = "Positions dans le &PDF…";
        MnuOutilsPositions.Click += MnuOutilsPositions_Click;
        // 
        // MnuOutilsSep1
        // 
        MnuOutilsSep1.Name = "MnuOutilsSep1";
        MnuOutilsSep1.Size = new Size(192, 6);
        // 
        // MnuOutilsEmail
        // 
        MnuOutilsEmail.Image = Properties.Resources.email;
        MnuOutilsEmail.Name = "MnuOutilsEmail";
        MnuOutilsEmail.Size = new Size(195, 22);
        MnuOutilsEmail.Text = "Modèle d'&email…";
        MnuOutilsEmail.Click += MnuOutilsEmail_Click;
        // 
        // MnuOutilsRecherche
        // 
        MnuOutilsRecherche.Image = Properties.Resources.loupe;
        MnuOutilsRecherche.Name = "MnuOutilsRecherche";
        MnuOutilsRecherche.Size = new Size(195, 22);
        MnuOutilsRecherche.Text = "&Recherche club FFTT…";
        MnuOutilsRecherche.Click += MnuOutilsRecherche_Click;
        // 
        // MnuOutilsSep2
        // 
        MnuOutilsSep2.Name = "MnuOutilsSep2";
        MnuOutilsSep2.Size = new Size(192, 6);
        // 
        // MnuOutilsSignature
        // 
        MnuOutilsSignature.Image = Properties.Resources.sign;
        MnuOutilsSignature.Name = "MnuOutilsSignature";
        MnuOutilsSignature.Size = new Size(195, 22);
        MnuOutilsSignature.Text = " &Signature…";
        MnuOutilsSignature.Click += MnuOutilsSignature_Click;
        // 
        // MnuAide
        // 
        MnuAide.Alignment = ToolStripItemAlignment.Right;
        MnuAide.DropDownItems.AddRange(new ToolStripItem[] { MnuAideAPropos });
        MnuAide.Name = "MnuAide";
        MnuAide.Size = new Size(24, 20);
        MnuAide.Text = "&?";
        // 
        // MnuAideAPropos
        // 
        MnuAideAPropos.Name = "MnuAideAPropos";
        MnuAideAPropos.Size = new Size(122, 22);
        MnuAideAPropos.Text = "À &propos";
        MnuAideAPropos.Click += MnuAideAPropos_Click;
        // 
        // GrpPdf
        // 
        GrpPdf.Controls.Add(LblSourceLabel);
        GrpPdf.Controls.Add(TxtSource);
        GrpPdf.Controls.Add(BtnSource);
        GrpPdf.Controls.Add(LblOutputLabel);
        GrpPdf.Controls.Add(TxtOutput);
        GrpPdf.Controls.Add(BtnOutput);
        GrpPdf.Location = new Point(12, 34);
        GrpPdf.Name = "GrpPdf";
        GrpPdf.Size = new Size(660, 90);
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
        TxtSource.Size = new Size(456, 24);
        TxtSource.TabIndex = 1;
        // 
        // BtnSource
        // 
        BtnSource.Cursor = Cursors.Hand;
        BtnSource.FlatStyle = FlatStyle.Flat;
        BtnSource.Location = new Point(545, 22);
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
        TxtOutput.Size = new Size(456, 24);
        TxtOutput.TabIndex = 4;
        // 
        // BtnOutput
        // 
        BtnOutput.Cursor = Cursors.Hand;
        BtnOutput.FlatStyle = FlatStyle.Flat;
        BtnOutput.Location = new Point(545, 54);
        BtnOutput.Name = "BtnOutput";
        BtnOutput.Size = new Size(100, 26);
        BtnOutput.TabIndex = 5;
        BtnOutput.Text = "Parcourir…";
        BtnOutput.Click += BtnOutput_Click;
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
        GrpComp.Controls.Add(BtnRechercheFftt);
        GrpComp.Controls.Add(LblItineraire);
        GrpComp.Controls.Add(BtnItineraire);
        GrpComp.Location = new Point(12, 134);
        GrpComp.Name = "GrpComp";
        GrpComp.Size = new Size(660, 120);
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
        TxtCompDate.Location = new Point(390, 25);
        TxtCompDate.Name = "TxtCompDate";
        TxtCompDate.PlaceholderText = "jj/mm/aaaa";
        TxtCompDate.Size = new Size(164, 24);
        TxtCompDate.TabIndex = 3;
        // 
        // LblCompHeure
        // 
        LblCompHeure.AutoSize = true;
        LblCompHeure.Location = new Point(560, 28);
        LblCompHeure.Name = "LblCompHeure";
        LblCompHeure.Size = new Size(15, 17);
        LblCompHeure.TabIndex = 4;
        LblCompHeure.Text = "à";
        // 
        // TxtCompHeure
        // 
        TxtCompHeure.Location = new Point(581, 25);
        TxtCompHeure.Name = "TxtCompHeure";
        TxtCompHeure.PlaceholderText = "hh:mm";
        TxtCompHeure.Size = new Size(57, 24);
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
        TxtCompAdresse.Size = new Size(360, 24);
        TxtCompAdresse.TabIndex = 7;
        // 
        // BtnRechercheFftt
        // 
        BtnRechercheFftt.Cursor = Cursors.Hand;
        BtnRechercheFftt.FlatStyle = FlatStyle.Flat;
        BtnRechercheFftt.Location = new Point(477, 57);
        BtnRechercheFftt.Name = "BtnRechercheFftt";
        BtnRechercheFftt.Size = new Size(168, 26);
        BtnRechercheFftt.TabIndex = 8;
        BtnRechercheFftt.Text = "🔍 Rechercher FFTT";
        BtnRechercheFftt.Click += BtnRechercheFftt_Click;
        // 
        // LblItineraire
        // 
        LblItineraire.AutoSize = true;
        LblItineraire.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblItineraire.ForeColor = Color.FromArgb(80, 80, 80);
        LblItineraire.Location = new Point(110, 90);
        LblItineraire.Name = "LblItineraire";
        LblItineraire.Size = new Size(38, 15);
        LblItineraire.TabIndex = 9;
        LblItineraire.Text = "🚘  —";
        // 
        // BtnItineraire
        // 
        BtnItineraire.Cursor = Cursors.Hand;
        BtnItineraire.FlatStyle = FlatStyle.Flat;
        BtnItineraire.Location = new Point(477, 87);
        BtnItineraire.Name = "BtnItineraire";
        BtnItineraire.Size = new Size(168, 26);
        BtnItineraire.TabIndex = 10;
        BtnItineraire.Text = "📍 Calculer itinéraire";
        BtnItineraire.Click += BtnItineraire_Click;
        // 
        // GrpIndem
        // 
        GrpIndem.Controls.Add(TblFinancier);
        GrpIndem.Location = new Point(12, 264);
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
        PnlDep.Controls.Add(LblDureeTrajet);
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
        NudKm.Location = new Point(82, 11);
        NudKm.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        NudKm.Name = "NudKm";
        NudKm.Size = new Size(68, 24);
        NudKm.TabIndex = 0;
        NudKm.ValueChanged += NudKm_ValueChanged;

        // LblDureeTrajet
        //
        LblDureeTrajet.AutoSize  = false;
        LblDureeTrajet.Font      = new Font("Segoe UI", 8.5F);
        LblDureeTrajet.ForeColor = Color.FromArgb(60, 60, 60);
        LblDureeTrajet.Location  = new Point(4, 13);
        LblDureeTrajet.Name      = "LblDureeTrajet";
        LblDureeTrajet.Size      = new Size(75, 20);
        LblDureeTrajet.TabIndex  = 10;
        LblDureeTrajet.Text      = "—";
        LblDureeTrajet.TextAlign = ContentAlignment.MiddleRight;
        // 
        // LblKmTaux
        // 
        LblKmTaux.AutoSize = true;
        LblKmTaux.Font = new Font("Segoe UI", 9F);
        LblKmTaux.Location = new Point(158, 14);
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
        GrpRap.Location = new Point(12, 382);
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
        // BtnGen
        // 
        BtnGen.BackColor = Color.FromArgb(21, 101, 192);
        BtnGen.Cursor = Cursors.Hand;
        BtnGen.FlatAppearance.BorderSize = 0;
        BtnGen.FlatStyle = FlatStyle.Flat;
        BtnGen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        BtnGen.ForeColor = Color.White;
        BtnGen.Location = new Point(228, 566);
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
        BtnReset.Location = new Point(12, 566);
        BtnReset.Name = "BtnReset";
        BtnReset.Size = new Size(184, 44);
        BtnReset.TabIndex = 11;
        BtnReset.Text = "🗑 &Effacer";
        BtnReset.Click += BtnReset_Click;
        // 
        // BtnOpen
        // 
        BtnOpen.Cursor = Cursors.Hand;
        BtnOpen.FlatStyle = FlatStyle.Flat;
        BtnOpen.Location = new Point(451, 566);
        BtnOpen.Name = "BtnOpen";
        BtnOpen.Size = new Size(221, 44);
        BtnOpen.TabIndex = 6;
        BtnOpen.Text = "📂  &Ouvrir PDF généré";
        BtnOpen.Click += BtnOpen_Click;
        // 
        // BtnEnvoyerOM
        // 
        BtnEnvoyerOM.Cursor = Cursors.Hand;
        BtnEnvoyerOM.FlatStyle = FlatStyle.Flat;
        BtnEnvoyerOM.Location = new Point(196, 620);
        BtnEnvoyerOM.Name = "BtnEnvoyerOM";
        BtnEnvoyerOM.Size = new Size(305, 40);
        BtnEnvoyerOM.TabIndex = 7;
        BtnEnvoyerOM.Text = "📧  Envoyer l'ordre de mission…";
        BtnEnvoyerOM.Click += BtnEnvoyerOM_Click;
        // 
        // StatusPrincipal
        // 
        StatusPrincipal.BackColor = Color.FromArgb(224, 231, 246);
        StatusPrincipal.Items.AddRange(new ToolStripItem[] { LblStatus });
        StatusPrincipal.Location = new Point(0, 658);
        StatusPrincipal.Name = "StatusPrincipal";
        StatusPrincipal.Size = new Size(697, 22);
        StatusPrincipal.SizingGrip = false;
        StatusPrincipal.TabIndex = 7;
        StatusPrincipal.Text = "StatusPrincipal";
        // 
        // LblStatus
        // 
        LblStatus.ForeColor = Color.FromArgb(40, 60, 120);
        LblStatus.Name = "LblStatus";
        LblStatus.Size = new Size(682, 17);
        LblStatus.Spring = true;
        LblStatus.Text = "Prêt.";
        LblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // Form1
        // 
        BackColor = Color.FromArgb(244, 246, 251);
        ClientSize = new Size(697, 680);
        Controls.Add(GrpPdf);
        Controls.Add(GrpComp);
        Controls.Add(GrpIndem);
        Controls.Add(GrpRap);
        Controls.Add(BtnGen);
        Controls.Add(BtnReset);
        Controls.Add(BtnOpen);
        Controls.Add(BtnEnvoyerOM);
        Controls.Add(StatusPrincipal);
        Controls.Add(MenuPrincipal);
        Font = new Font("Segoe UI", 9.5F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = MenuPrincipal;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Convocation JA — Compléter le PDF";
        MenuPrincipal.ResumeLayout(false);
        MenuPrincipal.PerformLayout();
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
        StatusPrincipal.ResumeLayout(false);
        StatusPrincipal.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    // ── Déclarations des champs ───────────────────────────────────────────────

    private MenuStrip           MenuPrincipal;
    private ToolStripMenuItem   MnuFichier;
    private ToolStripMenuItem   MnuFichierQuitter;
    private ToolStripMenuItem   MnuOutils;
    private ToolStripMenuItem   MnuOutilsParams;
    private ToolStripMenuItem   MnuOutilsPositions;
    private ToolStripSeparator  MnuOutilsSep1;
    private ToolStripMenuItem   MnuOutilsEmail;
    private ToolStripMenuItem   MnuOutilsRecherche;
    private ToolStripSeparator  MnuOutilsSep2;
    private ToolStripMenuItem   MnuOutilsSignature;
    private ToolStripMenuItem   MnuAide;
    private ToolStripMenuItem   MnuAideAPropos;

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
    private Button            BtnRechercheFftt;
    private Label             LblItineraire;
    private Button            BtnItineraire;

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
    private Label             LblDureeTrajet;
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

    private Button BtnGen;
    private Button BtnReset;
    private Button BtnOpen;
    private Button BtnEnvoyerOM;

    private StatusStrip          StatusPrincipal;
    private ToolStripStatusLabel LblStatus;
}
