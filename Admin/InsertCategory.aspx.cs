using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertCategory : System.Web.UI.Page
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
        ddlidRoot.DataSource = qr.getlsCategory().Where(x => x.idRoot == null);
        ddlidRoot.DataTextField = "nameCate";
        ddlidRoot.DataValueField = "idCate";
        ddlidRoot.DataBind();
    }
    protected void btnsaveCate_Click(object sender, EventArgs e)
    {
        if (txtnameCate.Text == "" || txtnameCate.Text == null)
        {
            Response.Write("<script>alert('Bạn chưa nhập tên danh mục !!!')</script>");
        }
        else
        {
            int result;
            if (ddlidRoot.SelectedValue.Equals("-1"))
            {
                result = qr.insertCategorynoroot(txtnameCate.Text, ckedetailCate.Text, cbactive.Checked);
                if (result == 1)
                {
                    if (Session["cate"] != null)
                    {
                        int idc = 0;
                        foreach (var item in qr.getAllCategory().OrderByDescending(x => x.idCate).Take(1))
                        {
                            idc = item.idCate;
                        }
                        Category1 ca = new Category1();
                        ca.idCate = idc;
                        ca.nameCate = txtnameCate.Text;
                        ca.activeCate = cbactive.Checked;
                        CategoryList ls = (CategoryList)Session["cate"];
                        ls.Insert(ls.Count, ca);
                        Session["cate"] = ls;
                    }
                    Response.Write("<script>alert('Thêm danh mục thành công !!!')</script>");
                    Response.Redirect("Category.aspx");
                }
            }
            else if (!ddlidRoot.SelectedValue.Equals("-1"))
            {
                result = qr.insertCategory(txtnameCate.Text, int.Parse(ddlidRoot.SelectedValue), ckedetailCate.Text, cbactive.Checked);
                if (result == 1)
                {
                    if (Session["cate"] != null)
                    {
                        int idc = 0;
                        foreach (var item in qr.getAllCategory().OrderByDescending(x => x.idCate).Take(1))
                        {
                            idc = item.idCate;
                        }
                        Category1 ca = new Category1();
                        ca.idCate = idc;
                        ca.nameCate = txtnameCate.Text;
                        ca.rootname = qr.getbyidCate(int.Parse(ddlidRoot.SelectedValue)).nameCate;
                        ca.activeCate = cbactive.Checked;
                        CategoryList ls = (CategoryList)Session["cate"];
                        ls.Insert(ls.Count, ca);
                        Session["cate"] = ls;
                    }
                    Response.Write("<script>alert('Thêm danh mục thành công !!!')</script>");
                    Response.Redirect("Category.aspx");
                }
            }
        }
    }
}