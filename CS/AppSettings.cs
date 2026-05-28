using System.Text.Json;

namespace OrdreMission.CS;

public sealed class FieldPos
{
    public float X       { get; set; }
    public float Y       { get; set; }
    public float Hauteur { get; set; } = 16f;   // hauteur du rectangle d'effacement (pt)
    public float Largeur { get; set; } = 130f;  // largeur du rectangle d'effacement (pt)
}

public sealed class AppSettings
{
    // ── Compétition ───────────────────────────────────────────────────────────

    // Oipposant, texte écrit dans le formulaire, est le nom de l'équipe locale
    public FieldPos Opposant    { get; set; } = new() { X = 100f, Y = 700f, Hauteur = 16, Largeur = 200f };
    public FieldPos Date        { get; set; } = new() { X = 340f, Y = 700f, Hauteur = 16, Largeur = 100f };
    public FieldPos Heure       { get; set; } = new() { X = 470f, Y = 700f, Hauteur = 16, Largeur =  70f };
    public FieldPos Adresse     { get; set; } = new() { X = 100f, Y = 680f, Hauteur = 16, Largeur = 300f };

    // ── Tableau financier — coordonnées réelles extraites du PDF ──────────────
    // Origine : coin bas-gauche · A4 = 595 × 842 pt
    // La ligne de données est à Y=305. Les valeurs ci-dessous écrasent
    // le texte existant (zones effacées par rectangle blanc avant écriture).
    public FieldPos Peage      { get; set; } = new() { X = 180f, Y = 305f, Hauteur = 16, Largeur = 130f };
    public FieldPos NbKm       { get; set; } = new() { X = 284f, Y = 305f, Hauteur = 16, Largeur =  70f };
    public FieldPos TotalFrais { get; set; } = new() { X = 512f, Y = 305f, Hauteur = 16, Largeur = 130f };

    // ── Rapport de Juge Arbitre — colonne droite ──────────────────────────────
    public FieldPos RapportAccueil    { get; set; } = new() { X = 205f, Y = 255f, Hauteur = 15, Largeur = 350f };
    public FieldPos RapportEquipement { get; set; } = new() { X = 205f, Y = 226f, Hauteur = 15, Largeur = 350f };

    // ── Montants ──────────────────────────────────────────────────────────────
    public decimal IndemFixe { get; set; } = 25m;
    public decimal TauxKm    { get; set; } = 0.30m;

    // ── Adresse de départ ─────────────────────────────────────────────────────
    public string AdresseNumero     { get; set; } = "";
    public string AdresseRue        { get; set; } = "";
    public string AdresseCodePostal { get; set; } = "";
    public string AdresseVille      { get; set; } = "";

    // ── Dernier état de saisie (restauré au démarrage) ────────────────────────
    public string  DernierSource      { get; set; } = "";
    public decimal DernierPeage       { get; set; } = 0m;
    public decimal DernierKm          { get; set; } = 0m;
    public string  DernierEquipeLocale    { get; set; } = "";
    public string  DerniereDate       { get; set; } = "";
    public string  DerniereHeure      { get; set; } = "";
    public string  DerniereAdresse    { get; set; } = "";

    // ── Signature ─────────────────────────────────────────────────────────────
    public float SigX { get; set; } = 350f;
    public float SigY { get; set; } =  80f;
    public float SigW { get; set; } = 130f;
    public float SigH { get; set; } =  40f;

    public int  Page               { get; set; } = 1;
    public bool RectanglesVisibles { get; set; } = false;
    public bool SignatureVisible   { get; set; } = false;

    // ── Arbitre ───────────────────────────────────────────────────────────────
    public string NomArbitre { get; set; } = "";   // ex. "Patrick CHAUTARD"

    // ── Responsable des nominations ───────────────────────────────────────────
    public string NomResponsableNominations   { get; set; } = "";
    public string EmailResponsableNominations { get; set; } = "";
    public string TelResponsableNominations   { get; set; } = "";

    // ── Mapbox (calcul d'itinéraire) ──────────────────────────────────────────
    // Jeton d'accès public (commence par pk.eyJ1…) : https://account.mapbox.com/
    // Quota gratuit : 100 000 géocodages/mois + 100 000 directions/mois.
    public string MapboxApiKey   { get; set; } = "";
    // Champs conservés pour rétrocompatibilité JSON (ne plus utiliser)
    public string OrsApiKey      { get; set; } = "";
    public string AzureMapsApiKey { get; set; } = "";

    // ── API FFTT Smartping ────────────────────────────────────────────────────
    // Identifiants obtenus auprès de la FFTT : interfaces.informatiques@fftt.email
    public string ApiId       { get; set; } = "";
    public string ApiPassword { get; set; } = "";

    // ── SMTP (envoi d'email via MailKit) ──────────────────────────────────────
    // SmtpSsl = false → STARTTLS (port 587 recommandé)
    // SmtpSsl = true  → SSL/TLS direct (port 465)
    // Mot de passe stocké en clair dans positions.json (usage local uniquement).
    public string SmtpHost     { get; set; } = "";
    public int    SmtpPort     { get; set; } = 587;
    public bool   SmtpSsl      { get; set; } = false;
    public string SmtpUser     { get; set; } = "";
    public string SmtpPassword { get; set; } = "";
    public string SmtpFrom     { get; set; } = "";

    // ── Persistance ───────────────────────────────────────────────────────────

    private static readonly string FilePath =
        System.IO.Path.Combine(AppContext.BaseDirectory, "positions.json");

    public static AppSettings Load()
    {
        if (!File.Exists(FilePath)) return new();
        try
        {
            return JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(FilePath)) ?? new();
        }
        catch { return new(); }
    }

    public void Save()
    {
        JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };
        JsonSerializerOptions opts = jsonSerializerOptions;
        File.WriteAllText(FilePath, JsonSerializer.Serialize(this, opts));
    }
}
