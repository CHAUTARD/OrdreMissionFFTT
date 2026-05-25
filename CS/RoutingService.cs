/* RoutingService.cs
 * Calcul d'itinéraire entre deux adresses françaises via Azure Maps.
 *
 * Géocodage : Azure Maps Search Address API
 *   GET https://atlas.microsoft.com/search/address/json?api-version=1.0&query=...
 *
 * Routage   : Azure Maps Route Directions API
 *   GET https://atlas.microsoft.com/route/directions/json?api-version=1.0&query=lat1,lon1:lat2,lon2
 *
 * Clé requise : subscription-key (portail Azure › Azure Maps › Clés d'accès).
 */
using System.Globalization;
using System.Text.Json.Nodes;

namespace OrdreMission.CS;

public static class RoutingService
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(20) };

    static RoutingService()
    {
        Http.DefaultRequestHeaders.UserAgent.ParseAdd("OrdreMission/1.0");
    }

    // ── API publique ──────────────────────────────────────────────────────────

    /// <summary>
    /// Calcule la distance (km, arrondi à 0,1) et la durée (minutes) entre deux adresses.
    /// </summary>
    /// <param name="apiKey">Clé d'abonnement Azure Maps.</param>
    /// <exception cref="InvalidOperationException">Adresse introuvable ou itinéraire impossible.</exception>
    public static async Task<(double Km, int Minutes)> CalculerAsync(
        string adresseDepart, string adresseArrivee, string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("Clé Azure Maps non configurée.");

        var dep = await GeocoderAsync(adresseDepart,  apiKey).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse de départ introuvable :\n" + adresseDepart);

        var arr = await GeocoderAsync(adresseArrivee, apiKey).ConfigureAwait(false)
                  ?? throw new InvalidOperationException(
                         "Adresse d'arrivée introuvable :\n" + adresseArrivee);

        return await RouteAsync(dep, arr, apiKey).ConfigureAwait(false);
    }

    // ── Géocodage Azure Maps Search ───────────────────────────────────────────

    private static async Task<(double Lat, double Lon)?> GeocoderAsync(
        string adresse, string apiKey)
    {
        string url = "https://atlas.microsoft.com/search/address/json"
                   + "?api-version=1.0"
                   + "&query="            + Uri.EscapeDataString(adresse)
                   + "&language=fr-FR"
                   + "&countrySet=FR"
                   + "&subscription-key=" + Uri.EscapeDataString(apiKey);

        string json = await Http.GetStringAsync(url).ConfigureAwait(false);
        var root    = JsonNode.Parse(json);
        var results = root?["results"]?.AsArray();
        if (results is null || results.Count == 0) return null;

        var pos = results[0]?["position"];
        if (pos is null) return null;

        double lat = pos["lat"]?.GetValue<double>() ?? double.NaN;
        double lon = pos["lon"]?.GetValue<double>() ?? double.NaN;
        if (double.IsNaN(lat) || double.IsNaN(lon)) return null;

        return (lat, lon);
    }

    // ── Routage Azure Maps Route ──────────────────────────────────────────────

    private static async Task<(double Km, int Minutes)> RouteAsync(
        (double Lat, double Lon) dep, (double Lat, double Lon) arr, string apiKey)
    {
        static string F(double d) => d.ToString("F6", CultureInfo.InvariantCulture);

        // query = "lat1,lon1:lat2,lon2"
        string query = $"{F(dep.Lat)},{F(dep.Lon)}:{F(arr.Lat)},{F(arr.Lon)}";
        string url   = "https://atlas.microsoft.com/route/directions/json"
                     + "?api-version=1.0"
                     + "&query="            + query
                     + "&travelMode=car"
                     + "&subscription-key=" + Uri.EscapeDataString(apiKey);

        string json  = await Http.GetStringAsync(url).ConfigureAwait(false);
        var    root  = JsonNode.Parse(json);
        var    summ  = root?["routes"]?[0]?["summary"]
                       ?? throw new InvalidOperationException("Aucun itinéraire trouvé par Azure Maps.");

        double metres  = summ["lengthInMeters"]?.GetValue<double>()     ?? 0;
        double seconds = summ["travelTimeInSeconds"]?.GetValue<double>() ?? 0;

        return (Math.Round(metres / 1000.0, 1), (int)Math.Round(seconds / 60.0));
    }
}
