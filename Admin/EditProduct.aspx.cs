using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditProduct : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlcate.DataSource = qr.getlsCategory().Where(x => x.idRoot != null);
            ddlcate.DataTextField = "nameCate";
            ddlcate.DataValueField = "idCate";
            ddlcate.DataBind();

            int id = int.Parse(Request.QueryString["id"]);
            txtnamePro.Text = qr.searchbyidPro(id).namePro;
            txtprice.Text = qr.searchbyidPro(id).price.ToString();
            ckedetailPro.Text = qr.searchbyidPro(id).detailPro;
            ddlcate.SelectedValue = qr.searchbyidPro(id).idCate.ToString();

        }
    }
    protected void btneditPro_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["id"]);
        int a = 1;
        if (txtnamePro.Text == "" && txtnamePro.Text == null)
        {
            Response.Write("<script>alert('Bạn chưa nhập tên sản phẩm.')</script>");
        }
        else if (txtprice.Text == "" && txtprice.Text == null)
        {
            Response.Write("<script>alert('Bạn chưa nhập giá sản phẩm.')</script>");
        }
        else if (int.TryParse(txtprice.Text, out a) == false)
        {
            Response.Write("<script>alert('Giá sản phẩm phải là số nguyên.')</script>");
        }
        else if (int.TryParse(txtprice.Text, out a) && (int.Parse(txtprice.Text)) < 1)
        {
            Response.Write("<script>alert('Giá sản phẩm phải lớn hơn 0.')</script>");
        }
        else if (ddlcate.SelectedValue.Equals("-1"))
        {
            Response.Write("<script>alert('Bạn chưa chọn tên danh mục.')</script>");
        }
        else if (fuimgPro.FileName == "" || fuimgPro.FileName == null)
        {
            int result = qr.updateProduct(id, txtnamePro.Text, int.Parse(txtprice.Text), qr.searchbyidPro(id).img, ckedetailPro.Text,
               Convert.ToDateTime(qr.searchbyidPro(id).dateUp), (bool)qr.searchbyidPro(id).activePro, int.Parse(ddlcate.SelectedValue));
            if (result == 1)
            {
                if (qr.getbyidCate(int.Parse(ddlcate.SelectedValue)).activeCate == false)
                {
                    qr.updateactivePro(id, false);
                }
                if (Session["pro"] != null)
                {
                    ProductList ls = (ProductList)Session["pro"];
                    foreach (var item in ls)
                    {
                        if (item.idPro == id)
                        {
                            item.namePro = txtnamePro.Text;
                            item.price = int.Parse(txtprice.Text);
                            item.detailPro = ckedetailPro.Text;
                            item.idCate = int.Parse(ddlcate.SelectedValue);
                        }
                    }
                    Session["pro"] = ls;
                }
                Response.Redirect("Product.aspx");
            }
        }
        else
        {
            qr.deleteImage(qr.searchbyidPro(id).img);
            string filename = Path.GetFileName(fuimgPro.FileName);
            fuimgPro.SaveAs(MapPath("../Upload/") + filename);
            int result = qr.updateProduct(id, txtnamePro.Text, int.Parse(txtprice.Text), filename, ckedetailPro.Text, Convert.ToDateTime(qr.searchbyidPro(id).dateUp), (bool)qr.searchbyidPro(id).activePro, int.Parse(ddlcate.SelectedValue));
            if (result == 1)
            {
                if (qr.getbyidCate(int.Parse(ddlcate.SelectedValue)).activeCate == false)
                {
                    qr.updateactivePro(id, false);
                }
                if (Session["pro"] != null)
                {
                    ProductList ls = (ProductList)Session["pro"];
                    foreach (var item in ls)
                    {
                        if (item.idPro == id)
                        {
                            item.namePro = txtnamePro.Text;
                            item.price = int.Parse(txtprice.Text);
                            item.img = filename;
                            item.detailPro = ckedetailPro.Text;
                            item.idCate = int.Parse(ddlcate.SelectedValue);
                        }
                    }
                    Session["pro"] = ls;
                }
            }
            Response.Redirect("Product.aspx");
        }
    }
}