/* PdfService.cs
 */
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Filter;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Layout;
using iText.Layout.Properties;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace OrdreMission.CS;

/// <summary>Données de compétition lues depuis la convocation PDF.</summary>
public sealed class CompetitionInfo
{
    public string Opposant { get; init; } = "";
    public string Date { get; init; } = "";
    public string Heure { get; init; } = "";
    public string Adresse { get; init; } = "";
}

public static class PdfService
{
    private static readonly CultureInfo Fr = CultureInfo.GetCultureInfo("fr-FR");

    // ── Lecture des infos compétition depuis le PDF source ────────────────────

    /// <summary>
    /// Extrait le texte du PDF et en deduit les champs de la competition.
    /// Retourne un objet vide (chaines vides) en cas d'echec.
    /// </summary>
    public static CompetitionInfo ReadCompetitionInfo(string inputPath, AppSettings cfg)
    {
        try
        {
            var readerProps = new ReaderProperties().SetPassword(null);
            using var reader = new PdfReader(inputPath, readerProps).SetUnethicalReading(true);
            using var pdfDoc = new PdfDocument(reader);

            return ParseCompetitionInfo(pdfDoc, cfg);
        }
        catch
        {
            return new CompetitionInfo();
        }
    }

    // Extrait les champs de la competition depuis le texte brut du PDF
    private static string ExtractTextFromRegion(PdfDocument pdfDoc, int pageNum, FieldPos pos)
    {
        iText.Kernel.Geom.Rectangle rect = new iText.Kernel.Geom.Rectangle(pos.X, pos.Y, pos.Largeur, pos.Hauteur);
        TextRegionEventFilter filter = new TextRegionEventFilter(rect);

        ITextExtractionStrategy strategy = new FilteredTextEventListener(
            new LocationTextExtractionStrategy(),
            filter
        );

        return PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNum), strategy);
    }

    private static CompetitionInfo ParseCompetitionInfo(PdfDocument pdfDoc, AppSettings cfg)
    {
        return new CompetitionInfo
        {
            Opposant    = ExtractTextFromRegion(pdfDoc, cfg.Page, cfg.Opposant),
            Date        = ExtractTextFromRegion(pdfDoc, cfg.Page, cfg.Date),
            Heure       = ExtractTextFromRegion(pdfDoc, cfg.Page, cfg.Heure),
            Adresse     = ExtractTextFromRegion(pdfDoc, cfg.Page, cfg.Adresse)
        };
    }

    // ── Génération du PDF complété ────────────────────────────────────────────

    public static void Generate(
        string inputPath,
        string outputPath,
        decimal peage,
        decimal nbKm,
        decimal totalFrais,
        string? signatureImagePath,
        string? rapportAccueil,
        string? rapportEquipement,
        string? opposant,
        string? date,
        string? heure,
        string? adresse,
        AppSettings cfg)
    {
        // Cree le dossier de destination si necessaire
        string? outDir = System.IO.Path.GetDirectoryName(outputPath);
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
        var page = pdfDoc.GetPage(cfg.Page);
        var canvas = new PdfCanvas(page);

        /*
        for (int x = 0; x < 590; x += 100)
        {
            canvas.SetLineWidth(1)
                  .MoveTo(x, 0) // Point de départ (x, y)
                  .LineTo(x, 840) // Point d'arrivée
                  .Stroke();
        }

        for (int y = 0; y < 840; y += 100)
        {
            canvas.SetLineWidth(1)
                  .MoveTo(0, y) // Point de départ (x, y)
                  .LineTo(590, y) // Point d'arrivée
                  .Stroke();
        }
        */


        canvas.SetFillColor(cfg.RectanglesVisibles ? ColorConstants.LIGHT_GRAY : ColorConstants.WHITE);

        // Efface une zone a partir de la position configuree.
        // La largeur est lue depuis pos.Largeur (configurable dans Positions PDF).
        // Hauteur = taille de police + marges haut/bas (3 pt de chaque cote).
        void EraseField(FieldPos pos)
        {
            canvas.Rectangle(new iText.Kernel.Geom.Rectangle(pos.X - 3f, pos.Y - 3f, pos.Largeur, pos.Hauteur)).Fill();
        }

        EraseField(cfg.Opposant);
        EraseField(cfg.Date);
        EraseField(cfg.Heure);
        EraseField(cfg.Adresse);

        EraseField(cfg.Peage);
        EraseField(cfg.NbKm);
        EraseField(cfg.TotalFrais);
        EraseField(cfg.RapportAccueil);
        EraseField(cfg.RapportEquipement);

        // Rectangle de positionnement de la signature (toujours gris clair quand visible)
        if (cfg.SignatureVisible)
        {
            canvas.SetFillColor(ColorConstants.LIGHT_GRAY);
            canvas.Rectangle(new iText.Kernel.Geom.Rectangle(cfg.SigX, cfg.SigY, cfg.SigW, cfg.SigH)).Fill();
        }

        canvas.Release();

        // -- Etape 2 : ecrire les nouvelles valeurs --------------------------------
        using var doc = new Document(pdfDoc);
        var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        var fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        void PutText(FieldPos pos, string text, PdfFont font, float fontSize)
        {
            var para = new iText.Layout.Element.Paragraph(text)
                .SetFont(font)
                .SetFontSize(fontSize);
            doc.ShowTextAligned(para, pos.X, pos.Y, cfg.Page,
                TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);
        }

        // Champs compétition
        if (!string.IsNullOrWhiteSpace(opposant)) PutText(cfg.Opposant, opposant!.Trim(), fontBold, 10f);
        if (!string.IsNullOrWhiteSpace(date)) PutText(cfg.Date, date!.Trim(), fontNormal, 10f);
        if (!string.IsNullOrWhiteSpace(heure)) PutText(cfg.Heure, heure!.Trim(), fontNormal, 10f);
        if (!string.IsNullOrWhiteSpace(adresse)) PutText(cfg.Adresse, adresse!.Trim(), fontNormal, 10f);

        // Tableau financier
        PutText(cfg.Peage, peage.ToString("0.00", Fr) + " EUR", fontBold, 10f);
        PutText(cfg.NbKm, nbKm.ToString("0", Fr), fontBold, 10f);
        PutText(cfg.TotalFrais, totalFrais.ToString("0.00", Fr) + " EUR", fontBold, 10f);

        // Rapport JA (uniquement si renseigne)
        if (!string.IsNullOrWhiteSpace(rapportAccueil))
            PutText(cfg.RapportAccueil, rapportAccueil.Trim(), fontNormal, 9f);

        if (!string.IsNullOrWhiteSpace(rapportEquipement))
            PutText(cfg.RapportEquipement, rapportEquipement.Trim(), fontNormal, 9f);

        // Signature image
        if (signatureImagePath is { } sigPath && File.Exists(sigPath))
        {
            var img = new iText.Layout.Element.Image(ImageDataFactory.Create(sigPath));
            img.SetFixedPosition(cfg.Page, cfg.SigX, cfg.SigY);
            img.ScaleToFit(cfg.SigW, cfg.SigH);
            doc.Add(img);
        }

        // -- Etape 3 : fermer le document --------------------------------
        doc.Close();
    }
}