/* DateHelper.cs
 * Helpers partagés pour le formatage des dates et heures (Form1, RechercheFfttForm…).
 */
using System.Globalization;

namespace OrdreMission.CS;

internal static class DateHelper
{
    private static readonly CultureInfo FrFR = CultureInfo.GetCultureInfo("fr-FR");

    /// <summary>
    /// Retourne (jourCourt, jourLong) à partir d'une date dd/MM/yyyy.
    /// jourCourt = "Samedi 15/12/2026"   — utilisé dans le sujet de l'email.
    /// jourLong  = "samedi 15 décembre 2026" — utilisé dans le corps de l'email.
    /// Retourne (dateStr, dateStr) si la date ne peut pas être analysée.
    /// </summary>
    public static (string jourCourt, string jourLong) FormatDate(string dateStr)
    {
        string[] fmts = [ "dd/MM/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy",
                          "dd/MM/yy",   "d/M/yy",   "d/MM/yy",   "dd/M/yy" ];
        if (DateTime.TryParseExact(dateStr.Trim(), fmts,
                FrFR, DateTimeStyles.None, out DateTime dt))
        {
            string jourCourt = FrFR.TextInfo.ToTitleCase(dt.ToString("dddd", FrFR))
                               + " " + dt.ToString("dd/MM/yyyy");
            string jourLong  = dt.ToString("dddd d MMMM yyyy", FrFR);
            return (jourCourt, jourLong);
        }
        return (dateStr, dateStr);
    }

    /// <summary>
    /// Normalise une heure saisie en format "XXhYY" :
    /// "16:00" → "16h00", "16h" → "16h00", "16H30" → "16h30".
    /// </summary>
    public static string NormaliserHeure(string heure)
    {
        if (string.IsNullOrWhiteSpace(heure)) return "";
        heure = heure.Trim().Replace(':', 'h').Replace('H', 'h').Replace('.', 'h');
        if (!heure.Contains('h')) return heure + "h00";
        if (heure.EndsWith('h'))  return heure + "00";
        return heure;
    }
}
