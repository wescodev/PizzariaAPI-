using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace PizzariaAPI.Services;

public class EmailService
{
    public async Task EnviarEmailAsync(string destinatario, string assunto, string mensagem)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("wesleysouza700@gmail.com"));
        email.To.Add(MailboxAddress.Parse(destinatario));
        email.Subject = assunto;
        email.Body = new TextPart("plain") { Text = mensagem };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("wesleysouza700@gmail.com", "mlpz ahol cinb xtcg"); 
        await smtp.SendAsync(email);
        smtp.Disconnect(true);


    }
}
