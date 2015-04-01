using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bascket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                DataTable cart = new DataTable();
                cart = (DataTable)Session["cart"];
                if (cart.Rows.Count < 1)
                {
                    btnbuypro.Visible = false;
                    btndeletecart.Visible = false;
                    btnnext.Visible = false;
                    btnupdatecart.Visible = false;
                    lbltest.Visible = true;
                    lbltest.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f68236");
                    lbltest.Text = "Giỏ hàng của bạn hiện đang rỗng.";
                }
                else
                {
                    lbltotalcash.Text = "Tổng tiền: " + cart.Compute("Sum(totalcash)", "").ToString() + "K";
                }
                gvCart.DataSource = cart;
                gvCart.DataBind();
            }
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowProducts.aspx");
    }
    protected void btndeletecart_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["cart"];
        dt.Rows.Clear();
        Session["cart"] = dt;
        Response.Redirect("Bascket.aspx");
    }
    protected void btnupdatecart_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)Session["cart"];
            foreach (GridViewRow r in gvCart.Rows)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(((Label)r.Cells[0].FindControl("lblidPro")).Text) == int.Parse(dr["idPro"].ToString()))
                    {
                        TextBox t = (TextBox)r.Cells[3].FindControl("txtquantity");
                        if (Convert.ToInt32(t.Text) <= 0)
                            dt.Rows.Remove(dr);
                        else
                            dr["Quantity"] = t.Text;
                        break;
                    }
                }
            }
            Session["cart"] = dt;
            Response.Redirect("Bascket.aspx");
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Đã Phát Sinh Lỗi, Vui Lòng Kiểm Tra Lại.');</script>", false);
        }
    }
    protected void btnbuypro_Click(object sender, EventArgs e)
    {
        Response.Redirect("OD.aspx");
    }
    protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lbtdelete")
        {
            int num = int.Parse(e.CommandArgument.ToString());
            try
            {
                DataTable cart = (DataTable)Session["cart"];
                cart.Rows[num].Delete();
                Session["cart"] = cart;
                Response.Redirect("Bascket.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Đã có lỗi xin kiểm tra lại.');</script>", false);
            }
        }
    }
}