using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Customer : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["pageCus"] == null)
            {
                if (Session["cus"] == null)
                {
                    gvCustomer.DataSource = qr.getAllCustomer();
                    gvCustomer.DataBind();
                }
                else
                {
                    gvCustomer.DataSource = Session["cus"];
                    gvCustomer.DataBind();
                }
            }
            else
            {
                if (Session["cus"] == null)
                {
                    gvCustomer.DataSource = qr.getAllCustomer();
                    gvCustomer.PageIndex = int.Parse(Session["pageCus"].ToString());
                    gvCustomer.DataBind();
                }
                else
                {
                    gvCustomer.DataSource = Session["cus"];
                    gvCustomer.PageIndex = int.Parse(Session["pageCus"].ToString());
                    gvCustomer.DataBind();
                }
            }
            ViewState["sort"] = 1;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CustomerList ls = new CustomerList();
        if (txtsearch.Text == "" || txtsearch.Text == null)
        {
            ls.getAllCus(qr.getAllCustomer().ToList());
            Session["cus"] = ls;
            gvCustomer.DataSource = Session["cus"];
            gvCustomer.DataBind();
        }
        else
        {
            ls.getAllSearch(qr.searchnameCus(txtsearch.Text).ToList());
            Session["cus"] = ls;
            gvCustomer.DataSource = Session["cus"];
            gvCustomer.DataBind();
        }
    }
    protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = int.Parse(((Label)gvCustomer.Rows[e.NewEditIndex].FindControl("lblidCus")).Text);
        Response.Redirect("Order.aspx?id=" + id);
    }
    protected void btnsort_Click(object sender, EventArgs e)
    {
        CustomerList ls = new CustomerList();
        if (ViewState["sort"].Equals(1))
        {
            ls.getAllCus(qr.getAllCustomer().OrderBy(x => x.nameCus).ToList());
            Session["cus"] = ls;
            gvCustomer.DataSource = Session["cus"];
            gvCustomer.DataBind();
            ViewState["sort"] = 0;
        }
        else
        {
            ls.getAllCus(qr.getAllCustomer().OrderByDescending(x => x.nameCus).ToList());
            Session["cus"] = ls;
            gvCustomer.DataSource = Session["cus"];
            gvCustomer.DataBind();
            ViewState["sort"] = 1;
        }
    }
    protected void gvCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomer.PageIndex = e.NewPageIndex;
        Session["pageCus"] = e.NewPageIndex;
        if (Session["cus"] == null)
        {
            gvCustomer.DataSource = qr.getAllCustomer();
            gvCustomer.DataBind();
        }
        else
        {
            gvCustomer.DataSource = Session["cus"];
            gvCustomer.DataBind();
        }
    }
}