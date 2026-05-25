/* FfttService.cs
 * Portage C# de la bibliothèque PHP alamirault/fftt-api (github.com/alamirault/fftt-api).
 *
 * API FFTT Smartping — authentification HMAC-SHA1 :
 *   URL  = https://www.fftt.com/mobile/pxml/{endpoint}.php
 *          ?serie={id}&tm={timestamp_ms}&tmc={HMAC-SHA1(ts, MD5(pwd))}&id={id}&{params}
 *
 * Endpoints utilisés :
 *   xml_club_dep2   dep={dept_2chiffres}  → liste clubs d'un département (numero + nom)
 *   xml_club_detail club={numero}          → détails complets (adresse, mailcor, telcor…)
 */
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace OrdreMission.CS;

// ── Modèles ───────────────────────────────────────────────────────────────────

/// <summary>Club retourné par la liste départementale (numero + nom uniquement).</summary>
public sealed class FfttClub
{
    public string Numero { get; init; } = "";
    public string Nom    { get; init; } = "";
}

/// <summary>Détails complets d'un club (adresse salle + coordonnées du correspondant).</summary>
public sealed class FfttClubDetails
{
    public string Numero     { get; init; } = "";
    public string Nom        { get; init; } = "";
    public string NomSalle   { get; init; } = "";
    public string Adresse1   { get; init; } = "";
    public string Adresse2   { get; init; } = "";
    public string Adresse3   { get; init; } = "";
    public string CpSalle    { get; init; } = "";
    public string VilleSalle { get; init; } = "";
    public string Web        { get; init; } = "";
    public string NomCor     { get; init; } = "";
    public string PrenomCor  { get; init; } = "";
    public string MailCor    { get; init; } = "";   // ← email du correspondant
    public string TelCor     { get; init; } = "";
}

// ── Service ───────────────────────────────────────────────────────────────────

