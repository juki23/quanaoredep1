using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        bool check = qr.checklogin(txtemail.Text, txtpassword.Text);
        if (check == true)
        {
            Session["login"] = txtemail.Text;
            Response.Redirect("Home.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Email hoặc mật khẩu không đúng.');</script>", false);
        }
    }
}