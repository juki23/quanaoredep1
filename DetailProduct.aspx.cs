using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailProduct : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("ShowProduct.aspx");
            }
            else
            {
                imgPro.ImageUrl = "Upload/" + qr.searchbyidPro(int.Parse(id)).img;
                lblnamePro.Text = qr.searchbyidPro(int.Parse(id)).namePro;
                lblidPro.Text = qr.searchbyidPro(int.Parse(id)).idPro.ToString();
                lblprice.Text = qr.searchbyidPro(int.Parse(id)).price.ToString();
                lbldetailpro.Text = qr.searchbyidPro(int.Parse(id)).detailPro;
            }
        }
    }
    protected void btncart_Click(object sender, EventArgs e)
    {
        string idp = Request.QueryString["id"];
        int a = 1;
        if (Session["login"] == null)
        {
            Response.Write("<script>alert('Bạn phải đăng nhập rồi mới được mua hàng')</script>");
        }
        else if (int.TryParse(txtquantity.Text, out a) == false)
        {
            Response.Write("<script>alert('Số lượng bạn phải để kiểu số nguyên.')</script>");
        }
        else if (int.TryParse(txtquantity.Text, out a) && int.Parse(txtquantity.Text) < 1)
        {
            Response.Write("<script>alert('Số lượng bạn nhập phải lớn hơn 0.')</script>");
        }
        else if (qr.searchbyidPro(int.Parse(idp)).activePro == false)
        {
            Response.Write("<script>alert('Sản phẩm hiện chưa được bán.')</script>");
        }
        else
        {
            DataTable cart = new DataTable();
            cart = Session["cart"] as DataTable;
            int id = int.Parse(lblidPro.Text);
            string name = lblnamePro.Text;
            int price = int.Parse(lblprice.Text);
            int quantity = int.Parse(txtquantity.Text);
            foreach (DataRow item in cart.Rows)
            {
                if ((int)item["idPro"] == id)
                {
                    item["Quantity"] = (int)item["Quantity"] + quantity;
                    goto GioHang;
                }
            }
            cart.Rows.Add(id, name, price, quantity);
        GioHang:
            Session["cart"] = cart;
            Response.Write("<script>alert('Đã thêm vào giỏ hàng.')</script>");
        }
    }
    protected void btnbuy_Click(object sender, EventArgs e)
    {
        string idp = Request.QueryString["id"];
        int a = 1;
        if (Session["login"] == null)
        {
            Response.Write("<script>alert('Bạn phải đăng nhập rồi mới được mua hàng')</script>");
        }
        else if (int.TryParse(txtquantity.Text, out a) == false)
        {
            Response.Write("<script>alert('Số lượng bạn phải để kiểu số nguyên.')</script>");
        }
        else if (int.TryParse(txtquantity.Text, out a) && int.Parse(txtquantity.Text) < 1)
        {
            Response.Write("<script>alert('Số lượng bạn nhập phải lớn hơn 0.')</script>");
        }
        else if (qr.searchbyidPro(int.Parse(idp)).activePro == false)
        {
            Response.Write("<script>alert('Sản phẩm hiện chưa được bán.')</script>");
        }
        else
        {
            DataTable cart = new DataTable();
            cart = Session["cart"] as DataTable;
            int id = int.Parse(lblidPro.Text);
            string name = lblnamePro.Text;
            int price = int.Parse(lblprice.Text);
            int quantity = int.Parse(txtquantity.Text);
            foreach (DataRow item in cart.Rows)
            {
                if ((int)item["idPro"] == id)
                {
                    item["Quantity"] = (int)item["Quantity"] + quantity;
                    goto GioHang;
                }
            }
            cart.Rows.Add(id, name, price, quantity);
        GioHang:
            Session["cart"] = cart;
            Response.Redirect("Bascket.aspx");
        }
    }
}