public static class FfttService
{
    private const string BaseUrl = "https://www.fftt.com/mobile/pxml/";

    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(15) };

    static FfttService()
    {
        Http.DefaultRequestHeaders.UserAgent.ParseAdd("OrdreMission/1.0");
    }

    // ── API publique ──────────────────────────────────────────────────────────

    /// <summary>
    /// Retourne la liste des clubs d'un département (2 premiers chiffres du code postal).
    /// </summary>
    public static async Task<List<FfttClub>> ChercherParDepartementAsync(
        string dep2chiffres, string apiId, string apiPassword)
    {
        string url = BuildUrl("xml_club_dep2", apiId, apiPassword,
                              [("dep", dep2chiffres.PadLeft(2, '0'))]);
        string xml = await FetchXmlAsync(url).ConfigureAwait(false);
        return ParseClubs(xml);
    }

    /// <summary>
    /// Retourne les détails complets d'un club (incluant <c>MailCor</c>).
    /// </summary>
    public static async Task<FfttClubDetails> ObtenirDetailsAsync(
        string clubNumero, string apiId, string apiPassword)
    {
        string url = BuildUrl("xml_club_detail", apiId, apiPassword,
                              [("club", clubNumero)]);
        string xml = await FetchXmlAsync(url).ConfigureAwait(false);
        return ParseClubDetails(xml);
    }

    // ── Authentification HMAC-SHA1 ────────────────────────────────────────────
    // Algorithme identique à UriGenerator.php du projet alamirault/fftt-api :
    //   tm  = timestamp en millisecondes
    //   tmc = hash_hmac('sha1', (string)tm, md5(password))

    private static string BuildUrl(
        string endpoint, string id, string password,
        IEnumerable<(string key, string value)> extraParams)
    {
        long   tm     = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        string md5Pwd = Md5Hex(password);
        string tmc    = HmacSha1Hex(tm.ToString(), md5Pwd);

        var sb = new StringBuilder(BaseUrl);
        sb.Append(endpoint).Append(".php");
        sb.Append("?serie=").Append(Uri.EscapeDataString(id));
        sb.Append("&tm=").Append(tm);
        sb.Append("&tmc=").Append(tmc);
        sb.Append("&id=").Append(Uri.EscapeDataString(id));

        foreach (var (k, v) in extraParams)
            sb.Append('&').Append(k).Append('=').Append(Uri.EscapeDataString(v));

        return sb.ToString();
    }

    private static string Md5Hex(string input)
    {
        using var md5 = MD5.Create();
        return Convert.ToHexString(
            md5.ComputeHash(Encoding.UTF8.GetBytes(input))).ToLowerInvariant();
    }

    private static string HmacSha1Hex(string message, string key)
    {
        // La clé est la représentation hexadécimale du MD5 (UTF-8 bytes)
        using var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(key));
        return Convert.ToHexString(
            hmac.ComputeHash(Encoding.UTF8.GetBytes(message))).ToLowerInvariant();
    }

    // ── Récupération et nettoyage du XML ──────────────────────────────────────
    // Quirks de l'API FFTT (reproduit depuis FFTTClient.php) :
    //   1. Des & non échappés peuvent traîner dans les réponses XML
    //   2. L'encodage peut être ISO-8859-1 ou UTF-8 selon l'endpoint

    private static async Task<string> FetchXmlAsync(string url)
    {
        byte[] bytes = await Http.GetByteArrayAsync(url).ConfigureAwait(false);
        string xml   = DetecterEtDecoder(bytes);

        // Corrige les & non échappés (bug connu de l'API FFTT)
        xml = Regex.Replace(xml, @"&(?!#?[a-zA-Z0-9]+;)", "&amp;");

        return xml;
    }

    private static string DetecterEtDecoder(byte[] bytes)
    {
        // Lit les premiers octets en ASCII pour trouver l'attribut encoding="..."
        string prolog = Encoding.ASCII.GetString(bytes, 0, Math.Min(bytes.Length, 300));
        int idx = prolog.IndexOf("encoding=\"", StringComparison.OrdinalIgnoreCase);
        if (idx >= 0)
        {
            idx += 10;
            int end = prolog.IndexOf('"', idx);
            if (end > idx)
            {
                try
                {
                    var enc = Encoding.GetEncoding(prolog[idx..end]);
                    return enc.GetString(bytes);
                }
                catch { /* encodage inconnu → UTF-8 */ }
            }
        }
        return Encoding.UTF8.GetString(bytes);
    }

    // ── Parseurs XML ─────────────────────────────────────────────────────────

    private static List<FfttClub> ParseClubs(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            return (doc.Root?.Elements("club") ?? [])
                .Select(e => new FfttClub
                {
                    Numero = e.Element("numero")?.Value ?? "",
                    Nom    = e.Element("nom")?.Value    ?? ""
                })
                .OrderBy(c => c.Nom)
                .ToList();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Réponse XML invalide : " + ex.Message, ex);
        }
    }

    private static FfttClubDetails ParseClubDetails(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            var e   = doc.Root?.Element("club")
                      ?? throw new InvalidOperationException("Club introuvable dans la réponse.");

            // Certains champs peuvent être absents ou vides ({})
            static string Val(XElement? el) =>
                el is null || el.IsEmpty ? "" : el.Value;

            return new FfttClubDetails
            {
                Numero     = Val(e.Element("numero")),
                Nom        = Val(e.Element("nom")),
                NomSalle   = Val(e.Element("nomsalle")),
                Adresse1   = Val(e.Element("adressesalle1")),
                Adresse2   = Val(e.Element("adressesalle2")),
                Adresse3   = Val(e.Element("adressesalle3")),
                CpSalle    = Val(e.Element("codepsalle")),
                VilleSalle = Val(e.Element("villesalle")),
                Web        = Val(e.Element("web")),
                NomCor     = Val(e.Element("nomcor")),
                PrenomCor  = Val(e.Element("prenomcor")),
                MailCor    = Val(e.Element("mailcor")),
                TelCor     = Val(e.Element("telcor"))
            };
        }
        catch (InvalidOperationException) { throw; }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Réponse XML invalide : " + ex.Message, ex);
        }
    }
}
