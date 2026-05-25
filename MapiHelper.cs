/* MapiHelper.cs
 * Envoi d'un email avec pièce jointe via MAPI Windows.
 * Ouvre le client de messagerie par défaut de l'utilisateur avec le message
 * et la pièce jointe pré-remplis — l'utilisateur confirme l'envoi dans son client.
 *
 * Fonctionne avec : Outlook, Windows Mail / Outlook.com, Thunderbird (+MAPI plugin).
 * Sur Windows 10/11, MAPI32.DLL est présent même sans client mail installé
 * (stub 64-bit), mais une erreur est retournée si aucun client n'est configuré.
 */
using System.Runtime.InteropServices;

namespace OrdreMission;

public static class MapiHelper
{
    // ── P/Invoke ──────────────────────────────────────────────────────────────

    [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi, SetLastError = false)]
    private static extern int MAPISendMail(IntPtr session, IntPtr hwnd,
        ref MapiMsg message, uint flags, uint reserved);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct MapiMsg
    {
        public uint    Reserved;
        public string? Subject;
        public string? NoteText;
        public string? MessageType;
        public string? DateReceived;
        public string? ConversationID;
        public int     Flags;
        public IntPtr  Originator;
        public int     RecipCount;
        public IntPtr  Recips;
        public int     FileCount;
        public IntPtr  Files;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct MapiRecip
    {
        public uint    Reserved;
        public uint    RecipClass;  // 1 = MAPI_TO
        public string? Name;
        public string? Address;     // "SMTP:xxx@xxx.fr"
        public uint    EIDSize;
        public IntPtr  EntryID;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct MapiFile
    {
        public uint    Reserved;
        public uint    Flags;
        public int     Position;    // -1 = non inséré dans le corps
        public string? PathName;
        public string? FileName;
        public IntPtr  FileType;
    }

    private const uint MAPI_DIALOG   = 0x8;  // afficher l'UI du client mail
    private const uint MAPI_LOGON_UI = 0x1;  // autoriser la boîte de connexion

    // ── API publique ──────────────────────────────────────────────────────────

    /// <summary>
    /// Ouvre le client de messagerie par défaut avec le message et la PJ pré-remplis.
    /// L'utilisateur relise et confirme l'envoi dans son propre client mail.
    /// </summary>
    /// <param name="destinataireEmail">Adresse e-mail du destinataire.</param>
    /// <param name="destinataireNom">Nom affiché (peut être vide).</param>
    /// <param name="sujet">Sujet du message.</param>
    /// <param name="corps">Corps du message (texte brut).</param>
    /// <param name="cheminPj">Chemin complet de la pièce jointe.</param>
    /// <exception cref="InvalidOperationException">Si MAPI retourne une erreur.</exception>
    public static void OuvrirAvecPj(string destinataireEmail, string destinataireNom,
        string sujet, string corps, string cheminPj)
    {
        var recip = new MapiRecip
        {
            RecipClass = 1,
            Name       = string.IsNullOrWhiteSpace(destinataireNom) ? destinataireEmail : destinataireNom,
            Address    = "SMTP:" + destinataireEmail,
        };

        var file = new MapiFile
        {
            Position = -1,
            PathName = cheminPj,
            FileName = Path.GetFileName(cheminPj),
        };

        IntPtr recipPtr = Marshal.AllocHGlobal(Marshal.SizeOf<MapiRecip>());
        IntPtr filePtr  = Marshal.AllocHGlobal(Marshal.SizeOf<MapiFile>());

        try
        {
            Marshal.StructureToPtr(recip, recipPtr, false);
            Marshal.StructureToPtr(file,  filePtr,  false);

            var msg = new MapiMsg
            {
                Subject    = sujet,
                NoteText   = corps,
                RecipCount = 1,
                Recips     = recipPtr,
                FileCount  = 1,
                Files      = filePtr,
            };

            int ret = MAPISendMail(IntPtr.Zero, IntPtr.Zero, ref msg,
                                   MAPI_DIALOG | MAPI_LOGON_UI, 0);

            // 0 = SUCCESS · 1 = USER_ABORT (pas une erreur)
            if (ret != 0 && ret != 1)
                throw new InvalidOperationException(CodeErreur(ret));
        }
        finally
        {
            Marshal.FreeHGlobal(recipPtr);
            Marshal.FreeHGlobal(filePtr);
        }
    }

    // ── Traduction des codes d'erreur MAPI ────────────────────────────────────

    private static string CodeErreur(int code) => code switch
    {
        2  => "Le message n'a pas été envoyé (MAPI_E_FAILURE).",
        3  => "Aucun client de messagerie configuré (MAPI_E_LOGIN_FAILURE).",
        5  => "Trop de destinataires (MAPI_E_TOO_MANY_RECIPIENTS).",
        6  => "Pièce jointe introuvable (MAPI_E_INVALID_RECIPS).",
        8  => "Type de message inconnu (MAPI_E_UNKNOWN_RECIPIENT).",
        11 => "Le texte est trop long (MAPI_E_TEXT_TOO_LARGE).",
        14 => "Dépassement de la capacité du client mail (MAPI_E_INSUFFICIENT_MEMORY).",
        _  => $"Erreur MAPI inattendue (code {code})."
    };
}
