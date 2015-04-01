using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrderDetail : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string query = Request.QueryString["id"];
            gvOrdersDetail.DataSource = qr.getAllbyidOrderOrdersdetail(int.Parse(query));
            gvOrdersDetail.DataBind();

            lbltotal.Text = qr.getAllbyidOrderOrdersdetail(int.Parse(query)).Select(x=>x.Price).Sum().ToString();
        }
    }
    protected void gvOrdersDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string query = Request.QueryString["id"];
        gvOrdersDetail.PageIndex = e.NewPageIndex;
        gvOrdersDetail.DataSource = qr.getAllbyidOrderOrdersdetail(int.Parse(query));
        gvOrdersDetail.DataBind();
    }
}