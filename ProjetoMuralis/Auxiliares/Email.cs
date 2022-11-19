using System.Net;
using System.Net.Mail;

namespace ProjetoMuralis.Auxiliares
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;
        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Enviar(string email, string asssunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };
                //Para quem vai ser enviado o e-mail
                mail.To.Add(email);
                //Assunto
                mail.Subject = asssunto;
               //configura corpo do e-mail
                mail.Body = mensagem;
               //Permição para passa codigos html para o email
                mail.IsBodyHtml = true;
                //Determinha a prioridade de envio ou se ja rapida
                mail.Priority = MailPriority.High;

                //Metodo para o envio do E-mail
                using(SmtpClient smtp = new SmtpClient())
                {
                    //Identifica as credenciais do e-mail como a senha e o email de acesso
                    smtp.Credentials = new NetworkCredential(username,senha);
                    //determina que o e-mail e seguro de ser enviado
                    smtp.EnableSsl = true;
                    //envia o email
                    smtp.Send(mail);
                    return true;
                }
            }
            catch(Exception erro)
            {
                //Gravar log de erro ao enviar e-mail
                return false;
            }
        }
    }
}
