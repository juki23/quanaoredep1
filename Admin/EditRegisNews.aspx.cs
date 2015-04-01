using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditRegisNews : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = int.Parse(Request.QueryString["id"]);
            txtemail.Text = qr.searchidRegisnew(id).email;
        }
    }
    protected void btneditRegisnew_Click(object sender, EventArgs e)
    {
        if (txtemail.Text == null || txtemail.Text == "")
        {
            Response.Write("<script>alert('Bạn chưa nhập email')</script>");
        }
        else
        {
            if (qr.checkemailRegisnews(txtemail.Text))
            {
                int id = int.Parse(Request.QueryString["id"]);
                int result = qr.updateRegisNews(id, txtemail.Text);
                if (result == 1)
                {
                    if (Session["search"] != null)
                    {
                        RegisNewsList ls = (RegisNewsList)Session["search"];
                        foreach (var item in ls)
                        {
                            if (item.idRegisnew == id)
                            {
                                item.email = txtemail.Text;
                            }
                        }
                        Session["search"] = ls;
                    }
                    Response.Write("<script>alert('Sửa email thành công.')</script>");
                    Response.Redirect("RegisNews.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Sửa email thất bại.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Email của bạn đã tồn tại.')</script>");
                Response.Redirect("RegisNews.aspx");
            }
        }
    }
}