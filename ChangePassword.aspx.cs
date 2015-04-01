using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
    protected void btnchangePass_Click(object sender, EventArgs e)
    {
        if (Session["Login"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        else
        {
            string email = Session["Login"].ToString();
            if (txtpass1.Text == null || txtpass1.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập mật khẩu hiện tại.');</script>", false);
            }
            else if (txtpass2.Text == null || txtpass2.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập mật khẩu mới.');</script>", false);
            }
            else if (txtpass3.Text == null || txtpass3.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa xác nhận mật khẩu mới.');</script>", false);
            }
            else if (txtpass2.Text.Length < 7 || txtpass2.Text.Length >= 16)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Mật khẩu của bạn phải dài từ 8 đến 16 ký tự.');</script>", false);
            }
            else if (txtpass1.Text != qr.getCusbyemail(email).password1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Mật khẩu hiện tại của bạn chưa đúng.');</script>", false);
            }
            else if (txtpass2.Text != txtpass3.Text)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Xác nhận mật khẩu mới không đúng.');</script>", false);
            }
            else
            {
                int id = qr.getCusbyemail(email).idCus;
                string nameCus = qr.getCusbyemail(email).nameCus;
                string address = qr.getCusbyemail(email).address1;
                DateTime birth = (DateTime)qr.getCusbyemail(email).birthday;
                int phone = int.Parse(qr.getCusbyemail(email).phone.ToString());
                bool sex = (bool)qr.getCusbyemail(email).sex;
                DateTime regisday = (DateTime)qr.getCusbyemail(email).registerDate;
                int result = qr.updateCustomer(id, nameCus, txtpass2.Text, email, address, birth, phone, sex, regisday);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Thay đổi mật khẩu thành công.');</script>", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Không thay đổi được.');</script>", false);
                }
            }
        }
    }
}