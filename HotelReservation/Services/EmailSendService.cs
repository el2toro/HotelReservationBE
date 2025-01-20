using System.Net.Mail;
using System.Net;

namespace HotelReservation.Services;

public interface IEmailSendService
{
    Task SendEmail(string email);
}
public class EmailSendService : IEmailSendService
{
    public async Task SendEmail(string email)
    {
        // For testing purpose only
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("me001@gmail.com");
        mailMessage.To.Add("verify2@outlook.com");
        mailMessage.Subject = "Hello world";
        mailMessage.Body = "This is a test email sent using C#.Net";

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp-mail.outlook.com";
        smtpClient.Port = 587;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("verify2@outlook.com", "123456789");
        smtpClient.EnableSsl = true;

        try
        {
            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
