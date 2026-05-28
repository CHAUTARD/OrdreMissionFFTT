/* RechercheFfttForm.cs
 * Recherche un club FFTT via l'API Smartping (portage de alamirault/fftt-api).
 *
 * Workflow :
 *   1. Saisir / vérifier les identifiants API (id + mot de passe FFTT Smartping)
 *   2. Entrer un code postal → recherche par département (2 premiers chiffres)
 *   3. Cliquer sur un club → chargement asynchrone des détails (mailcor, adresse…)
 *   4. Bouton "Envoyer un email" ouvre EnvoyerEmailForm avec l'adresse pré-remplie
 */
using OrdreMission.CS;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OrdreMission;

public partial class RechercheFfttForm : Form
{
    private static readonly CultureInfo FrFR = CultureInfo.GetCultureInfo("fr-FR");

    private readonly AppSettings     _cfg;
    private readonly EmailTemplate   _emailTpl;
    private readonly string          _equipeLocale;
    private readonly string          _date;
    private readonly string          _heure;
    private FfttClubDetails?         _details;
    private CancellationTokenSource? _ctsFetch;

    public RechercheFfttForm(string codePostal, string equipeLocale, string date, string heure,
                             AppSettings cfg, EmailTemplate emailTpl)
    {
        _cfg      = cfg;
        _emailTpl = emailTpl;
        _equipeLocale = equipeLocale;
        _date     = date;
        _heure    = heure;
        InitializeComponent();
        TxtCp.Text     = codePostal;
        TxtApiId.Text  = _cfg.ApiId;
        TxtApiPwd.Text = _cfg.ApiPassword;
        ActualiserEtatIdentifiants();
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (IdentifiantsOk() && Regex.IsMatch(TxtCp.Text.Trim(), @"^\d{5}$"))
            await RechercherAsync();
    }

    // ── Identifiants ─────────────────────────────────────────────────────────

    private bool IdentifiantsOk() =>
        !string.IsNullOrWhiteSpace(_cfg.ApiId) &&
        !string.IsNullOrWhiteSpace(_cfg.ApiPassword);

    private void ActualiserEtatIdentifiants()
    {
        bool ok = IdentifiantsOk();
        BtnRechercher.Enabled = ok;
        if (ok)
        {
            LblCredEtat.Text      = "✔ Identifiants configurés.";
            LblCredEtat.ForeColor = Color.FromArgb(0, 130, 0);
        }
        else
        {
            LblCredEtat.Text      = "⚠ Identifiants non configurés — remplissez les champs ci-dessus, puis cliquez sur Enregistrer.";
            LblCredEtat.ForeColor = Color.FromArgb(180, 60, 0);
        }
    }

    private void BtnSauvegarderCred_Click(object? sender, EventArgs e)
    {
        _cfg.ApiId       = TxtApiId.Text.Trim();
        _cfg.ApiPassword = TxtApiPwd.Text.Trim();
        _cfg.Save();
        ActualiserEtatIdentifiants();
    }

    private void MnuIdentifiants_Click(object? sender, EventArgs e)
    {
        const int delta = 71;
        bool show = !GrpCred.Visible;
        GrpCred.Visible        = show;
        MnuIdentifiants.Text   = show ? "▲ Masquer identifiants" : "⚙ Identifiants API";
        int sign = show ? +1 : -1;
        foreach (Control c in new Control[] { LblCp, TxtCp, BtnRechercher, DgvClubs, GrpDetail, LblStatus, BtnEmail, BtnFermer })
            c.Top += sign * delta;
        Height += sign * delta;
    }

