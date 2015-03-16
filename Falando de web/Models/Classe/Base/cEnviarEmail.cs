using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public class cEnviarEmail
{
    private static void Enviar(string assunto, string msg)
    {
        WebClient web = new WebClient();
        string template = web.DownloadString("http://assets.falandodeweb.com.br/email/modelo.html");

        MailMessage mm = new MailMessage();

        mm.From = new MailAddress("email@empresa.com.br");
        mm.To.Add("email@empresa.com.br");

        mm.IsBodyHtml = true;
        mm.Subject = "Falando de Web - " + assunto;
        mm.Body = template.Replace("[MENSAGEM]", msg);

        SmtpClient smtp = new SmtpClient("smtp.empresa.com.br");
        smtp.Credentials = new NetworkCredential("email@empresa.com.br", "senha");
        smtp.Port = 587;
        smtp.EnableSsl = true;

        ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

        smtp.Send(mm);
        smtp.Dispose();
    }

    public static void Enviar(int tipo, int protocolo, string nome, string email, string telefone, string msg)
    {
        string t = "contato";

        if (tipo == 2)
            t = "alistamento";
        
        string html = "<p>Olá, <strong>Administrador</strong>.<br />";
        html += "Novo " + t + " através do site:</p>";
        html += "<ul>";
        html += "<li><strong>Protocolo: </strong>nº " + protocolo + "</li>";
        html += "<li><strong>Data: </strong>" + DateTime.Now + "</li>";
        html += "<li><strong>Nome: </strong>" + nome + "</li>";
        html += "<li><strong>E-mail: </strong>" + email + "</li>";
        html += "<li><strong>Telefone: </strong>" + telefone + "</li>";
        html += "<li><strong>Mensagem: </strong>" + msg + "</li>";
        html += "</ul>";

        Enviar(t, html);
    }
}