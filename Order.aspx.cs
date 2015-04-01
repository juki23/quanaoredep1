using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                gvOrderCus.DataSource = qr.getAllbyidCusOrder(qr.getCusbyemail(Session["login"].ToString()).idCus);
                gvOrderCus.DataBind();
            }
        }
    }
    protected void gvOrderCus_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Session["login"] != null)
        {
            int id = int.Parse(((Label)gvOrderCus.Rows[e.NewEditIndex].FindControl("lblidorder")).Text);
            Response.Redirect("OrderDetail.aspx?id=" + id);
        }
    }
    protected void gvOrderCus_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["login"] != null)
        {
            int id = int.Parse(((Label)gvOrderCus.Rows[e.RowIndex].FindControl("lblidorder")).Text);
            if (qr.searchOrder(id).active == true)
            {
                Response.Redirect("<script>alert('Hóa đơn đã thanh toán ko thể hủy.')</script>");
            }
            else
            {
                qr.updatestatusOrder(id, true);
                gvOrderCus.DataSource = qr.getAllbyidCusOrder(qr.getCusbyemail(Session["login"].ToString()).idCus);
                gvOrderCus.DataBind();
            }
        }
    }
}