using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Information : System.Web.UI.Page
{
    QARDRepository rep = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["pageInfo"] == null)
            {
                if (Session["info"] != null)
                {
                    gvInfo.DataSource = Session["info"];
                    gvInfo.DataBind();
                }
                else
                {
                    gvInfo.DataSource = rep.getAllInformation();
                    gvInfo.DataBind();
                }
            }
            else
            {
                if (Session["info"] != null)
                {
                    gvInfo.DataSource = Session["info"];
                    gvInfo.PageIndex = int.Parse(Session["pageInfo"].ToString());
                    gvInfo.DataBind();
                }
                else
                {
                    gvInfo.DataSource = rep.getAllInformation();
                    gvInfo.PageIndex = int.Parse(Session["pageInfo"].ToString());
                    gvInfo.DataBind();
                }
            }
        }
    }
    protected void gvInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = int.Parse(((Label)gvInfo.Rows[e.NewEditIndex].FindControl("lblidInfo")).Text);
        Response.Redirect("EditInformation.aspx?id=" + id);
    }
    protected void gvInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = int.Parse(((Label)gvInfo.Rows[e.RowIndex].FindControl("lblidInfo")).Text);
        if (rep.searchidInfo(id).imgInfo != null)
        {
            rep.deleteImage(rep.searchidInfo(id).imgInfo);
        }
        rep.deletefollowrootInfo(id);
        gvInfo.DataSource = rep.getAllInformation();
        if (Session["pageInfo"] != null)
        {
            gvInfo.PageIndex = int.Parse(Session["pageInfo"].ToString());    
        }
        gvInfo.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        InformationList ls = new InformationList();
        if (txtsearch.Text == "" || txtsearch.Text == null)
        {
            ls.getAllInfo(rep.getAllInformation().ToList());
            Session["info"] = ls;
            gvInfo.DataSource = Session["info"];
            gvInfo.DataBind();
        }
        else if (!rdbsearchName.Checked && !rdbsearchDetail.Checked && txtsearch.Text != "")
        {
            Response.Write("<script>alert('Bạn chưa chọn mục để tiềm kiếm.')</script>");
        }
        else if (rdbsearchName.Checked)
        {
            ls.getAllSearchnameInfo(rep.searchnameInfo(txtsearch.Text).ToList());
            Session["info"] = ls;
            gvInfo.DataSource = Session["info"];
            gvInfo.DataBind();
        }
        else if (rdbsearchDetail.Checked)
        {
            ls.getAllSearchsearchdetailInfo(rep.searchbydetailInfo(txtsearch.Text).ToList());
            Session["info"] = ls;
            gvInfo.DataSource = Session["info"];
            gvInfo.DataBind();
        }
    }
    protected void gvInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInfo.PageIndex = e.NewPageIndex;
        Session["pageInfo"] = e.NewPageIndex;
        if (Session["info"] != null)
        {
            gvInfo.DataSource = Session["info"];
            gvInfo.DataBind();
        }
        else
        {
            gvInfo.DataSource = rep.getAllInformation();
            gvInfo.DataBind();
        }

    }
}