    private void LblCredLien_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        // Page d'inscription à l'API Smartping FFTT
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(
                "https://www.fftt.com/site/mediatheque/autres-medias/api")
            { UseShellExecute = true });
        }
        catch { /* ignorer si pas de navigateur */ }
    }

    // ── Recherche ─────────────────────────────────────────────────────────────

    private async void BtnRechercher_Click(object? sender, EventArgs e)
        => await RechercherAsync();

    private async Task RechercherAsync()
    {
        string cp = TxtCp.Text.Trim();
        if (!Regex.IsMatch(cp, @"^\d{5}$"))
        {
            LblStatus.Text = "⚠ Code postal invalide (5 chiffres requis).";
            return;
        }
        if (!IdentifiantsOk())
        {
            LblStatus.Text = "⚠ Identifiants API non configurés.";
            return;
        }

        // Département = 2 premiers chiffres du CP (métropole) ou 3 pour DOM-TOM (97x)
        string dep = cp.StartsWith("97") && cp.Length >= 3 ? cp[..3] : cp[..2];

        BtnRechercher.Enabled = false;
        LblStatus.Text        = $"⏳ Recherche des clubs du département {dep}…";
        DgvClubs.Rows.Clear();
        _details          = null;
        BtnEmail.Enabled  = false;
        GrpDetail.Text    = "Club sélectionné";
        LblDetail.Text    = "";

        try
        {
            var clubs = await FfttService.ChercherParDepartementAsync(dep, _cfg.ApiId, _cfg.ApiPassword);

            LblStatus.Text = clubs.Count switch
            {
                0 => "Aucun club trouvé pour ce département.",
                1 => "1 club trouvé. Cliquez dessus pour afficher ses coordonnées.",
                _ => $"{clubs.Count} clubs trouvés. Cliquez sur un club pour afficher ses coordonnées."
            };

            foreach (var c in clubs)
            {
                int row = DgvClubs.Rows.Add(c.Nom, c.Numero);
                DgvClubs.Rows[row].Tag = c;
            }

            if (clubs.Count == 1)
                DgvClubs.Rows[0].Selected = true;
        }
        catch (HttpRequestException ex)
        {
            LblStatus.Text = "⛔ Erreur réseau : " + ex.Message;
        }
        catch (Exception ex)
        {
            LblStatus.Text = "⛔ " + ex.Message;
        }
        finally
        {
            BtnRechercher.Enabled = IdentifiantsOk();
        }
    }

    // ── Sélection d'un club → chargement des détails ──────────────────────────

    private async void DgvClubs_SelectionChanged(object? sender, EventArgs e)
    {
        if (DgvClubs.SelectedRows.Count == 0) return;
        var club = DgvClubs.SelectedRows[0].Tag as FfttClub;
        if (club is null) return;

        // Annuler le fetch précédent encore en vol
        _ctsFetch?.Cancel();
        _ctsFetch = new CancellationTokenSource();
        var cts = _ctsFetch;

        _details         = null;
        BtnEmail.Enabled = false;
        GrpDetail.Text   = club.Nom;
        LblDetail.Text   = "⏳ Chargement des coordonnées…";

        try
        {
            var det = await FfttService.ObtenirDetailsAsync(
                          club.Numero, _cfg.ApiId, _cfg.ApiPassword);

            if (cts.IsCancellationRequested) return;
            _details = det;

            // Construire l'affichage des coordonnées
            var lignes = new List<string>();
            if (!string.IsNullOrWhiteSpace(det.NomSalle))   lignes.Add("Salle : " + det.NomSalle);
            if (!string.IsNullOrWhiteSpace(det.Adresse1))   lignes.Add(det.Adresse1);
            if (!string.IsNullOrWhiteSpace(det.Adresse2))   lignes.Add(det.Adresse2);
            if (!string.IsNullOrWhiteSpace(det.Adresse3))   lignes.Add(det.Adresse3);
            string cp = $"{det.CpSalle} {det.VilleSalle}".Trim();
            if (!string.IsNullOrEmpty(cp))                   lignes.Add(cp);
            if (!string.IsNullOrWhiteSpace(det.TelCor))     lignes.Add("Tél : " + det.TelCor);
            if (!string.IsNullOrWhiteSpace(det.MailCor))    lignes.Add("✉ Email : " + det.MailCor);
            else                                              lignes.Add("✉ Email : (non renseigné)");
            if (!string.IsNullOrWhiteSpace(det.NomCor))
                lignes.Add("Correspondant : " + $"{det.PrenomCor} {det.NomCor}".Trim());

            GrpDetail.Text   = det.Nom;
            LblDetail.Text   = string.Join("\n", lignes);
            BtnEmail.Enabled = !string.IsNullOrWhiteSpace(det.MailCor);
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            if (!cts.IsCancellationRequested)
            {
                LblDetail.Text = "⛔ " + ex.Message;
            }
        }
    }

    // ── Envoi d'email ─────────────────────────────────────────────────────────

    private void BtnEmail_Click(object? sender, EventArgs e)
    {
        if (_details is null) return;
        var (jourCourt, jourLong) = FormatDate(_date);
        string heureNorm = NormaliserHeure(_heure);
        string sujet = _emailTpl.Appliquer(_emailTpl.SujetTemplate, jourCourt: jourCourt, equipeLocale: _equipeLocale);
        string corps = _emailTpl.Appliquer(_emailTpl.CorpsTemplate, jourLong: jourLong, heure: heureNorm, nomArbitre: _cfg.NomArbitre, equipeLocale: _equipeLocale);
        using var form = new EnvoyerEmailForm(_details.MailCor, sujet, corps);
        form.ShowDialog(this);
    }

    // ── Helpers de formatage date / heure ─────────────────────────────────────

    /// <summary>
    /// Retourne (jourCourt, jourLong) à partir d'une date dd/MM/yyyy.
    /// jourCourt = "Samedi 15/12/2026"  (pour le sujet)
    /// jourLong  = "samedi 15 décembre 2026"  (pour le corps)
    /// </summary>
    private static (string jourCourt, string jourLong) FormatDate(string dateStr)
    {
        string[] fmts = [ "dd/MM/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy",
                          "dd/MM/yy",   "d/M/yy",   "d/MM/yy",   "dd/M/yy" ];
        if (DateTime.TryParseExact(dateStr.Trim(), fmts,
                FrFR, System.Globalization.DateTimeStyles.None, out DateTime dt))
        {
            string jourCourt = FrFR.TextInfo.ToTitleCase(dt.ToString("dddd", FrFR))
                               + " " + dt.ToString("dd/MM/yyyy");
            string jourLong  = dt.ToString("dddd d MMMM yyyy", FrFR);
            return (jourCourt, jourLong);
        }
        return (dateStr, dateStr);   // fallback si la date n'est pas parseable
    }

    /// <summary>
    /// Normalise une heure saisie en "XXhYY" : "16:00" → "16h00", "16h" → "16h00".
    /// </summary>
    private static string NormaliserHeure(string heure)
    {
        if (string.IsNullOrWhiteSpace(heure)) return "";
        heure = heure.Trim().Replace(':', 'h').Replace('H', 'h').Replace('.', 'h');
        if (!heure.Contains('h')) return heure + "h00";
        if (heure.EndsWith('h'))  return heure + "00";
        return heure;
    }

    private void BtnFermer_Click(object? sender, EventArgs e) => Close();

    private void TxtCp_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnRechercher.PerformClick(); }
    }
}
