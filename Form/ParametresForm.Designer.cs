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

        // ── TabControl ────────────────────────────────────────────────────────
        TcParams       = new TabControl();
        TpMontants     = new TabPage();
        TpArbitre      = new TabPage();
        TpNominations  = new TabPage();
        TpItineraire   = new TabPage();
        TpSmtp         = new TabPage();

        // ── Onglet 1 : Montants réglementaires ───────────────────────────────
        Grp          = new GroupBox();
        LblIndemLbl  = new Label();
        NudIndemFixe = new NumericUpDown();
        LblEuroIndem = new Label();
        LblTauxLbl   = new Label();
        NudTauxKm    = new NumericUpDown();
        LblEuroKm    = new Label();

        // ── Onglet 2 : Arbitre et Adresse de départ ──────────────────────────
        LblNomArbitreLbl = new Label();
        TxtNomArbitre    = new TextBox();
        GrpAddr          = new GroupBox();
        LblNumeroLbl     = new Label();
        TxtNumero        = new TextBox();
        LblRueLbl        = new Label();
        TxtRue           = new TextBox();
        LblCpLbl         = new Label();
        TxtCp            = new TextBox();
        LblVilleLbl      = new Label();
        TxtVille         = new TextBox();

        // ── Onglet 3 : Responsable des nominations ────────────────────────────
        GrpNominations       = new GroupBox();
        LblNomNominationsLbl = new Label();
        TxtNomNominations    = new TextBox();
        LblEmailNominationsLbl = new Label();
        TxtEmailNominations  = new TextBox();
        LblTelNominationsLbl = new Label();
        TxtTelNominations    = new TextBox();

        // ── Onglet 4 : OpenRouteService ───────────────────────────────────────
        GrpAzureMaps    = new GroupBox();
        LblAzureMapsLbl = new Label();
        TxtAzureMapsKey = new TextBox();

        // ── Onglet 5 : SMTP ───────────────────────────────────────────────────
        GrpSmtp            = new GroupBox();
        LblSmtpServeurLbl  = new Label();
        TxtSmtpHost        = new TextBox();
        LblSmtpPortLbl     = new Label();
        NudSmtpPort        = new NumericUpDown();
        ChkSmtpSsl         = new CheckBox();
        LblSmtpUserLbl     = new Label();
        TxtSmtpUser        = new TextBox();
        LblSmtpPasswordLbl = new Label();
        TxtSmtpPassword    = new TextBox();
        LblSmtpFromLbl     = new Label();
        TxtSmtpFrom        = new TextBox();

        // ── Boutons Sauvegarder par onglet ───────────────────────────────────
        BtnSauverMontants    = new Button();
        BtnSauverArbitre     = new Button();
        BtnSauverNominations = new Button();
        BtnSauverItineraire  = new Button();
        BtnSauverSmtp        = new Button();

        // ── Boutons globaux ───────────────────────────────────────────────────
        BtnOk     = new Button();
        BtnCancel = new Button();

        // ── SuspendLayout ─────────────────────────────────────────────────────
        TcParams.SuspendLayout();
        TpMontants.SuspendLayout();
        TpArbitre.SuspendLayout();
        TpNominations.SuspendLayout();
        TpItineraire.SuspendLayout();
        TpSmtp.SuspendLayout();
        Grp.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NudIndemFixe).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NudTauxKm).BeginInit();
        GrpAddr.SuspendLayout();
        GrpNominations.SuspendLayout();
        GrpAzureMaps.SuspendLayout();
        GrpSmtp.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NudSmtpPort).BeginInit();
        SuspendLayout();

        // ── TcParams ─────────────────────────────────────────────────────────
        TcParams.Controls.Add(TpMontants);
        TcParams.Controls.Add(TpArbitre);
        TcParams.Controls.Add(TpNominations);
        TcParams.Controls.Add(TpItineraire);
        TcParams.Controls.Add(TpSmtp);
        TcParams.Location      = new Point(12, 12);
        TcParams.Name          = "TcParams";
        TcParams.SelectedIndex = 0;
        TcParams.Size          = new Size(396, 260);
        TcParams.TabIndex      = 0;

        // ── TpMontants ───────────────────────────────────────────────────────
        TpMontants.Controls.Add(Grp);
        TpMontants.Controls.Add(BtnSauverMontants);
        TpMontants.Location           = new Point(4, 24);
        TpMontants.Name               = "TpMontants";
        TpMontants.Padding            = new Padding(3);
        TpMontants.Size               = new Size(388, 212);
        TpMontants.TabIndex           = 0;
        TpMontants.Text               = "Montants";
        TpMontants.UseVisualStyleBackColor = true;

        // ── TpArbitre ────────────────────────────────────────────────────────
        TpArbitre.Controls.Add(LblNomArbitreLbl);
        TpArbitre.Controls.Add(TxtNomArbitre);
        TpArbitre.Controls.Add(GrpAddr);
        TpArbitre.Controls.Add(BtnSauverArbitre);
        TpArbitre.Location            = new Point(4, 24);
        TpArbitre.Name                = "TpArbitre";
        TpArbitre.Padding             = new Padding(3);
        TpArbitre.Size                = new Size(388, 212);
        TpArbitre.TabIndex            = 1;
        TpArbitre.Text                = "Arbitre / Départ";
        TpArbitre.UseVisualStyleBackColor = true;

        // ── TpNominations ────────────────────────────────────────────────────
        TpNominations.Controls.Add(GrpNominations);
        TpNominations.Controls.Add(BtnSauverNominations);
        TpNominations.Location        = new Point(4, 24);
        TpNominations.Name            = "TpNominations";
        TpNominations.Padding         = new Padding(3);
        TpNominations.Size            = new Size(388, 212);
        TpNominations.TabIndex        = 2;
        TpNominations.Text            = "Nominations";
        TpNominations.UseVisualStyleBackColor = true;

        // ── TpItineraire ─────────────────────────────────────────────────────
        TpItineraire.Controls.Add(GrpAzureMaps);
        TpItineraire.Controls.Add(BtnSauverItineraire);
        TpItineraire.Location         = new Point(4, 24);
        TpItineraire.Name             = "TpItineraire";
        TpItineraire.Padding          = new Padding(3);
        TpItineraire.Size             = new Size(388, 212);
        TpItineraire.TabIndex         = 3;
        TpItineraire.Text             = "Itinéraire";
        TpItineraire.UseVisualStyleBackColor = true;

        // ── TpSmtp ───────────────────────────────────────────────────────────
        TpSmtp.Controls.Add(GrpSmtp);
        TpSmtp.Controls.Add(BtnSauverSmtp);
        TpSmtp.Location               = new Point(4, 24);
        TpSmtp.Name                   = "TpSmtp";
        TpSmtp.Padding                = new Padding(3);
        TpSmtp.Size                   = new Size(388, 212);
        TpSmtp.TabIndex               = 4;
        TpSmtp.Text                   = "SMTP";
        TpSmtp.UseVisualStyleBackColor = true;

        // ── Grp (Montants réglementaires) ─────────────────────────────────────
        Grp.Controls.Add(LblIndemLbl);
        Grp.Controls.Add(NudIndemFixe);
        Grp.Controls.Add(LblEuroIndem);
        Grp.Controls.Add(LblTauxLbl);
        Grp.Controls.Add(NudTauxKm);
        Grp.Controls.Add(LblEuroKm);
        Grp.Location = new Point(6, 6);
        Grp.Name     = "Grp";
        Grp.Size     = new Size(376, 106);
        Grp.TabIndex = 0;
        Grp.TabStop  = false;
        Grp.Text     = "Montants réglementaires";

        LblIndemLbl.AutoSize = true;
        LblIndemLbl.Location = new Point(12, 28);
        LblIndemLbl.Name     = "LblIndemLbl";
        LblIndemLbl.TabIndex = 0;
        LblIndemLbl.Text     = "Indemnité fixe :";

        NudIndemFixe.DecimalPlaces = 2;
        NudIndemFixe.Increment     = new decimal(new int[] { 5, 0, 0, 65536 });
        NudIndemFixe.Location      = new Point(188, 24);
        NudIndemFixe.Maximum       = new decimal(new int[] { 9999, 0, 0, 0 });
        NudIndemFixe.Name          = "NudIndemFixe";
        NudIndemFixe.Size          = new Size(80, 23);
        NudIndemFixe.TabIndex      = 1;

        LblEuroIndem.AutoSize = true;
        LblEuroIndem.Location = new Point(273, 28);
        LblEuroIndem.Name     = "LblEuroIndem";
        LblEuroIndem.TabIndex = 2;
        LblEuroIndem.Text     = "€";

        LblTauxLbl.AutoSize = true;
        LblTauxLbl.Location = new Point(12, 70);
        LblTauxLbl.Name     = "LblTauxLbl";
        LblTauxLbl.TabIndex = 3;
        LblTauxLbl.Text     = "Taux kilométrique :";

        NudTauxKm.DecimalPlaces = 2;
        NudTauxKm.Increment     = new decimal(new int[] { 1, 0, 0, 131072 });
        NudTauxKm.Location      = new Point(188, 66);
        NudTauxKm.Maximum       = new decimal(new int[] { 999, 0, 0, 131072 });
        NudTauxKm.Name          = "NudTauxKm";
        NudTauxKm.Size          = new Size(80, 23);
        NudTauxKm.TabIndex      = 4;

        LblEuroKm.AutoSize = true;
        LblEuroKm.Location = new Point(273, 70);
        LblEuroKm.Name     = "LblEuroKm";
        LblEuroKm.TabIndex = 5;
        LblEuroKm.Text     = "€ / km";

        // ── Onglet 2 — Arbitre ────────────────────────────────────────────────
        LblNomArbitreLbl.AutoSize = true;
        LblNomArbitreLbl.Font     = new Font("Segoe UI", 9F, FontStyle.Bold);
        LblNomArbitreLbl.Location = new Point(10, 16);
        LblNomArbitreLbl.Name     = "LblNomArbitreLbl";
        LblNomArbitreLbl.TabIndex = 0;
        LblNomArbitreLbl.Text     = "Arbitre :";

        TxtNomArbitre.Location        = new Point(79, 13);
        TxtNomArbitre.MaxLength       = 80;
        TxtNomArbitre.Name            = "TxtNomArbitre";
        TxtNomArbitre.PlaceholderText = "Prénom NOM";
        TxtNomArbitre.Size            = new Size(295, 23);
        TxtNomArbitre.TabIndex        = 1;

        // ── GrpAddr (Adresse de départ) ───────────────────────────────────────
        GrpAddr.Controls.Add(LblNumeroLbl);
        GrpAddr.Controls.Add(TxtNumero);
        GrpAddr.Controls.Add(LblRueLbl);
        GrpAddr.Controls.Add(TxtRue);
        GrpAddr.Controls.Add(LblCpLbl);
        GrpAddr.Controls.Add(TxtCp);
        GrpAddr.Controls.Add(LblVilleLbl);
        GrpAddr.Controls.Add(TxtVille);
        GrpAddr.Location = new Point(6, 44);
        GrpAddr.Name     = "GrpAddr";
        GrpAddr.Size     = new Size(376, 100);
        GrpAddr.TabIndex = 2;
        GrpAddr.TabStop  = false;
        GrpAddr.Text     = "Adresse de départ";

        LblNumeroLbl.AutoSize = true;
        LblNumeroLbl.Location = new Point(10, 28);
        LblNumeroLbl.Name     = "LblNumeroLbl";
        LblNumeroLbl.TabIndex = 0;
        LblNumeroLbl.Text     = "N° :";

        TxtNumero.Location = new Point(42, 24);
        TxtNumero.Name     = "TxtNumero";
        TxtNumero.Size     = new Size(55, 23);
        TxtNumero.TabIndex = 1;

        LblRueLbl.AutoSize = true;
        LblRueLbl.Location = new Point(108, 28);
        LblRueLbl.Name     = "LblRueLbl";
        LblRueLbl.TabIndex = 2;
        LblRueLbl.Text     = "Rue :";

        TxtRue.Location = new Point(145, 24);
        TxtRue.Name     = "TxtRue";
        TxtRue.Size     = new Size(218, 23);
        TxtRue.TabIndex = 3;

        LblCpLbl.AutoSize = true;
        LblCpLbl.Location = new Point(10, 64);
        LblCpLbl.Name     = "LblCpLbl";
        LblCpLbl.TabIndex = 4;
        LblCpLbl.Text     = "Code postal :";

        TxtCp.Location = new Point(114, 60);
        TxtCp.Name     = "TxtCp";
        TxtCp.Size     = new Size(80, 23);
        TxtCp.TabIndex = 5;

        LblVilleLbl.AutoSize = true;
        LblVilleLbl.Location = new Point(205, 64);
        LblVilleLbl.Name     = "LblVilleLbl";
        LblVilleLbl.TabIndex = 6;
        LblVilleLbl.Text     = "Ville :";

        TxtVille.Location = new Point(244, 60);
        TxtVille.Name     = "TxtVille";
        TxtVille.Size     = new Size(120, 23);
        TxtVille.TabIndex = 7;

        // ── GrpNominations ───────────────────────────────────────────────────
        GrpNominations.Controls.Add(LblNomNominationsLbl);
        GrpNominations.Controls.Add(TxtNomNominations);
        GrpNominations.Controls.Add(LblEmailNominationsLbl);
        GrpNominations.Controls.Add(TxtEmailNominations);
        GrpNominations.Controls.Add(LblTelNominationsLbl);
        GrpNominations.Controls.Add(TxtTelNominations);
        GrpNominations.Location = new Point(6, 6);
        GrpNominations.Name     = "GrpNominations";
        GrpNominations.Size     = new Size(376, 116);
        GrpNominations.TabIndex = 0;
        GrpNominations.TabStop  = false;
        GrpNominations.Text     = "Responsable des nominations";

        LblNomNominationsLbl.AutoSize = true;
        LblNomNominationsLbl.Location = new Point(10, 28);
        LblNomNominationsLbl.Name     = "LblNomNominationsLbl";
        LblNomNominationsLbl.TabIndex = 0;
        LblNomNominationsLbl.Text     = "Nom :";

        TxtNomNominations.Location        = new Point(114, 24);
        TxtNomNominations.Name            = "TxtNomNominations";
        TxtNomNominations.PlaceholderText = "Prénom NOM";
        TxtNomNominations.Size            = new Size(248, 23);
        TxtNomNominations.TabIndex        = 1;

        LblEmailNominationsLbl.AutoSize = true;
        LblEmailNominationsLbl.Location = new Point(10, 60);
        LblEmailNominationsLbl.Name     = "LblEmailNominationsLbl";
        LblEmailNominationsLbl.TabIndex = 2;
        LblEmailNominationsLbl.Text     = "Email :";

        TxtEmailNominations.Location        = new Point(114, 56);
        TxtEmailNominations.Name            = "TxtEmailNominations";
        TxtEmailNominations.PlaceholderText = "responsable@ligue.fftt.fr";
        TxtEmailNominations.Size            = new Size(248, 23);
        TxtEmailNominations.TabIndex        = 3;

        LblTelNominationsLbl.AutoSize = true;
        LblTelNominationsLbl.Location = new Point(10, 92);
        LblTelNominationsLbl.Name     = "LblTelNominationsLbl";
        LblTelNominationsLbl.TabIndex = 4;
        LblTelNominationsLbl.Text     = "Téléphone :";

        TxtTelNominations.Location        = new Point(114, 88);
        TxtTelNominations.Name            = "TxtTelNominations";
        TxtTelNominations.PlaceholderText = "06 00 00 00 00";
        TxtTelNominations.Size            = new Size(160, 23);
        TxtTelNominations.TabIndex        = 5;

        // ── GrpAzureMaps (OpenRouteService) ───────────────────────────────────
        GrpAzureMaps.Controls.Add(LblAzureMapsLbl);
        GrpAzureMaps.Controls.Add(TxtAzureMapsKey);
        GrpAzureMaps.Location = new Point(6, 6);
        GrpAzureMaps.Name     = "GrpAzureMaps";
        GrpAzureMaps.Size     = new Size(376, 55);
        GrpAzureMaps.TabIndex = 0;
        GrpAzureMaps.TabStop  = false;
        GrpAzureMaps.Text     = "OpenRouteService (calcul d'itinéraire)";

        LblAzureMapsLbl.AutoSize = true;
        LblAzureMapsLbl.Location = new Point(10, 24);
        LblAzureMapsLbl.Name     = "LblAzureMapsLbl";
        LblAzureMapsLbl.TabIndex = 0;
        LblAzureMapsLbl.Text     = "Clé API :";

        TxtAzureMapsKey.Location        = new Point(68, 20);
        TxtAzureMapsKey.Name            = "TxtAzureMapsKey";
        TxtAzureMapsKey.PlaceholderText = "Votre clé OpenRouteService…";
        TxtAzureMapsKey.Size            = new Size(294, 23);
        TxtAzureMapsKey.TabIndex        = 1;

        // ── GrpSmtp ───────────────────────────────────────────────────────────
        GrpSmtp.Controls.Add(LblSmtpServeurLbl);
        GrpSmtp.Controls.Add(TxtSmtpHost);
        GrpSmtp.Controls.Add(LblSmtpPortLbl);
        GrpSmtp.Controls.Add(NudSmtpPort);
        GrpSmtp.Controls.Add(ChkSmtpSsl);
        GrpSmtp.Controls.Add(LblSmtpUserLbl);
        GrpSmtp.Controls.Add(TxtSmtpUser);
        GrpSmtp.Controls.Add(LblSmtpPasswordLbl);
        GrpSmtp.Controls.Add(TxtSmtpPassword);
        GrpSmtp.Controls.Add(LblSmtpFromLbl);
        GrpSmtp.Controls.Add(TxtSmtpFrom);
        GrpSmtp.Location = new Point(6, 6);
        GrpSmtp.Name     = "GrpSmtp";
        GrpSmtp.Size     = new Size(376, 170);
        GrpSmtp.TabIndex = 0;
        GrpSmtp.TabStop  = false;
        GrpSmtp.Text     = "SMTP (envoi d'emails)";

        LblSmtpServeurLbl.AutoSize = true;
        LblSmtpServeurLbl.Location = new Point(10, 24);
        LblSmtpServeurLbl.Name     = "LblSmtpServeurLbl";
        LblSmtpServeurLbl.TabIndex = 0;
        LblSmtpServeurLbl.Text     = "Serveur :";

        TxtSmtpHost.Location        = new Point(73, 21);
        TxtSmtpHost.Name            = "TxtSmtpHost";
        TxtSmtpHost.PlaceholderText = "smtp.example.com";
        TxtSmtpHost.Size            = new Size(192, 23);
        TxtSmtpHost.TabIndex        = 1;

        LblSmtpPortLbl.AutoSize = true;
        LblSmtpPortLbl.Location = new Point(273, 24);
        LblSmtpPortLbl.Name     = "LblSmtpPortLbl";
        LblSmtpPortLbl.TabIndex = 2;
        LblSmtpPortLbl.Text     = "Port :";

        NudSmtpPort.Location = new Point(316, 21);
        NudSmtpPort.Maximum  = new decimal(new int[] { 65535, 0, 0, 0 });
        NudSmtpPort.Minimum  = new decimal(new int[] { 1, 0, 0, 0 });
        NudSmtpPort.Name     = "NudSmtpPort";
        NudSmtpPort.Size     = new Size(50, 23);
        NudSmtpPort.TabIndex = 3;
        NudSmtpPort.Value    = new decimal(new int[] { 587, 0, 0, 0 });

        ChkSmtpSsl.AutoSize = true;
        ChkSmtpSsl.Location = new Point(10, 52);
        ChkSmtpSsl.Name     = "ChkSmtpSsl";
        ChkSmtpSsl.TabIndex = 4;
        ChkSmtpSsl.Text     = "SSL/TLS direct (port 465)";

        LblSmtpUserLbl.AutoSize = true;
        LblSmtpUserLbl.Location = new Point(10, 82);
        LblSmtpUserLbl.Name     = "LblSmtpUserLbl";
        LblSmtpUserLbl.TabIndex = 5;
        LblSmtpUserLbl.Text     = "Login :";

        TxtSmtpUser.Location        = new Point(110, 79);
        TxtSmtpUser.Name            = "TxtSmtpUser";
        TxtSmtpUser.PlaceholderText = "utilisateur@example.com";
        TxtSmtpUser.Size            = new Size(254, 23);
        TxtSmtpUser.TabIndex        = 6;

        LblSmtpPasswordLbl.AutoSize = true;
        LblSmtpPasswordLbl.Location = new Point(10, 110);
        LblSmtpPasswordLbl.Name     = "LblSmtpPasswordLbl";
        LblSmtpPasswordLbl.TabIndex = 7;
        LblSmtpPasswordLbl.Text     = "Mot de passe :";

        TxtSmtpPassword.Location     = new Point(110, 107);
        TxtSmtpPassword.Name         = "TxtSmtpPassword";
        TxtSmtpPassword.PasswordChar = '●';
        TxtSmtpPassword.Size         = new Size(254, 23);
        TxtSmtpPassword.TabIndex     = 8;

        LblSmtpFromLbl.AutoSize = true;
        LblSmtpFromLbl.Location = new Point(10, 140);
        LblSmtpFromLbl.Name     = "LblSmtpFromLbl";
        LblSmtpFromLbl.TabIndex = 9;
        LblSmtpFromLbl.Text     = "Expéditeur :";

        TxtSmtpFrom.Location        = new Point(110, 137);
        TxtSmtpFrom.Name            = "TxtSmtpFrom";
        TxtSmtpFrom.PlaceholderText = "votre@adresse.fr  (vide = Login)";
        TxtSmtpFrom.Size            = new Size(254, 23);
        TxtSmtpFrom.TabIndex        = 10;

        // ── Boutons Sauvegarder par onglet (position commune : y=188, droite) ─
        InitBtnSauver(BtnSauverMontants,    "BtnSauverMontants",    0);
        BtnSauverMontants.Click    += BtnSauverMontants_Click;
        InitBtnSauver(BtnSauverArbitre,     "BtnSauverArbitre",     1);
        BtnSauverArbitre.Click     += BtnSauverArbitre_Click;
        InitBtnSauver(BtnSauverNominations, "BtnSauverNominations", 2);
        BtnSauverNominations.Click += BtnSauverNominations_Click;
        InitBtnSauver(BtnSauverItineraire,  "BtnSauverItineraire",  3);
        BtnSauverItineraire.Click  += BtnSauverItineraire_Click;
        InitBtnSauver(BtnSauverSmtp,        "BtnSauverSmtp",        4);
        BtnSauverSmtp.Click        += BtnSauverSmtp_Click;

        // ── Boutons globaux ───────────────────────────────────────────────────
        BtnOk.BackColor                  = Color.FromArgb(21, 101, 192);
        BtnOk.DialogResult               = DialogResult.OK;
        BtnOk.FlatAppearance.BorderSize  = 0;
        BtnOk.FlatStyle                  = FlatStyle.Flat;
        BtnOk.ForeColor                  = Color.White;
        BtnOk.Image                      = Properties.Resources.save1;
        BtnOk.ImageAlign                 = ContentAlignment.MiddleLeft;
        BtnOk.Padding                    = new Padding(6, 0, 0, 0);
        BtnOk.Location                   = new Point(285, 280);
        BtnOk.Name                       = "BtnOk";
        BtnOk.Size                       = new Size(123, 38);
        BtnOk.TabIndex                   = 11;
        BtnOk.Text                       = "  &Enregistrer";
        BtnOk.TextAlign                  = ContentAlignment.MiddleRight;
        BtnOk.TextImageRelation          = TextImageRelation.ImageBeforeText;
        BtnOk.UseVisualStyleBackColor    = false;
        BtnOk.Click                     += BtnOk_Click;

        BtnCancel.DialogResult           = DialogResult.Cancel;
        BtnCancel.FlatStyle              = FlatStyle.Flat;
        BtnCancel.Image                  = Properties.Resources.cancel;
        BtnCancel.ImageAlign             = ContentAlignment.MiddleLeft;
        BtnCancel.Padding                = new Padding(6, 0, 0, 0);
        BtnCancel.Location               = new Point(10, 280);
        BtnCancel.Name                   = "BtnCancel";
        BtnCancel.Size                   = new Size(121, 38);
        BtnCancel.TabIndex               = 12;
        BtnCancel.Text                   = "  &Annuler";
        BtnCancel.TextAlign              = ContentAlignment.MiddleRight;
        BtnCancel.TextImageRelation      = TextImageRelation.ImageBeforeText;

        // ── ParametresForm ────────────────────────────────────────────────────
        AcceptButton      = BtnOk;
        CancelButton      = BtnCancel;
        ClientSize        = new Size(420, 326);
        Controls.Add(TcParams);
        Controls.Add(BtnOk);
        Controls.Add(BtnCancel);
        Font              = new Font("Segoe UI", 9F);
        FormBorderStyle   = FormBorderStyle.FixedDialog;
        Icon              = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox       = false;
        MinimizeBox       = false;
        Name              = "ParametresForm";
        StartPosition     = FormStartPosition.CenterParent;
        Text              = "Paramètres";

        // ── ResumeLayout ──────────────────────────────────────────────────────
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
        GrpSmtp.ResumeLayout(false);
        GrpSmtp.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NudSmtpPort).EndInit();
        TpMontants.ResumeLayout(false);
        TpArbitre.ResumeLayout(false);
        TpArbitre.PerformLayout();
        TpNominations.ResumeLayout(false);
        TpItineraire.ResumeLayout(false);
        TpSmtp.ResumeLayout(false);
        TcParams.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    // ── Déclarations ──────────────────────────────────────────────────────────

    private TabControl TcParams;
    private TabPage    TpMontants;
    private TabPage    TpArbitre;
    private TabPage    TpNominations;
    private TabPage    TpItineraire;
    private TabPage    TpSmtp;

    private GroupBox      Grp;
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
    private Label    LblNomNominationsLbl;
    private TextBox  TxtNomNominations;
    private Label    LblEmailNominationsLbl;
    private TextBox  TxtEmailNominations;
    private Label    LblTelNominationsLbl;
    private TextBox  TxtTelNominations;

    private GroupBox GrpAzureMaps;
    private Label    LblAzureMapsLbl;
    private TextBox  TxtAzureMapsKey;

    private GroupBox      GrpSmtp;
    private Label         LblSmtpServeurLbl;
    private TextBox       TxtSmtpHost;
    private Label         LblSmtpPortLbl;
    private NumericUpDown NudSmtpPort;
    private CheckBox      ChkSmtpSsl;
    private Label         LblSmtpUserLbl;
    private TextBox       TxtSmtpUser;
    private Label         LblSmtpPasswordLbl;
    private TextBox       TxtSmtpPassword;
    private Label         LblSmtpFromLbl;
    private TextBox       TxtSmtpFrom;

    private Button BtnSauverMontants;
    private Button BtnSauverArbitre;
    private Button BtnSauverNominations;
    private Button BtnSauverItineraire;
    private Button BtnSauverSmtp;

    private Button BtnOk;
    private Button BtnCancel;
}
