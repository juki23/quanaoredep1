using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailInfo : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string query = Request.QueryString["idinfo"];
            if (query == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                if (qr.searchidInfo(int.Parse(query)).imgInfo != null)
                {
                    imgInfo.Visible = true;
                    imgInfo.ImageUrl = "Upload/" + qr.searchidInfo(int.Parse(query)).imgInfo;
                }
                lblnameInfo.Text = qr.searchidInfo(int.Parse(query)).nameInfo;
                lbldetailInfo.Text = qr.searchidInfo(int.Parse(query)).detailInfo;
            }
        }
    }
}