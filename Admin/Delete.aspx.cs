using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertCustomer : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["idrg"] != null)
            {
                int result = qr.deleteRegisNews(int.Parse(Request.Params["idrg"]));
                if (result == 1)
                {
                    Response.Expires = -1;
                    Response.ContentType = "text/plain";
                    Response.Write("success");
                    Response.End();
                }
            }

        }
    }
}

