using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderDetail : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                gvorderdetail.DataSource = qr.getAllbyidOrderOrdersdetail(id);
                gvorderdetail.DataBind();
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}