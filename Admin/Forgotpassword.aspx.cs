using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Forgotpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsendmail_Click(object sender, EventArgs e)
    {
        QARDRepository qr = new QARDRepository();
        string fromMail = "aptech.c1109g@gmail.com";
        string toMail = qr.getDataAdmin().Email;
        MailMessage mail = new MailMessage();
        mail.To.Add(toMail);
        mail.From = new MailAddress(fromMail);
        mail.Subject = "Administrator: This is your password for login page";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Hi " + qr.getDataAdmin().Username + "!\n This is your password: " + qr.getDataAdmin().Password;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password
        client.Credentials = new System.Net.NetworkCredential(fromMail, "c1109gvodoi");
        client.Port = 587; // Gmail works on this port<o:p />
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
        Response.Write("<script>alert('Mật khẩu đã đc gửi tới email của bạn.')</script>");
    }
}