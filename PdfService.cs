using System.Globalization;
using System.Text.RegularExpressions;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Layout;
using iText.Layout.Properties;

namespace OrdreMission;

/// <summary>Données de compétition lues depuis la convocation PDF.</summary>
public sealed class CompetitionInfo
{
    public string Opposant    { get; init; } = "";
    public string Date        { get; init; } = "";
    public string Heure       { get; init; } = "";
    public string Adresse     { get; init; } = "";
    public string Responsable { get; init; } = "";
}

public static class PdfService
{
    private static readonly CultureInfo Fr = CultureInfo.GetCultureInfo("fr-FR");

    // ── Lecture des infos compétition depuis le PDF source ────────────────────

    /// <summary>
    /// Extrait le texte du PDF et en deduit les champs de la competition.
    /// Retourne un objet vide (chaines vides) en cas d'echec.
    /// </summary>
    public static CompetitionInfo ReadCompetitionInfo(string inputPath, int page)
    {
        try
        {
            var readerProps = new ReaderProperties().SetPassword(null);
            using var reader = new PdfReader(inputPath, readerProps).SetUnethicalReading(true);
            using var pdfDoc = new PdfDocument(reader);

            int pageNum = Math.Max(1, Math.Min(page, pdfDoc.GetNumberOfPages()));
            string text = PdfTextExtractor.GetTextFromPage(
                pdfDoc.GetPage(pageNum),
                new SimpleTextExtractionStrategy());

            return ParseCompetitionInfo(text);
        }
        catch
        {
            return new CompetitionInfo();
        }
    }

    private static CompetitionInfo ParseCompetitionInfo(string text)
    {
        // Extrait le premier groupe capturant du pattern, ou "" si absent.
        static string Get(string pattern, string input)
        {
            var m = Regex.Match(input, pattern,
                RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return m.Success ? m.Groups[1].Value.Trim() : "";
        }

        // Nettoie les espaces multiples produits par l'extraction PDF.
        static string Clean(string s) =>
            Regex.Replace(s, @"\s{2,}", " ").Trim();

        return new CompetitionInfo
        {
            // "Opposant :" ou "Opposant -" suivi du nom du club
            Opposant    = Clean(Get(@"[Oo]pposant\s*[:\-]\s*(.+?)$",          text)),

            // "le," ou "le " suivi de la date (jusqu'a "a" horaire ou fin de ligne)
            Date        = Clean(Get(@"\ble[,\s]+\s*(.{3,30}?)(?:\s+[aà]\s+\d|\s*$)", text)),

            // "a " ou "a " suivi de l'heure au format hh:mm ou hhhmm
            Heure       = Clean(Get(@"\b[aà]\s+(\d{1,2}\s*[hH:]\s*\d{2})\b",  text)),

            // "ADRESSE DE LA SALLE" suivi de l'adresse
            Adresse     = Clean(Get(@"ADRESSE\s+DE\s+LA\s+SALLE\s*[:\-]?\s*(.+?)$", text)),

            // "Responsable" suivi du nom
            Responsable = Clean(Get(@"[Rr]esponsable\s*[:\-]\s*(.+?)$",        text)),
        };
    }

    // ── Génération du PDF complété ────────────────────────────────────────────

    public static void Generate(
        string      inputPath,
        string      outputPath,
        decimal     peage,
        decimal     nbKm,
        decimal     totalFrais,
        string?     signatureImagePath,
        string?     rapportAccueil,
        string?     rapportEquipement,
        string?     opposant,
        string?     date,
        string?     heure,
        string?     adresse,
        string?     responsable,
        AppSettings cfg)
    {
        // Cree le dossier de destination si necessaire
        string? outDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outDir))
            Directory.CreateDirectory(outDir);

        // SetUnethicalReading : contourne les restrictions d'edition du PDF
        // (les convocations FFTT sont souvent protegees en ecriture)
        var readerProps = new ReaderProperties().SetPassword(null);
        using var reader = new PdfReader(inputPath, readerProps)
                               .SetUnethicalReading(true);
        using var writer = new PdfWriter(outputPath);
        using var pdfDoc = new PdfDocument(reader, writer);

        // -- Etape 1 : effacer les zones pre-imprimees avec un rectangle blanc ----
        var page   = pdfDoc.GetPage(cfg.Page);
        var canvas = new PdfCanvas(page);

