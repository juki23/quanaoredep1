using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            repproduct.DataSource = qr.getAllProduct().Where(x => x.activePro == true).Take(8);
            repproduct.DataBind();
        }
    }
    protected void btnaddEmail_Click(object sender, EventArgs e)
    {
        if (iptemail.Value == null || iptemail.Value == "")
        {
            lblerror.Text = "Bạn chưa nhập Email.";
            lblerror.ForeColor = System.Drawing.Color.Red;
        }
        else if (qr.checkmail(iptemail.Value) == false)
        {
            lblerror.Text = "Email của bạn không đúng.";
            lblerror.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            if (qr.checkemailRegisnews(iptemail.Value))
            {
                int resutl = qr.insertRegisNews(iptemail.Value);
                if (resutl == 1)
                {
                    lblerror.Text = "Thêm Email thành công.";
                    lblerror.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblerror.Text = "Thêm Email thất bại.";
                    lblerror.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblerror.Text = "Email của bạn đã được thêm.";
                lblerror.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}