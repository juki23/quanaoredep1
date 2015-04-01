using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["search"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblkeysearch.Text = Session["search"].ToString();
                if (qr.searchnamePro(Session["search"].ToString()).Count() < 1)
                {
                    lblsearchnull.Visible = true;
                    divsearch.Visible = true;
                }
                else
                {
                    ccpro.DataSource = qr.searchnamePro(Session["search"].ToString());
                    ccpro.BindToControl = dtlproduct;
                    dtlproduct.DataSource = ccpro.DataSourcePaged;
                    dtlproduct.DataBind();

                    lblsearchnull.Visible = false;
                    divsearch.Visible = false;
                }
            }
        }
    }
}