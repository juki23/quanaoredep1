using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP_MasterTL : System.Web.UI.MasterPage
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] == null)
            {
                lbtlogin.Visible = true;
                lblmenber.Visible = false;
                lbtout.Visible = false;
            }
            else
            {
                lblmenber.Visible = true;
                lbtout.Visible = true;
                lbtlogin.Visible = false;
                lblmenber.Text = Session["login"].ToString();
            }

            repCate.DataSource = qr.getAllCategory().Where(x => x.activeCate == true);
            repCate.DataBind();

            repInfo.DataSource = qr.getAllInformation();
            repInfo.DataBind();

            repnewPro.DataSource = qr.getAllProduct().Where(x => x.activePro == true).OrderByDescending(x => x.dateUp).Take(5);
            repnewPro.DataBind();

            DataTable cart = new DataTable();
            if (Session["cart"] == null)
            {
                cart.Columns.Clear();
                cart.Columns.Add("idPro", typeof(int));
                cart.Columns.Add("namePro", typeof(string));
                cart.Columns.Add("price", typeof(int));
                cart.Columns.Add("Quantity", typeof(int));
                cart.Columns.Add("totalcash", typeof(int), "Quantity * price");

                Session["cart"] = cart;
            }
            else
            {
                cart = Session["cart"] as DataTable;
            }
        }
    }
    protected void lbtlogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void lblmenber_Click(object sender, EventArgs e)
    {
        Response.Redirect("Member.aspx");
    }
    protected void lbtout_Click(object sender, EventArgs e)
    {
        Session["login"] = null;
        Response.Redirect("Login.aspx");
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (iptsearch.Value == null || iptsearch.Value == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập từ khóa.');</script>", false);
        }
        else
        {
            Session["search"] = iptsearch.Value;
            Response.Redirect("SearchResult.aspx");
        }
    }
}
