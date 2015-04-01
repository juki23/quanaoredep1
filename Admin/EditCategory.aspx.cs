using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditCategory : System.Web.UI.Page
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
        string query = Request.QueryString["idcate"];
        ddlidRoot.DataSource = qr.getlsCategorynoroot(int.Parse(query)).Where(x => x.idRoot == null);
        ddlidRoot.DataTextField = "nameCate";
        ddlidRoot.DataValueField = "idCate";
        ddlidRoot.DataBind();

        txtnameCate.Text = qr.getbyidCate(int.Parse(query)).nameCate;
        ddlidRoot.SelectedValue = qr.getbyidCate(int.Parse(query)).idRoot.ToString();
        ckedetailCate.Text = qr.getbyidCate(int.Parse(query)).detailCate;
    }
    protected void btneditCate_Click(object sender, EventArgs e)
    {
        int result;
        string query = Request.QueryString["idcate"];
        if (txtnameCate.Text == null && txtnameCate.Text == "")
        {
            Response.Write("<script>alert('Bạn chưa nhập tên danh mục !!!')</script>");
        }
        else if (ddlidRoot.SelectedValue.Equals("-1"))
        {
            result = qr.updateCategorynoroot(int.Parse(query), txtnameCate.Text, ckedetailCate.Text, (bool)qr.getbyidCate(int.Parse(query)).activeCate);
            if (result == 1)
            {
                if (Session["cate"] != null)
                {
                    CategoryList ls = (CategoryList)Session["cate"];
                    foreach (var item in ls)
                    {
                        if (item.idCate == int.Parse(query))
                        {
                            item.nameCate = txtnameCate.Text;
                            item.detailCate = ckedetailCate.Text;
                        }
                    }
                    Session["cate"] = ls;
                }
                Response.Write("<script>alert('Sửa danh mục thành công !!!')</script>");
                Response.Redirect("Category.aspx");
            }
        }
        else if (!ddlidRoot.SelectedValue.Equals("-1"))
        {
            result = qr.updateCategory(int.Parse(query), txtnameCate.Text, int.Parse(ddlidRoot.SelectedValue), ckedetailCate.Text, (bool)qr.getbyidCate(int.Parse(query)).activeCate);
            if (result == 1)
            {
                if (qr.getbyidCate(int.Parse(ddlidRoot.SelectedValue)).activeCate == false)// neu danh muc dc chon co' active == fales thi:
                {
                    int result1 = qr.updateactiveCate(int.Parse(query), false);// update active ==  false cho danh muc dang dc sua~ 
                    if (result1 == 1)
                    {
                        qr.updateactiveProbyCate(int.Parse(query), false);// va` update active == false cho nhung san~ pham~ nao` co' danh muc dang dc sua~ lam` idCate
                    }
                }
                if (Session["cate"] != null)
                {
                    CategoryList ls = (CategoryList)Session["cate"];
                    foreach (var item in ls)
                    {
                        if (item.idCate == int.Parse(query))
                        {
                            item.nameCate = txtnameCate.Text;
                            item.idRoot = int.Parse(ddlidRoot.SelectedValue);
                            item.rootname = qr.getbyidCate(int.Parse(ddlidRoot.SelectedValue)).nameCate;
                            item.detailCate = ckedetailCate.Text;
                        }
                    }
                    Session["cate"] = ls;
                }
                Response.Write("<script>alert('Sửa danh mục thành công !!!')</script>");
                Response.Redirect("Category.aspx");
            }
        }
    }
}