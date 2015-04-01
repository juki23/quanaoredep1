using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    protected void loadData()
    {
        string query = Request.QueryString["id"];
        if (Session["pagePro"] == null)
        {
            if (query != null)
            {
                if (Session["pro"] == null)
                {
                    gvproduct.DataSource = qr.getAllbyidCatePro(int.Parse(query));
                    gvproduct.DataBind();
                }
                else
                {
                    gvproduct.DataSource = Session["pro"];
                    gvproduct.DataBind();
                }
            }
            else
            {
                if (Session["pro"] == null)
                {
                    gvproduct.DataSource = qr.getAllProduct().ToList();
                    gvproduct.DataBind();
                }
                else
                {
                    gvproduct.DataSource = Session["pro"];
                    gvproduct.DataBind();
                }
            }
        }
        else
        {
            if (query != null)
            {
                if (Session["pro"] == null)
                {
                    gvproduct.DataSource = qr.getAllbyidCatePro(int.Parse(query));
                    gvproduct.PageIndex = int.Parse(Session["pagePro"].ToString());
                    gvproduct.DataBind();
                }
                else
                {
                    gvproduct.DataSource = Session["pro"];
                    gvproduct.PageIndex = int.Parse(Session["pagePro"].ToString());
                    gvproduct.DataBind();
                }
            }
            else
            {
                if (Session["pro"] == null)
                {
                    gvproduct.DataSource = qr.getAllProduct().ToList();
                    gvproduct.PageIndex = int.Parse(Session["pagePro"].ToString());
                    gvproduct.DataBind();
                }
                else
                {
                    gvproduct.DataSource = Session["pro"];
                    gvproduct.PageIndex = int.Parse(Session["pagePro"].ToString());
                    gvproduct.DataBind();
                }
            }
        }
    }
    protected void gvproduct_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = int.Parse(((Label)gvproduct.Rows[e.NewEditIndex].FindControl("lblidpro")).Text);
        Response.Redirect("EditProduct.aspx?id=" + id);
    }
    protected void gvproduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = int.Parse(((Label)gvproduct.Rows[e.RowIndex].FindControl("lblidpro")).Text);
        if (qr.searchbyidPro(id).img != null)
        {
            qr.deleteImage(qr.searchbyidPro(id).img);
        }
        int result = qr.deleteProduct(id);
        if (result == 1)
        {
            loadData();
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Xóa thành công.');</script>", false);
        }
        else
        {
            loadData();
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Đã xảy ra lỗi, bạn nên kiểm tra lại.');</script>", false);
        }
    }
    protected void ddlarrange_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = Request.QueryString["id"];
        ProductList ls = new ProductList();
        if (query != null)
        {
            if (ddlarrange.SelectedValue.Equals("0"))
            {
                ls.getAllProbyidCate(qr.getAllbyidCatePro(int.Parse(query)).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("1"))
            {
                ls.getAllProbyidCate(qr.getAllbyidCatePro(int.Parse(query)).OrderBy(x => x.idPro).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("2"))
            {
                ls.getAllProbyidCate(qr.getAllbyidCatePro(int.Parse(query)).OrderBy(x => x.namePro).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("3"))
            {
                ls.getAllProbyidCate(qr.getAllbyidCatePro(int.Parse(query)).OrderBy(x => x.nameCate).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
        }
        else
        {

            if (ddlarrange.SelectedValue.Equals("0"))
            {
                ls.getAllPro(qr.getAllProduct().ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("1"))
            {
                ls.getAllPro(qr.getAllProduct().OrderBy(x => x.idPro).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("2"))
            {
                ls.getAllPro(qr.getAllProduct().OrderBy(x => x.namePro).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("3"))
            {
                ls.getAllPro(qr.getAllProduct().OrderBy(x => x.nameCate).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtsearch.Text == "" && txtsearch.Text == null)
        {
            loadData();
        }
        else
        {
            ProductList ls = new ProductList();
            string query = Request.QueryString["id"];
            if (query == null)
            {
                ls.getAllSearchPro(qr.searchnamePro(txtsearch.Text));
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }
            else
            {
                ls.getAllSearchPro(qr.searchnamePro(txtsearch.Text).Where(x => x.idCate == Int32.Parse(query)).ToList());
                Session["pro"] = ls;
                gvproduct.DataSource = Session["pro"];
                gvproduct.DataBind();
            }

        }
    }
    protected void gvproduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvproduct.PageIndex = e.NewPageIndex;
        Session["pagePro"] = e.NewPageIndex;
        if (Session["pro"] == null)
        {
            loadData();
        }
        else
        {
            gvproduct.DataSource = Session["pro"];
            gvproduct.DataBind();
        }
    }
    protected void gvproduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int idPro = int.Parse(((Label)gvproduct.Rows[e.RowIndex].FindControl("lblidpro")).Text);
        int idRoot = int.Parse(((Label)gvproduct.Rows[e.RowIndex].FindControl("lblidroot")).Text);
        if (qr.searchbyidPro(idPro).activePro == true)//neu active dc chuyen tu` hien sang an~
        {
            int result = qr.updateactivePro(idPro, false);// update bt
            if (result == 1)
            {
                if (Session["pro"] != null)
                {
                    ProductList ls = (ProductList)Session["pro"];
                    foreach (var item in ls)
                    {
                        if (item.idPro == idPro)
                        {
                            item.activePro = false;
                        }
                    }
                    Session["pro"] = ls;
                }
                Response.Redirect("Product.aspx");
            }
        }
        else // con` nguoc lai tu` an~ sang hien thi` kt
        {
            if (qr.getbyidCate(idRoot).activeCate == true) // neu ma` cai idRoot(idCate) ma` co' cai' active == true(hien)
            {
                int result = qr.updateactivePro(idPro, true); // update active bt
                if (result == 1)
                {
                    if (Session["pro"] != null)
                    {
                        ProductList ls = (ProductList)Session["pro"];
                        foreach (var item in ls)
                        {
                            if (item.idPro == idPro)
                            {
                                item.activePro = true;
                            }
                        }
                        Session["pro"] = ls;
                    }
                    Response.Redirect("Product.aspx");
                }
            }
            else// nguoc lai
            {
                Response.Write("<script>alert('Danh mục chứa sản phẩm chưa được hiển thị')</script>");// ko cho update vi` dm chua' sp chua dc active == true
            }
        }
    }
}