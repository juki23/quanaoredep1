using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MasterAD : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblusername.Text = Session["Username"].ToString();
            }
        }
    }
    protected void lbtlogout_Click(object sender, EventArgs e)
    {
        Session["Username"] = null;
        Response.Redirect("Login.aspx");
    }
}
