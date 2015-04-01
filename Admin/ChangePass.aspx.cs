using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChangePass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        QARDRepository qr = new QARDRepository();
        if (qr.getDataAdmin().Password == txtpassword1.Text)
        {
            if (txtpassword2.Text == txtpassword3.Text)
            {
                if (txtpassword2.Text == qr.getDataAdmin().Password)
                {
                    Response.Write("<script>alert('Mật khẩu mới không đc giống mật khẩu cũ.')</script>");
                }
                else
                {
                    qr.updatePassAdmin(txtpassword2.Text);
                    Response.Write("<script>alert('Thay đổi mật khẩu thành công.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Mât khẩu mới không giống nhau.')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Bạn đã nhập sai mật khẩu hiện tại.')</script>");
        }
    }
}