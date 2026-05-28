/* RoutingService.cs
 * Calcul d'itinéraire entre deux adresses françaises via Mapbox.
 *
 * Géocodage : Mapbox Geocoding API v5
 *   GET https://api.mapbox.com/geocoding/v5/mapbox.places/{query}.json
 *
 * Routage   : Mapbox Directions API v5 (driving)
 *   GET https://api.mapbox.com/directions/v5/mapbox/driving/{lon1,lat1};{lon2,lat2}
 *
 * Jeton d'accès : https://account.mapbox.com/
 * Quota gratuit : 100 000 géocodages/mois + 100 000 directions/mois.
 */
using System.Globalization;
using System.Text.Json.Nodes;

namespace OrdreMission.CS;

public static class RoutingService
{
    private const string BaseUrl = "https://api.mapbox.com";

    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(20) };

    static RoutingService()
    {
        Http.DefaultRequestHeaders.UserAgent.ParseAdd("OrdreMission/1.0");
    }

    // ── API publique ──────────────────────────────────────────────────────────

    /// <summary>
    /// Calcule la distance (km, arrondi à 0,1) et la durée (minutes).
    /// </summary>
    /// <param name="apiKey">Jeton d'accès Mapbox (pk.eyJ1…).</param>
    /// <exception cref="InvalidOperationException">Adresse introuvable ou erreur API.</exception>
    public static async Task<(double Km, int Minutes)> CalculerAsync(
        string adresseDepart, string adresseArrivee, string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("Jeton Mapbox non configuré.");

        var dep = await GeocoderAsync(adresseDepart,  apiKey).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse de départ introuvable :\n" + adresseDepart);

        var arr = await GeocoderAsync(adresseArrivee, apiKey).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse d'arrivée introuvable :\n" + adresseArrivee);

        return await RouteMapboxAsync(dep, arr, apiKey).ConfigureAwait(false);
    }

    // ── Géocodage Mapbox ──────────────────────────────────────────────────────

    private static async Task<(double Lat, double Lon)?> GeocoderAsync(
        string adresse, string apiKey)
    {
        string query = Uri.EscapeDataString(adresse);
        string url   = $"{BaseUrl}/geocoding/v5/mapbox.places/{query}.json"
                     + $"?access_token={Uri.EscapeDataString(apiKey)}"
                     +  "&country=fr&language=fr&limit=1";

        string json  = await Http.GetStringAsync(url).ConfigureAwait(false);
        var    root  = JsonNode.Parse(json);
        var    feats = root?["features"]?.AsArray();
        if (feats is null || feats.Count == 0) return null;

        // Mapbox GeoJSON : center = [lon, lat]
        var center = feats[0]?["center"]?.AsArray();
        if (center is null || center.Count < 2) return null;

        double lon = center[0]?.GetValue<double>() ?? double.NaN;
        double lat = center[1]?.GetValue<double>() ?? double.NaN;
        if (double.IsNaN(lat) || double.IsNaN(lon)) return null;

        return (lat, lon);
    }

    // ── Routage Mapbox Directions ─────────────────────────────────────────────

    private static async Task<(double Km, int Minutes)> RouteMapboxAsync(
        (double Lat, double Lon) dep, (double Lat, double Lon) arr, string apiKey)
    {
        static string F(double d) => d.ToString("F6", CultureInfo.InvariantCulture);

        // Mapbox attend les coordonnées au format lon,lat séparées par ";"
        string coords = $"{F(dep.Lon)},{F(dep.Lat)};{F(arr.Lon)},{F(arr.Lat)}";
        string url    = $"{BaseUrl}/directions/v5/mapbox/driving/{coords}"
                      + $"?access_token={Uri.EscapeDataString(apiKey)}"
                      +  "&overview=false";

        string json   = await Http.GetStringAsync(url).ConfigureAwait(false);
        var    root   = JsonNode.Parse(json);
        var    routes = root?["routes"]?.AsArray();

        if (routes is null || routes.Count == 0)
            throw new InvalidOperationException("Aucun itinéraire trouvé par Mapbox.");

        double metres  = routes[0]?["distance"]?.GetValue<double>() ?? 0;
        double seconds = routes[0]?["duration"]?.GetValue<double>() ?? 0;

        return (Math.Round(metres / 1000.0, 1), (int)Math.Round(seconds / 60.0));
    }
}
