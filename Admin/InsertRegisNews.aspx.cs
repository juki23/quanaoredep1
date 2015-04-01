using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertRegisNews : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsaveEmail_Click(object sender, EventArgs e)
    {
        if (txtemail.Text == null || txtemail.Text == "")
        {
            Response.Write("<script>alert('Bạn chưa nhập email.');window.location.href='InsertRegisNews.aspx';</script>");
        }
        else if (qr.checkmail(txtemail.Text) == false)
        {
            Response.Write("<script>alert('Email của bạn ko đúng.');window.location.href='InsertRegisNews.aspx';</script>");
        }
        else
        {
            if (qr.checkemailRegisnews(txtemail.Text))
            {
                int result = qr.insertRegisNews(txtemail.Text);
                if (result == 1)
                {
                    if (Session["search"] != null)
                    {
                        int idr = 0;
                        foreach (var item in qr.getAllRegisNews().OrderByDescending(x => x.idRegisnew).Take(1))
                        {
                            idr = item.idRegisnew;
                        }
                        Regisnew re = new Regisnew();
                        re.idRegisnew = idr;
                        re.email = txtemail.Text;
                        RegisNewsList ls = (RegisNewsList)Session["search"];
                        ls.Insert(ls.Count, re);
                        Session["search"] = ls;
                    }
                    Response.Write("<script>alert('Thêm Email Thành công.')</script>");
                    Response.Redirect("RegisNews.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Thêm Email Thất bại.');window.location.href='InsertRegisNews.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Email của bạn đã được thêm.')</script>");
                Response.Redirect("RegisNews.aspx");
            }
        }
    }
}