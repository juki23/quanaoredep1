using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Countlg"] = 0;
            //Serializer sr = new Serializer();
            //string load = HttpContext.Current.Server.MapPath("../App_Data/UserAdmin.txt");
            //UserAdmin ad = new UserAdmin();
            //ad.Username = "admin";
            //ad.Password = "admin";
            //ad.Email = "aptech.c1109g@gmail.com";
            //sr.SerializeObject(load, ad);
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int count = (int)ViewState["Countlg"];
        if (SampleCaptcha.Visible == false && CaptchaCodeTextBox.Visible == false)
        {
            int result = qr.loginAdmin(txtusername.Text, txtpassword.Text);
            if (result == 1)
            {
                Session["Username"] = txtusername.Text;
                Response.Redirect("Product.aspx");
            }
            else
            {
                count++;
                ViewState["Countlg"] = count;
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Tên đăng nhập hoặc mật khẩu không đúng.');</script>", false);
                if (count >= 3)
                {
                    SampleCaptcha.Visible = true;
                    CaptchaCodeTextBox.Visible = true;
                }
            }
        }
        else
        {
            bool isHuman = SampleCaptcha.Validate(CaptchaCodeTextBox.Text);
            int result = qr.loginAdmin(txtusername.Text, txtpassword.Text);
            SampleCaptcha.Visible = true;
            CaptchaCodeTextBox.Visible = true;
            if (isHuman && result == 1)
            {
                Session["Username"] = txtusername.Text;
                Response.Redirect("Product.aspx");
            }
            else if (!isHuman && result == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Mã captcha không đúng.');</script>", false);
            }
            else if (isHuman && result != 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Tên đăng nhập hoặc mật khẩu không đúng.');</script>", false);
            }
            else if (!isHuman && result != 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Tên đăng nhập hoặc mật khẩu không đúng.');</script>", false);
            }
        }
    }
}