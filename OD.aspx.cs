using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OD : System.Web.UI.Page
{
    QARDRepository qr = new QARDRepository();
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
                cart = Session["cart"] as DataTable;
                if (cart.Rows.Count > 0)
                {
                    txtdateBuy.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        if (Session["login"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        else
        {
            DateTime dt = DateTime.Today;
            if (DateTime.TryParse(txtDelivery.Text, out dt) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Ngày giao hàng không đúng.');</script>", false);
            }
            else
            {
                DataTable cart = new DataTable();
                cart = Session["cart"] as DataTable;
                if (cart.Rows.Count > 0)
                {
                    int id = qr.getCusbyemail(Session["login"].ToString()).idCus;
                    DateTime datebuy = DateTime.Parse(txtdateBuy.Text);
                    DateTime datedelivery = DateTime.Parse(txtDelivery.Text);
                    string notes = txtnote.Text;
                    qr.insertOrder(id, null, datebuy, datedelivery, notes, false, true);
                    int idO = 0;
                    foreach (var item in qr.getAllOrder().OrderByDescending(x => x.idOrder).Take(1))
                    {
                        idO = item.idOrder;
                    }
                    foreach (DataRow item in cart.Rows)
                    {
                        int idPro = int.Parse(item["idPro"].ToString());
                        int Quantity = int.Parse(item["Quantity"].ToString());
                        int price = int.Parse(item["price"].ToString());
                        qr.insertOderDetail(idO, idPro, price, Quantity);
                    }
                    //var bk = new BaoKimPayment();
                    //Session["idod"] = idO;
                    //String order_id = idO.ToString();//mã đơn hàng
                    //String business = "khiem132@gmail.com";//email bảo kim nhận tiền
                    //String total_amount = cart.Compute("Sum(totalcash)", "").ToString();
                    //String shipping_fee = "";//phí vận chuyển
                    //String tax_fee = "";//thuế khác
                    //String order_description = notes;//mo ta đơn hàng
                    //String url_success = "ODsucess.aspx";//url trả về khi thanh toán thành công
                    //String url_cancel = "";//url trả về khi thanh toán thất bại
                    //String url_detail = "";
                    //cart.Rows.Clear();
                    //Response.Redirect(bk.createRequestUrl(order_id, business, total_amount, shipping_fee, tax_fee, order_description, url_success, url_cancel, url_detail));



                    Response.Write("<script>alert('Bạn đã đặt hàng thành công.');window.location.href='Home.aspx'</script>");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
}