        canvas.SetFillColor(cfg.RectanglesVisibles ? ColorConstants.LIGHT_GRAY : ColorConstants.WHITE);

        // Efface une zone a partir de la position configuree.
        // La largeur est lue depuis pos.Largeur (configurable dans Positions PDF).
        // Hauteur = taille de police + marges haut/bas (3 pt de chaque cote).
        void EraseField(FieldPos pos)
        {
            canvas.Rectangle(new iText.Kernel.Geom.Rectangle(pos.X - 3f, pos.Y - 3f, pos.Largeur, pos.Hauteur)).Fill();
        }

        EraseField(cfg.Peage);
        EraseField(cfg.NbKm);
        EraseField(cfg.TotalFrais);
        EraseField(cfg.RapportAccueil);
        EraseField(cfg.RapportEquipement);
        if (!string.IsNullOrWhiteSpace(opposant))    EraseField(cfg.CompOpposant);
        if (!string.IsNullOrWhiteSpace(date))        EraseField(cfg.CompDate);
        if (!string.IsNullOrWhiteSpace(heure))       EraseField(cfg.CompHeure);
        if (!string.IsNullOrWhiteSpace(adresse))     EraseField(cfg.CompAdresse);
        if (!string.IsNullOrWhiteSpace(responsable)) EraseField(cfg.CompResponsable);

        // Rectangle de positionnement de la signature (toujours gris clair quand visible)
        if (cfg.SignatureVisible)
        {
            canvas.SetFillColor(ColorConstants.LIGHT_GRAY);
            canvas.Rectangle(new iText.Kernel.Geom.Rectangle(cfg.SigX, cfg.SigY, cfg.SigW, cfg.SigH)).Fill();
        }

        canvas.Release();

        // -- Etape 2 : ecrire les nouvelles valeurs --------------------------------
        using var doc  = new Document(pdfDoc);
        var fontBold   = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        var fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        void PutText(FieldPos pos, string text, PdfFont font, float fontSize)
        {
            var para = new iText.Layout.Element.Paragraph(text)
                .SetFont(font)
                .SetFontSize(fontSize);
            doc.ShowTextAligned(para, pos.X, pos.Y, cfg.Page,
                TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);
        }

        // Tableau financier
        PutText(cfg.Peage,      peage.ToString("0.00", Fr)      + " EUR", fontBold,   10f);
        PutText(cfg.NbKm,       nbKm.ToString("0", Fr),                   fontBold,   10f);
        PutText(cfg.TotalFrais, totalFrais.ToString("0.00", Fr) + " EUR", fontBold,   10f);

        // Rapport JA (uniquement si renseigne)
        if (!string.IsNullOrWhiteSpace(rapportAccueil))
            PutText(cfg.RapportAccueil, rapportAccueil.Trim(), fontNormal, 9f);

        if (!string.IsNullOrWhiteSpace(rapportEquipement))
            PutText(cfg.RapportEquipement, rapportEquipement.Trim(), fontNormal, 9f);

        // Champs compétition
        if (!string.IsNullOrWhiteSpace(opposant))    PutText(cfg.CompOpposant,    opposant!.Trim(),    fontBold,   10f);
        if (!string.IsNullOrWhiteSpace(date))        PutText(cfg.CompDate,        date!.Trim(),        fontNormal, 10f);
        if (!string.IsNullOrWhiteSpace(heure))       PutText(cfg.CompHeure,       heure!.Trim(),       fontNormal, 10f);
        if (!string.IsNullOrWhiteSpace(adresse))     PutText(cfg.CompAdresse,     adresse!.Trim(),     fontNormal, 10f);
        if (!string.IsNullOrWhiteSpace(responsable)) PutText(cfg.CompResponsable, responsable!.Trim(), fontNormal, 10f);

        // Signature image
        if (signatureImagePath is { } sigPath && File.Exists(sigPath))
        {
            var img = new iText.Layout.Element.Image(ImageDataFactory.Create(sigPath));
            img.SetFixedPosition(cfg.Page, cfg.SigX, cfg.SigY);
            img.ScaleToFit(cfg.SigW, cfg.SigH);
            doc.Add(img);
        }
    }
}
