using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace PizzariaAPI.Services;

public class EmailService
{
    public async Task EnviarEmailAsync(string destinatario, string mensagem)
    {
        var assunto = "Solicitação de Alteração de Senha";
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("wesleysouza700@gmail.com"));
        email.To.Add(MailboxAddress.Parse(destinatario));
        email.Subject = assunto;
        email.Body = new TextPart("html") { Text = mensagem };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("wesleysouza700@gmail.com", "mlpz ahol cinb xtcg"); 
        await smtp.SendAsync(email);
        smtp.Disconnect(true);


    }

  public string GerarMensagemAlteracaoSenha(string nome, string email)
    {
        var linkAlteracaoSenha = $"https://martiniclayton.github.io/belapizza/alterarSenha.html?email={Uri.EscapeDataString(email)}";

        return $@"
        <html>
            <body style='font-family: Arial, sans-serif; background-color: #fff8f0; color: #333; padding: 20px;'>
                <div style='max-width: 600px; margin: auto; background-color: #fff; border-radius: 10px; padding: 30px; box-shadow: 0 4px 10px rgba(0,0,0,0.1);'>
                    <h1 style='color: #d35400; text-align: center;'>Pizzaria Bella Pizza 🍕</h1>
                    <h2 style='color: #e74c3c;'>Olá {nome},</h2>
                    <p>Recebemos sua solicitação de <strong>alteração de senha</strong>.</p>
                    <p>Clique no botão abaixo para redefinir sua senha de forma segura:</p>
    
                    <div style='text-align: center; margin: 30px 0;'>
                        <a href='{linkAlteracaoSenha}' style='
                            background-color: #e74c3c;
                            color: white;
                            padding: 14px 28px;
                            text-decoration: none;
                            font-size: 16px;
                            font-weight: bold;
                            border-radius: 8px;
                            display: inline-block;'>Redefinir Senha</a>
                    </div>
    
                    <p style='font-size: 14px; color: #555;'>
                        Se você não solicitou essa alteração, pode ignorar este e-mail. Sua conta continuará segura.
                    </p>
    
                    <hr style='margin: 30px 0; border: none; border-top: 1px solid #eee;' />
    
                    <p style='text-align: center; font-size: 12px; color: #999;'>
                        Obrigado por escolher a <strong>Pizzaria Bella Pizza</strong>!<br />
                        <em>Sabor que conquista desde a primeira fatia.</em>
                    </p>
                </div>
            </body>
        </html>";
    }


}
