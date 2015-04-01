using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RegisNews : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["pageRe"] == null)
            {
                if (Session["search"] == null)
                {
                    gvregisnew.DataSource = qr.getAllRegisNews();
                    gvregisnew.DataBind();
                }
                else
                {
                    gvregisnew.DataSource = Session["search"];
                    gvregisnew.DataBind();
                }
            }
            else
            {
                if (Session["search"] == null)
                {
                    gvregisnew.DataSource = qr.getAllRegisNews();
                    gvregisnew.PageIndex = int.Parse(Session["pageRe"].ToString());
                    gvregisnew.DataBind();
                }
                else
                {
                    gvregisnew.DataSource = Session["search"];
                    gvregisnew.PageIndex = int.Parse(Session["pageRe"].ToString());
                    gvregisnew.DataBind();
                }
            }
            if (Request.Params["idcb"] != null)
            {
                Session["cb"] += Request.Params["idcb"] + ",";
            }
            else if (Request.Params["idecb"] != null)
            {
                string a = Request.Params["idecb"].ToString() + ",";
                string b = Session["cb"].ToString();
                string c = b.Replace(a, "");
                Session["cb"] = c;
            }
        }
    }
    protected void gvregisnew_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = int.Parse(((Label)gvregisnew.Rows[e.NewEditIndex].FindControl("lblemail")).Text);
        Response.Redirect("EditRegisNews.aspx?id=" + id);
    }

    //protected void cbselectall_CheckedChanged(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow rows in gvregisnew.Rows)
    //    {
    //        CheckBox cba = (CheckBox)sender;
    //        CheckBox cbx = (CheckBox)rows.Cells[0].FindControl("cbregisnew");
    //        if (cba.Checked)
    //        {
    //            cbx.Checked = true;
    //        }
    //        else
    //        {
    //            cbx.Checked = false;
    //        }
    //    }
    //}
    protected void btndeleteall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow rows in gvregisnew.Rows)
        {
            CheckBox cbx = (CheckBox)rows.Cells[0].FindControl("cbregisnew");
            if (cbx.Checked)
            {
                int id = int.Parse(((Label)rows.Cells[1].FindControl("lblidemail")).Text);
                qr.deleteRegisNews(id);
            }
        }
        gvregisnew.DataSource = qr.getAllRegisNews();
        gvregisnew.DataBind();
    }
    protected void gvregisnew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvregisnew.PageIndex = e.NewPageIndex;
        Session["pageRe"] = e.NewPageIndex;
        if (Session["search"] == null)
        {
            gvregisnew.DataSource = qr.getAllRegisNews();
            gvregisnew.PageIndex = int.Parse(Session["pageRe"].ToString());
            gvregisnew.DataBind();

        }
        else
        {
            gvregisnew.DataSource = Session["search"];
            gvregisnew.PageIndex = int.Parse(Session["pageRe"].ToString());
            gvregisnew.DataBind();
        }
        if (Session["cb"] != null)
        {
            string[] test = Session["cb"].ToString().TrimEnd(',').Split(',');
            foreach (var item in test)
            {
                var q = from a in test
                        where a == item
                        select a;
                foreach (GridViewRow rows in gvregisnew.Rows)
                {
                    int id = int.Parse(((Label)rows.Cells[1].FindControl("lblidemail")).Text);
                    CheckBox cb = (CheckBox)rows.Cells[0].FindControl("cbregisnew");
                    if (id == int.Parse(item))
                    {
                        if (q.Count() % 2 != 0)
                        {
                            cb.Checked = true;
                        }
                        else
                        {
                            cb.Checked = false;
                        }

                    }
                }
            }
        }
    }
    protected void btnsendmail_Click(object sender, EventArgs e)
    {
        List<Regisnew> ls = new List<Regisnew>();
        foreach (GridViewRow rows in gvregisnew.Rows)
        {
            CheckBox cbx = (CheckBox)rows.Cells[0].FindControl("cbregisnew");
            if (cbx.Checked)
            {
                Regisnew rg = new Regisnew();
                string email = ((Label)rows.Cells[1].FindControl("lblemail1")).Text;
                rg.email = email;
                ls.Add(rg);
            }
        }
        if (ls.Count > 0)
        {
            Session["email"] = ls;
            Response.Redirect("SendMail.aspx");
        }
        else
        {
            lbl.Text = "Bạn chưa chọn email nào.";
            lbl.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RegisNewsList lsrn = new RegisNewsList();
        if (txtsearch.Text == null || txtsearch.Text == "")
        {
            lsrn.getAll(qr.getAllRegisNews().ToList());
            Session["search"] = lsrn;
            gvregisnew.DataSource = Session["search"];
            gvregisnew.DataBind();
        }
        else
        {
            lsrn.getAllSearch(qr.searchEmail(txtsearch.Text).ToList());
            Session["search"] = lsrn;
            gvregisnew.DataSource = Session["search"];
            gvregisnew.DataBind();
        }
    }
}