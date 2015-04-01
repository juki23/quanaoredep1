using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertProduct : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlcategory.DataSource = qr.getlsCategory().Where(x => x.idRoot != null);
            ddlcategory.DataTextField = "nameCate";
            ddlcategory.DataValueField = "idCate";
            ddlcategory.DataBind();
        }
    }
    protected void btnsavePro_Click(object sender, EventArgs e)
    {
        int a = 1;
        if (txtnamepro.Text == "" && txtnamepro.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập tên sản phẩm.');</script>", false);
        }
        else if (txtprice.Text == "" && txtprice.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa nhập giá sản phẩm.');</script>", false);
        }
        else if (int.TryParse(txtprice.Text, out a) == false)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Giá sản phẩm phải là số nguyên.');</script>", false);
        }
        else if (int.TryParse(txtprice.Text, out a) && (int.Parse(txtprice.Text)) < 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Giá sản phẩm phải lớn hơn 0.');</script>", false);
        }
        else if (ddlcategory.SelectedValue.Equals("-1"))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa chọn tên danh mục.');</script>", false);
        }
        else if (qr.getbyidCate(int.Parse(ddlcategory.SelectedValue)).activeCate == false && cbactive.Checked == true)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Danh mục bạn chọn chưa được hiển thị nên sản phẩm không cũng không được hiển thị.');</script>", false);
        }
        else
        {
            if (fuimgpro.FileName == null || fuimgpro.FileName == "")
            {
                int result = qr.insertProduct(txtnamepro.Text, int.Parse(txtprice.Text), null, ckeproduct.Text, Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    cbactive.Checked, int.Parse(ddlcategory.SelectedValue));
                if (result == 1)
                {
                    if (Session["pro"] != null)
                    {
                        int idp = 0;
                        foreach (var item in qr.getAllProduct().OrderByDescending(x => x.idPro).Take(1))
                        {
                            idp = item.idPro;
                        }
                        Product1 p = new Product1();
                        p.idPro = idp;
                        p.namePro = txtnamepro.Text;
                        p.price = int.Parse(txtprice.Text);
                        p.dateUp = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        p.activePro = cbactive.Checked;
                        p.nameCate = qr.getbyidCate(int.Parse(ddlcategory.SelectedValue)).nameCate;
                        ProductList ls = (ProductList)Session["pro"];
                        ls.Insert(ls.Count, p);
                        Session["pro"] = ls;
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Thêm sản phẩm thành công.');</script>", false);
                    Response.Redirect("Product.aspx");
                }
            }
            else
            {
                string filename = Path.GetFileName(fuimgpro.FileName);
                fuimgpro.SaveAs(MapPath("../Upload/") + filename);
                int result = qr.insertProduct(txtnamepro.Text, int.Parse(txtprice.Text), filename, ckeproduct.Text, Convert.ToDateTime(DateTime.Now.ToShortDateString()), cbactive.Checked, int.Parse(ddlcategory.SelectedValue));
                if (result == 1)
                {
                    if (Session["pro"] != null)
                    {
                        int idp = 0;
                        foreach (var item in qr.getAllProduct().OrderByDescending(x => x.idPro).Take(1))
                        {
                            idp = item.idPro;
                        }
                        Product1 p = new Product1();
                        p.idPro = idp;
                        p.namePro = txtnamepro.Text;
                        p.price = int.Parse(txtprice.Text);
                        p.img = filename;
                        p.dateUp = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        p.activePro = cbactive.Checked;
                        p.nameCate = qr.getbyidCate(int.Parse(ddlcategory.SelectedValue)).nameCate;
                        ProductList ls = (ProductList)Session["pro"];
                        ls.Insert(ls.Count, p);
                        Session["pro"] = ls;
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Thêm sản phẩm thành công.');</script>", false);
                    Response.Redirect("Product.aspx");
                }
            }
        }
    }
}