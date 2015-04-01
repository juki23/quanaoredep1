using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditInformation : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (true)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    txtcusname.Text = qr.getCusbyemail(Session["login"].ToString()).nameCus;
                    txtaddress.Text = qr.getCusbyemail(Session["login"].ToString()).address1;
                    txtphone.Text = qr.getCusbyemail(Session["login"].ToString()).phone.ToString();
                    ddlsex.SelectedValue = qr.getCusbyemail(Session["login"].ToString()).sex.ToString();
                    txtbirthday.Text = Convert.ToDateTime(qr.getCusbyemail(Session["login"].ToString()).birthday).ToShortDateString();
                }
            }
        }
    }
    protected void btnupdateCus_Click(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Today;
        if (txtcusname.Text == null || txtcusname.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập tên người dùng.');</script>", false);
        }
        else if (txtaddress.Text == null || txtaddress.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập địa chỉ.');</script>", false);
        }
        else if (txtbirthday.Text == null || txtbirthday.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập ngày sinh.');</script>", false);
        }
        else if (DateTime.TryParse(txtbirthday.Text, out dt) == false)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Ngày sinh bạn nhập chưa đúng.');</script>", false);
        }
        else if (txtphone.Text == null || txtphone.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập số điện thoại.');</script>", false);
        }
        else
        {
            if (Session["login"] != null)
            {
                int id = qr.getCusbyemail(Session["login"].ToString()).idCus;
                string email = qr.getCusbyemail(Session["login"].ToString()).email;
                string regisday = qr.getCusbyemail(Session["login"].ToString()).registerDate.ToString();
                string pass = qr.getCusbyemail(Session["login"].ToString()).password1;
                int result = qr.updateCustomer(id, txtcusname.Text, pass, email, txtaddress.Text, Convert.ToDateTime(txtbirthday.Text), int.Parse(txtphone.Text),
                    Convert.ToBoolean(ddlsex.SelectedValue), Convert.ToDateTime(regisday));
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Cập nhật thông tin thành công.');</script>", false);
                }
            }
        }
    }
}