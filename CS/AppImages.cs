/* AppImages.cs
 * Chargement des icônes embarquées (images/save.png, images/cancel.png).
 * Les ressources sont intégrées à l'EXE via <EmbeddedResource> dans le .csproj.
 * Le flux MemoryStream reste ouvert : Image.FromStream l'exige pendant toute la durée de vie.
 */
using System.Reflection;

namespace OrdreMission.CS;

public static class AppImages
{
    /// <summary>Icône disquette — boutons Enregistrer / Sauvegarder.</summary>
    public static Image? Save   { get; } = Charger("save.png");

    /// <summary>Icône annuler — boutons Annuler.</summary>
    public static Image? Cancel { get; } = Charger("cancel.png");

    // ── Chargement depuis les ressources embarquées ───────────────────────────

    private static Image? Charger(string nom)
    {
        var asm = Assembly.GetExecutingAssembly();
        using var src = asm.GetManifestResourceStream($"OrdreMission.images.{nom}");
        if (src is null) return null;

        // Copier dans un MemoryStream : Image.FromStream requiert le flux ouvert
        var ms = new MemoryStream();
        src.CopyTo(ms);
        ms.Position = 0;
        return Image.FromStream(ms);   // ms reste ouvert intentionnellement
    }

    // ── Helpers d'application sur les boutons ─────────────────────────────────

    /// <summary>
    /// Applique l'icône Save sur un bouton Enregistrer/Sauvegarder
    /// (image à gauche, texte à droite).
    /// </summary>
    public static void AppliquerSauvegarde(Button btn)
    {
        if (Save is null) return;
        btn.Image             = Save;
        btn.ImageAlign        = ContentAlignment.MiddleLeft;
        btn.TextImageRelation = TextImageRelation.ImageBeforeText;
        btn.Padding           = new Padding(6, 0, 0, 0);
    }

    /// <summary>
    /// Applique l'icône Cancel sur un bouton Annuler
    /// (image à gauche, texte à droite).
    /// </summary>
    public static void AppliquerAnnuler(Button btn)
    {
        if (Cancel is null) return;
        btn.Image             = Cancel;
        btn.ImageAlign        = ContentAlignment.MiddleLeft;
        btn.TextImageRelation = TextImageRelation.ImageBeforeText;
        btn.Padding           = new Padding(6, 0, 0, 0);
    }
}
