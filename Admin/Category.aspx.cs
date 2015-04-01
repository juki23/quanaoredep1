using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Category : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    public void loadData()
    {
        if (Session["pageCat"] == null)
        {
            if (Session["cate"] == null)
            {
                gvCategory.DataSource = qr.getAllCategory();
                gvCategory.DataBind();
            }
            else
            {
                gvCategory.DataSource = Session["cate"];
                gvCategory.DataBind();
            }
        }
        else
        {
            if (Session["cate"] == null)
            {
                gvCategory.DataSource = qr.getAllCategory();
                gvCategory.PageIndex = int.Parse(Session["pageCat"].ToString());
                gvCategory.DataBind();
            }
            else
            {
                gvCategory.DataSource = Session["cate"];
                gvCategory.PageIndex = int.Parse(Session["pageCat"].ToString());
                gvCategory.DataBind();
            }
        }
    }
    protected void gvCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = int.Parse(((Label)gvCategory.Rows[e.NewEditIndex].FindControl("lblidCate")).Text);
        Response.Redirect("Product.aspx?id=" + id);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CategoryList ls = new CategoryList();
        if (txtsearch.Text == "" || txtsearch.Text == null)
        {
            ls.getAllCate(qr.getAllCategory().ToList());
            Session["cate"] = ls;
            gvCategory.DataSource = Session["cate"];
            gvCategory.DataBind();
        }
        else
        {
            ls.getAllSearchCate(qr.searchnameCate(txtsearch.Text).ToList());
            Session["cate"] = ls;
            gvCategory.DataSource = Session["cate"];
            gvCategory.DataBind();
        }
    }
    protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = int.Parse(((Label)gvCategory.Rows[e.RowIndex].FindControl("lblidCate")).Text);
        int result = qr.deleteCategory(id);
        if (result == 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Xóa thành công.');</script>", false);
            loadData();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Xóa không được.');</script>", false);
            loadData();
        }
    }
    protected void gvCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = int.Parse(((Label)gvCategory.Rows[e.RowIndex].FindControl("lblidCate")).Text);
        Response.Redirect("EditCategory.aspx?idcate=" + id);
    }
    protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategory.PageIndex = e.NewPageIndex;
        Session["pageCat"] = e.NewPageIndex;
        if (Session["cate"] == null)
        {
            gvCategory.DataSource = qr.getAllCategory();
            gvCategory.DataBind();
        }
        else
        {
            gvCategory.DataSource = Session["cate"];
            gvCategory.DataBind();
        }
    }
    protected void gvCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int id = int.Parse(((Label)gvCategory.Rows[e.RowIndex].FindControl("lblidCate")).Text);
        if (qr.getbyidCate(id).activeCate == false)// kt xem neu activeCate == false(an~)
        {
            int result = qr.updateactiveCate(id, true);// update bt
            if (result == 1)
            {
                if (Session["cate"] != null)
                {
                    CategoryList ls = (CategoryList)Session["cate"];
                    foreach (var item in ls)
                    {
                        if (item.idCate == id)
                        {
                            item.activeCate = true;
                        }
                    }
                    Session["cate"] = ls;
                }
                loadData();
            }
        }
        else // nguoc lai activeCate == true(hien)
        {
            if (qr.getbyidCate(id).idRoot != null)
            {
                int result = qr.updateactiveCate(id, false);// update active danh muc do' = false 
                if (result == 1) // neu nhu update thanh cong
                {
                    if (Session["cate"] != null)
                    {
                        CategoryList ls = (CategoryList)Session["cate"];
                        foreach (var item in ls)
                        {
                            if (item.idCate == id)
                            {
                                item.activeCate = false;
                            }
                        }
                        Session["cate"] = ls;
                    }
                    int result1 = qr.updateactiveProbyCate(id, false);
                    if (result1 == 1)
                    {
                        loadData();
                    }
                }
            }
            else
            {
                int result = qr.updateactiveCate(id, false);
                if (result == 1)
                {
                    if (Session["cate"] != null)
                    {
                        CategoryList ls = (CategoryList)Session["cate"];
                        foreach (var item in ls)
                        {
                            if (item.idCate == id)
                            {
                                item.activeCate = false;
                            }
                        }
                        Session["cate"] = ls;
                    }
                    foreach (var item in qr.searchidrootCate(id))
                    {
                        int result1 = qr.updateactiveCate(item.idCate, false);
                        if (result1 == 1)
                        {
                            if (Session["cate"] != null)
                            {
                                CategoryList ls = (CategoryList)Session["cate"];
                                foreach (var item1 in ls)
                                {
                                    if (item1.idCate == item.idCate)
                                    {
                                        item1.activeCate = false;
                                    }
                                }
                                Session["cate"] = ls;
                            }
                            qr.updateactiveProbyCate(item.idCate, false);
                        }
                    }
                    loadData();
                }
            }
        }
    }
}