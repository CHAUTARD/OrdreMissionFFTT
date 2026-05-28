/* EmailService.cs
 * Envoi d'un email via SMTP en utilisant MailKit.
 * Les paramètres de connexion sont lus depuis AppSettings (SmtpHost, SmtpPort…).
 */
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace OrdreMission.CS;

public static class EmailService
{
    /// <summary>
    /// Envoie un email en texte brut via le serveur SMTP configuré dans AppSettings.
    /// </summary>
    /// <exception cref="InvalidOperationException">Si le serveur SMTP n'est pas configuré.</exception>
    /// <exception cref="MailKit.Net.Smtp.SmtpCommandException">En cas d'erreur SMTP.</exception>
    public static async Task EnvoyerAsync(
        AppSettings cfg,
        string destinataire,
        string sujet,
        string corps)
    {
        if (string.IsNullOrWhiteSpace(cfg.SmtpHost))
            throw new InvalidOperationException(
                "Serveur SMTP non configuré.\n" +
                "Renseignez les paramètres SMTP dans Outils > Paramètres.");

        // ── Construction du message ───────────────────────────────────────────
        var message = new MimeMessage();

        string adresseExp = string.IsNullOrWhiteSpace(cfg.SmtpFrom)
            ? cfg.SmtpUser
            : cfg.SmtpFrom;
        message.From.Add(MailboxAddress.Parse(adresseExp));
        message.To.Add(MailboxAddress.Parse(destinataire));
        message.Subject = sujet;
        message.Body    = new TextPart("plain") { Text = corps };

        // ── Connexion et envoi ────────────────────────────────────────────────
        using var client = new SmtpClient();

        SecureSocketOptions socketOpts = cfg.SmtpSsl
            ? SecureSocketOptions.SslOnConnect           // port 465
            : SecureSocketOptions.StartTlsWhenAvailable; // port 587

        await client.ConnectAsync(cfg.SmtpHost, cfg.SmtpPort, socketOpts);

        if (!string.IsNullOrWhiteSpace(cfg.SmtpUser))
            await client.AuthenticateAsync(cfg.SmtpUser, cfg.SmtpPassword);

        await client.SendAsync(message);
        await client.DisconnectAsync(quit: true);
    }
}
