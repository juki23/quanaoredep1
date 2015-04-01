using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowProducts : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ccpro.MaxPages = 1000;
            string query = Request.QueryString["idpro"];
            if (query == null)
            {
                ccpro.DataSource = qr.getAllProduct().Where(x => x.activePro == true).ToList();
                ccpro.BindToControl = dtlproduct;

                dtlproduct.DataSource = ccpro.DataSourcePaged;
                dtlproduct.DataBind();
            }
            else
            {
                lblnameCate.Text = qr.getbyidCate(int.Parse(query)).nameCate;
                lbldetailCate.Text = qr.getbyidCate(int.Parse(query)).detailCate;
                if (qr.getAllbyidCatePro(int.Parse(query)).Count > 0)
                {
                    ccpro.DataSource = qr.getAllbyidCatePro(int.Parse(query)).Where(x => x.activePro == true).ToList();
                    ccpro.BindToControl = dtlproduct;

                    dtlproduct.DataSource = ccpro.DataSourcePaged;
                    dtlproduct.DataBind();
                }
                else
                {
                    if (qr.getproductbyIdRoot(int.Parse(query)).Any())
                    {
                        ccpro.DataSource = qr.getproductbyIdRoot(int.Parse(query)).Where(x => x.activePro == true).ToList();
                        ccpro.BindToControl = dtlproduct;

                        dtlproduct.DataSource = ccpro.DataSourcePaged;
                        dtlproduct.DataBind();
                    }
                    else
                    {
                        lbltest.Text = "Hiện không có sản phẩm nào trong trang này";
                        lbltest.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F68236");
                    }
                }
            } 
        }
    }
    protected void dtlproduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "lbtcart")
        //{
        //    if (Session["login"] == null)
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //    else
        //    {
        //        DataTable cart = new DataTable();
        //        cart = Session["cart"] as DataTable;
        //        int id = int.Parse(((Label)e.Item.FindControl("lblidPro")).Text);
        //        string name = ((Label)e.Item.FindControl("lblnamePro")).Text;
        //        int price = int.Parse(((Label)e.Item.FindControl("lblprice")).Text);
        //        int quantity = 1;
        //        foreach (DataRow item in cart.Rows)
        //        {
        //            if ((int)item["idPro"] == id)
        //            {
        //                item["Quantity"] = (int)item["Quantity"] + 1;
        //                goto GioHang;
        //            }
        //        }
        //        cart.Rows.Add(id,name,price,quantity);
        //    GioHang:
        //        Session["cart"] = cart;
        //        Response.Write("<script>alert('Đã thêm vào giỏ hàng.')</script>");
        //    }
        //}
    }
}