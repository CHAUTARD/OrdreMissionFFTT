/* EmailTemplate.cs
 * Modèle de l'email envoyé aux clubs adverses.
 * Persisté dans email_template.json à côté de l'EXE.
 *
 * Variables disponibles dans les templates :
 *   {jourCourt}   → ex. "Samedi 15/12/2026"
 *   {jourLong}    → ex. "samedi 15 décembre 2026"
 *   {heure}       → ex. "16h00"
 *   {nomArbitre}  → valeur de AppSettings.NomArbitre
 */
using System.Text.Json;

namespace OrdreMission.CS;

public sealed class EmailTemplate
{
    // ── Modèles ───────────────────────────────────────────────────────────────

    public string SujetTemplate { get; set; } = "Arbitrage de la rencontre du {jourCourt}";

    public string CorpsTemplate { get; set; } =
        "Bonjour,\r\n\r\n" +
        "Je vais officier comme juge arbitre lors de votre rencontre du {jourLong} à {heure}.\r\n\r\n" +
        "La rencontre est-elle toujours d'actualité, l'horaire et le lieu restent-ils inchangés ?\r\n\r\n" +
        "Pour informations :\r\n" +
        "- Je me déplace avec mon poste d'arbitrage avec GIRPE et une imprimante.\r\n\r\n" +
        "Sinon :\r\n" +
        "- Une prise électrique existe-t-elle à proximité ?\r\n" +
        "- À partir de quelle heure la salle est-elle ouverte ?\r\n\r\n" +
        "Cordialement\r\n" +
        "{nomArbitre}";

    // ── Persistance ───────────────────────────────────────────────────────────

    private static readonly string FilePath =
        System.IO.Path.Combine(AppContext.BaseDirectory, "email_template.json");

    public static EmailTemplate Load()
    {
        if (!File.Exists(FilePath)) return new();
        try
        {
            return JsonSerializer.Deserialize<EmailTemplate>(
                       File.ReadAllText(FilePath)) ?? new();
        }
        catch { return new(); }
    }

    public void Save()
    {
        JsonSerializerOptions opts = new() { WriteIndented = true };
        File.WriteAllText(FilePath, JsonSerializer.Serialize(this, opts));
    }

    // ── Application des variables ─────────────────────────────────────────────

    /// <summary>Génère le sujet en substituant {jourCourt}.</summary>
    public string AppliquerSujet(string jourCourt)
        => SujetTemplate.Replace("{jourCourt}", jourCourt);

    /// <summary>Génère le corps en substituant toutes les variables.</summary>
    public string AppliquerCorps(string jourLong, string heure,
                                 string nomArbitre = "", string equipe = "")
        => CorpsTemplate
               .Replace("{jourLong}",    jourLong)
               .Replace("{heure}",       heure)
               .Replace("{nomArbitre}",  nomArbitre)
               .Replace("{equipe}",      equipe);
}
