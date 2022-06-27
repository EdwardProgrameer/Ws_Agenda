using System.Net.Mail;
namespace Ws_Agenda.Helpers
{
    public class MailHerper
    {
        public static string SendMail( string user_email, string Token,string UrlDomain)
        {
            string EmailOrigen = "manuelarredondomaleno@gmail.com";
            string EmailPassword = "gpqjbjahgiheayja";
            string url =UrlDomain + "api/User/RecoveryPassword2/";

            MailMessage mailMessage = new MailMessage
                (EmailOrigen,user_email, "Recuperacion de contrasena",
                "<p>Correo para recuperacion de contrasena</p><br> "+"<a href = '"+url+"'>" +
                "Haga clikc para recupera su contrasena</a>");

            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, EmailPassword);
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
            return EmailOrigen;

        }
    }
}
