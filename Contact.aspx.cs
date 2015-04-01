using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btncontext_Click(object sender, EventArgs e)
    {
        if (iptname.Value == null || iptname.Value == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập tên.');</script>", false);
        }
        else if (iptemail.Value == null || iptemail.Value == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập Email.');</script>", false);
        }
        else if (qr.checkmail(iptemail.Value) == false)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập Email không đúng.');</script>", false);
        }
        else if (txamessage.InnerText == null || txamessage.InnerText == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập tin nhắn.');</script>", false);
        }
        else
        {
            int result = qr.sendmail("quanaoredep1@gmail.com", "quanaoredep1@gmail.com", txamessage.InnerText, iptname.Value + "[" + iptemail.Value + "]");
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Gửi tin nhắn thành công.');</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Gửi tin nhắn thất bại.');</script>", false);
            }
        }
    }
}