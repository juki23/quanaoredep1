using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSendPass_Click(object sender, EventArgs e)
    {
        if (qr.checkmail(txtforgotpass.Text) == false)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Email của bạn không đúng.');</script>", false);
        }
        else if (qr.getCusbyemail(txtforgotpass.Text) == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Email của bạn không tồn tại.');</script>", false);
        }
        else
        {
            string fromMail = "quanaoredep1@gmail.com";
            string toMail = txtforgotpass.Text;
            MailMessage mail = new MailMessage();
            mail.To.Add(toMail);
            mail.From = new MailAddress(fromMail);
            mail.Subject = "Administrator: This is your password for login page";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Hi " + txtforgotpass.Text + "!\n This is your password: " + qr.getCusbyemail(txtforgotpass.Text).password1;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password
            client.Credentials = new System.Net.NetworkCredential(fromMail, "Quanaoredep12");
            client.Port = 587; // Gmail works on this port<o:p />
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Mật khẩu đã đc gửi tới email của bạn.');</script>", false);
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
        }
    }
}