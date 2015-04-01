using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SendMail : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] != null)
            {
                string c = "";
                List<Regisnew> ls = (List<Regisnew>)Session["email"];
                foreach (Regisnew item in ls)
                {
                    c += item.email + ",";
                }
                txtEmail.Text = c.Substring(0, c.Length - 1);
            }
        }
    }
    protected void btnsendMail_Click(object sender, EventArgs e)
    {
        string fromMail = "quanaoredep1@gmail.com";
        string[] toMail = txtEmail.Text.Split(',');
        MailMessage mail = new MailMessage();
        foreach (string item in toMail)
        {
            mail.To.Add(new MailAddress(item));
        }
        mail.From = new MailAddress(fromMail);
        mail.Subject = txtSub.Text;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = ckeMessage.Text;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password
        client.Credentials = new System.Net.NetworkCredential(fromMail, "Quanaoredep12");
        client.Port = 587; // Gmail works on this port<o:p />
        client.Host = "smtp.gmail.com";
        client.Timeout = 10000;
        client.EnableSsl = true;
       
        try
        {
            client.Send(mail);
            Response.Write("<script>alert('Gửi mail thành công.')</script>");
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