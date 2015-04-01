using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member : System.Web.UI.Page
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
                lblfullname.Text = qr.getCusbyemail(Session["login"].ToString()).nameCus;
                lblemail.Text = qr.getCusbyemail(Session["login"].ToString()).email;
                lbladdress.Text = qr.getCusbyemail(Session["login"].ToString()).address1;
                lblphone.Text = qr.getCusbyemail(Session["login"].ToString()).phone.ToString();
                lblbirth.Text = (Convert.ToDateTime(qr.getCusbyemail(Session["login"].ToString()).birthday)).ToShortDateString();
                lblregisday.Text = Convert.ToDateTime(qr.getCusbyemail(Session["login"].ToString()).registerDate).ToShortDateString();
                if (qr.getCusbyemail(Session["login"].ToString()).sex == true)
                {
                    lblsex.Text = "Nam";
                }
                else
                {
                    lblsex.Text = "Nử";
                }
            }
        }
    }
}