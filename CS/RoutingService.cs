/* RoutingService.cs
 * Calcul d'itinéraire entre deux adresses françaises.
 *
 * Géocodage : Nominatim (OpenStreetMap) — https://nominatim.openstreetmap.org
 * Routage   : OSRM public demo server   — https://router.project-osrm.org
 *
 * Aucune clé API requise. Connexion internet nécessaire.
 * Respect des CGU Nominatim : User-Agent identifiable, ≤ 1 requête/seconde.
 */
using System.Globalization;
using System.Text.Json.Nodes;

namespace OrdreMission.CS;

public static class RoutingService
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(20) };

    static RoutingService()
    {
        // Nominatim exige un User-Agent identifiable (CGU §2)
        Http.DefaultRequestHeaders.UserAgent.ParseAdd(
            "OrdreMission/1.0 (patrick.chautard@free.fr)");
    }

    // ── API publique ──────────────────────────────────────────────────────────

    /// <summary>
    /// Calcule la distance (km arrondi à 0,1) et la durée (minutes)
    /// entre <paramref name="adresseDepart"/> et <paramref name="adresseArrivee"/>.
    /// Lève <see cref="InvalidOperationException"/> si une adresse est introuvable.
    /// </summary>
    public static async Task<(double Km, int Minutes)> CalculerAsync(
        string adresseDepart, string adresseArrivee)
    {
        // Géocodage séquentiel (respect du 1 req/s Nominatim)
        var dep = await GeocoderAsync(adresseDepart).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse de départ introuvable :\n" + adresseDepart);

        await Task.Delay(1100).ConfigureAwait(false);  // respecte la limite 1 req/s

        var arr = await GeocoderAsync(adresseArrivee).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse d'arrivée introuvable :\n" + adresseArrivee);

        return await RouteOsrmAsync(dep, arr).ConfigureAwait(false);
    }

    // ── Géocodage Nominatim ───────────────────────────────────────────────────

    private static async Task<(double Lat, double Lon)?> GeocoderAsync(string adresse)
    {
        string url = "https://nominatim.openstreetmap.org/search"
                   + "?q="            + Uri.EscapeDataString(adresse)
                   + "&format=json&limit=1&countrycodes=fr";

        string json = await Http.GetStringAsync(url).ConfigureAwait(false);
        var arr = JsonNode.Parse(json)?.AsArray();
        if (arr is null || arr.Count == 0) return null;

        var item = arr[0];
        if (!double.TryParse(item?["lat"]?.GetValue<string>(),
                NumberStyles.Float, CultureInfo.InvariantCulture, out double lat)) return null;
        if (!double.TryParse(item?["lon"]?.GetValue<string>(),
                NumberStyles.Float, CultureInfo.InvariantCulture, out double lon)) return null;

        return (lat, lon);
    }

    // ── Routage OSRM ──────────────────────────────────────────────────────────

    private static async Task<(double Km, int Minutes)> RouteOsrmAsync(
        (double Lat, double Lon) dep, (double Lat, double Lon) arr)
    {
        // OSRM attend les coordonnées au format lon,lat (ordre inversé)
        static string F(double d) => d.ToString("F6", CultureInfo.InvariantCulture);

        string coords = $"{F(dep.Lon)},{F(dep.Lat)};{F(arr.Lon)},{F(arr.Lat)}";
        string url    = $"https://router.project-osrm.org/route/v1/driving/{coords}?overview=false";

        string json  = await Http.GetStringAsync(url).ConfigureAwait(false);
        var    root  = JsonNode.Parse(json);
        var    route = root?["routes"]?[0]
                       ?? throw new InvalidOperationException("Aucun itinéraire trouvé par OSRM.");

        double metres  = route["distance"]?.GetValue<double>() ?? 0;
        double seconds = route["duration"]?.GetValue<double>() ?? 0;

        return (Math.Round(metres / 1000.0, 1), (int)Math.Round(seconds / 60.0));
    }
}
