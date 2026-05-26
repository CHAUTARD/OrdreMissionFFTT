/* RoutingService.cs
 * Calcul d'itinéraire entre deux adresses françaises via OpenRouteService (ORS).
 *
 * Géocodage : ORS Geocode Search (Pelias / OpenStreetMap)
 *   GET https://api.openrouteservice.org/geocode/search
 *
 * Routage   : ORS Directions v2 (driving-car)
 *   GET https://api.openrouteservice.org/v2/directions/driving-car
 *
 * Clé gratuite : https://openrouteservice.org/dev/#/signup
 * Quota free   : 2 000 requêtes/jour · 40 requêtes/minute.
 */
using System.Globalization;
using System.Text.Json.Nodes;

namespace OrdreMission.CS;

public static class RoutingService
{
    private const string BaseUrl = "https://api.openrouteservice.org";

    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(20) };

    static RoutingService()
    {
        Http.DefaultRequestHeaders.UserAgent.ParseAdd("OrdreMission/1.0");
    }

    // ── API publique ──────────────────────────────────────────────────────────

    /// <summary>
    /// Calcule la distance (km, arrondi à 0,1) et la durée (minutes).
    /// </summary>
    /// <param name="apiKey">Clé API OpenRouteService.</param>
    /// <exception cref="InvalidOperationException">Adresse introuvable ou réseau indisponible.</exception>
    public static async Task<(double Km, int Minutes)> CalculerAsync(
        string adresseDepart, string adresseArrivee, string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("Clé API OpenRouteService non configurée.");

        var dep = await GeocoderAsync(adresseDepart,  apiKey).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse de départ introuvable :\n" + adresseDepart);

        var arr = await GeocoderAsync(adresseArrivee, apiKey).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse d'arrivée introuvable :\n" + adresseArrivee);

        return await RouteOrsAsync(dep, arr, apiKey).ConfigureAwait(false);
    }

    // ── Géocodage ORS / Pelias ────────────────────────────────────────────────

    private static async Task<(double Lat, double Lon)?> GeocoderAsync(
        string adresse, string apiKey)
    {
        string url = BaseUrl + "/geocode/search"
                   + "?api_key="          + Uri.EscapeDataString(apiKey)
                   + "&text="             + Uri.EscapeDataString(adresse)
                   + "&boundary.country=FRA"
                   + "&size=1";

        string json  = await Http.GetStringAsync(url).ConfigureAwait(false);
        var    root  = JsonNode.Parse(json);
        var    feats = root?["features"]?.AsArray();
        if (feats is null || feats.Count == 0) return null;

        // GeoJSON : coordinates = [lon, lat]
        var coords = feats[0]?["geometry"]?["coordinates"]?.AsArray();
        if (coords is null || coords.Count < 2) return null;

        double lon = coords[0]?.GetValue<double>() ?? double.NaN;
        double lat = coords[1]?.GetValue<double>() ?? double.NaN;
        if (double.IsNaN(lat) || double.IsNaN(lon)) return null;

        return (lat, lon);
    }

    // ── Routage ORS Directions ────────────────────────────────────────────────

    private static async Task<(double Km, int Minutes)> RouteOrsAsync(
        (double Lat, double Lon) dep, (double Lat, double Lon) arr, string apiKey)
    {
        static string F(double d) => d.ToString("F6", CultureInfo.InvariantCulture);

        // ORS attend les coordonnées au format lon,lat
        string url = BaseUrl + "/v2/directions/driving-car"
                   + "?api_key=" + Uri.EscapeDataString(apiKey)
                   + "&start="   + $"{F(dep.Lon)},{F(dep.Lat)}"
                   + "&end="     + $"{F(arr.Lon)},{F(arr.Lat)}";

        string json  = await Http.GetStringAsync(url).ConfigureAwait(false);
        var    root  = JsonNode.Parse(json);
        var    summ  = root?["features"]?[0]?["properties"]?["summary"]
                       ?? throw new InvalidOperationException("Aucun itinéraire trouvé par ORS.");

        double metres  = summ["distance"]?.GetValue<double>() ?? 0;
        double seconds = summ["duration"]?.GetValue<double>() ?? 0;

        return (Math.Round(metres / 1000.0, 1), (int)Math.Round(seconds / 60.0));
    }
}
