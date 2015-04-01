using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Today;
        int a = 1;
        if (txtcusname.Text == "" || txtcusname.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập họ tên.');</script>", false);
        }
        else if (txtaddress.Text == "" || txtaddress.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập địa chỉ.');</script>", false);
        }
        else if (txtemail.Text == "" || txtemail.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập email.');</script>", false);
        }
        else if (!qr.checkmail(txtemail.Text))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Email của bạn không đúng.');</script>", false);
        }
        else if (!qr.checkemailCus(txtemail.Text))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Email của bạn đã có người sử dụng.');</script>", false);
        }
        else if (txtbirthday.Text == "" || txtbirthday.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập ngày sinh.');</script>", false);
        }
        else if (DateTime.TryParse(txtbirthday.Text, out dt) == false)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Ngày tháng năm bạn nhập chưa đúng.');</script>", false);
        }
        else if (txtphone.Text == "" || txtphone.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập số điện thoại.');</script>", false);
        }
        else if (int.TryParse(txtphone.Text, out a) == false)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Số điện thoại phải là số.');</script>", false);
        }
        else if (txtphone.Text.Length > 11 || txtphone.Text.Length < 9)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Số điện thoại của bạn chỉ được dài từ 9 đến 11 số.');</script>", false);
        }
        else if (txtpass.Text == "" || txtpass.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập mật khẩu.');</script>", false);
        }
        else if (txtpass.Text.Length < 7 || txtpass.Text.Length >= 16)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Mật khẩu của bạn phải dài từ 8 đến 16 ký tự.');</script>", false);
        }
        else if (txtconfirmpass.Text == "" || txtconfirmpass.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập xác nhận mật khẩu.');</script>", false);
        }
        else if (txtpass.Text != txtconfirmpass.Text)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Xác nhận mật khẩu không chính xác.');</script>", false);
        }
        else
        {
            int result = qr.insertCustomer(txtcusname.Text, txtpass.Text, txtemail.Text, txtaddress.Text, DateTime.Parse(txtbirthday.Text),
                int.Parse(txtphone.Text), Convert.ToBoolean(ddlsex.SelectedValue), Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (result == 1)
            {
                if (cbnewletter.Checked)
                {
                    qr.insertRegisNews(txtemail.Text);
                }
                Session["login"] = txtemail.Text;
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Thêm tài khoản thành công.');</script>", false);
                Response.Redirect("Home.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Thêm tài khoản thất bại.');</script>", false);
            }
        }
    }
}