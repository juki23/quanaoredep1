using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Order : System.Web.UI.Page
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
        if (Session["pageOrder"] == null)
        {
            if (query == null)
            {
                gvOrder.DataSource = qr.getAllOrder();
                gvOrder.DataBind();
            }
            else
            {
                gvOrder.DataSource = qr.getAllbyidCusOrder(int.Parse(query));
                gvOrder.DataBind();
            }
        }
        else
        {
            if (query == null)
            {
                gvOrder.DataSource = qr.getAllOrder();
                gvOrder.PageIndex = int.Parse(Session["pageOrder"].ToString());
                gvOrder.DataBind();
            }
            else
            {
                gvOrder.DataSource = qr.getAllbyidCusOrder(int.Parse(query));
                gvOrder.PageIndex = int.Parse(Session["pageOrder"].ToString());
                gvOrder.DataBind();
            }
        }

    }
    protected void gvOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int id = int.Parse(((Label)gvOrder.Rows[e.NewEditIndex].FindControl("lblidOrder")).Text);
        Response.Redirect("OrderDetail.aspx?id=" + id);
    }
    protected void ddlarrange_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = Request.QueryString["id"];
        if (query != null)
        {
            List<sp_selectbyidCusOrdersResult> lsid = new List<sp_selectbyidCusOrdersResult>();
            if (ddlarrange.SelectedValue.Equals("0"))
            {
                lsid = qr.getAllbyidCusOrder(int.Parse(query)).ToList();
                gvOrder.DataSource = qr.getAllbyidCusOrder(int.Parse(query));
                gvOrder.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("1"))
            {
                lsid = qr.getAllbyidCusOrder(int.Parse(query)).Where(x => x.active == true).ToList();
                gvOrder.DataSource = qr.getAllbyidCusOrder(int.Parse(query)).Where(x => x.active == true).ToList();
                gvOrder.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("2"))
            {
                lsid = qr.getAllbyidCusOrder(int.Parse(query)).Where(x => x.active == false).ToList();
                gvOrder.DataSource = qr.getAllbyidCusOrder(int.Parse(query)).Where(x => x.active == false).ToList();
                gvOrder.DataBind();
            }
            Session["order"] = lsid;
        }
        else
        {
            List<sp_selectallOrdersResult> ls = new List<sp_selectallOrdersResult>();
            if (ddlarrange.SelectedValue.Equals("0"))
            {
                ls = qr.getAllOrder().ToList();
                gvOrder.DataSource = qr.getAllOrder();
                gvOrder.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("1"))
            {
                ls = qr.getAllOrder().Where(x => x.active == true).ToList();
                gvOrder.DataSource = qr.getAllOrder().Where(x => x.active == true).ToList();
                gvOrder.DataBind();
            }
            else if (ddlarrange.SelectedValue.Equals("2"))
            {
                ls = qr.getAllOrder().Where(x => x.active == false).ToList();
                gvOrder.DataSource = qr.getAllOrder().Where(x => x.active == false).ToList();
                gvOrder.DataBind();
            }
            Session["order"] = ls;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string query = Request.QueryString["id"];
        if (txtsearch.Text == null || txtsearch.Text == "")
        {
            loadData();
            //if (query == null)
            //{
            //    List<sp_selectallOrdersResult> ls = new List<sp_selectallOrdersResult>();
            //    ls = qr.getAllOrder().ToList();
            //    Session["order"] = ls;
            //    gvOrder.DataSource = Session["order"];
            //    gvOrder.DataBind();
            //}
            //else
            //{
            //    List<sp_selectbyidCusOrdersResult> ls = new List<sp_selectbyidCusOrdersResult>();
            //    ls = qr.getAllbyidCusOrder(int.Parse(query)).ToList();
            //    Session["order"] = ls;
            //    gvOrder.DataSource = Session["order"];
            //    gvOrder.DataBind();
            //}
        }
        else
        {
            List<sp_searchcodesOrderResult> ls = new List<sp_searchcodesOrderResult>();
            if (query == null)
            {
                ls = qr.searchcodesOder(txtsearch.Text).ToList();
                Session["order"] = ls;
                gvOrder.DataSource = Session["order"];
                gvOrder.DataBind();
            }
            else
            {
                ls = qr.searchcodesOder(txtsearch.Text).Where(x => x.idCus == int.Parse(query)).ToList();
                Session["order"] = ls;
                gvOrder.DataSource = Session["order"];
                gvOrder.DataBind();
            }
        }
    }
    protected void gvOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = int.Parse(((Label)gvOrder.Rows[e.RowIndex].FindControl("lblidOrder")).Text);
        if (qr.searchOrder(id).active == true)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Hóa đơn đã thanh toán ko thể hủy.');</script>", false);
        }
        else
        {
            qr.updatestatusOrder(id, true);
            loadData();
        }
    }
    protected void gvOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = int.Parse(((Label)gvOrder.Rows[e.RowIndex].FindControl("lblidOrder")).Text);
        if (qr.searchOrder(id).status1 == true)
        {
            int result1 = qr.deleteOrderDetail(id);
            if (result1 == 1)
            {
                int result2 = qr.deleteOrder(id);
                if (result2 == 1)
                {
                    loadData();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Xóa không được.');</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Bạn chưa hủy hóa đơn.');</script>", false);
        }
    }
    protected void gvOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string query = Request.QueryString["id"];
        gvOrder.PageIndex = e.NewPageIndex;
        Session["pageOrder"] = e.NewPageIndex;
        if (Session["order"] == null)
        {
            loadData();
        }
        else
        {

            if (query != null)
            {
                gvOrder.DataSource = Session["order"] as List<sp_selectbyidCusOrdersResult>;
                gvOrder.DataBind();
            }
            else
            {
                gvOrder.DataSource = Session["order"] as List<sp_selectallOrdersResult>;
                gvOrder.DataBind();
            }
        }
    }
    protected void gvOrder_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        int id = int.Parse(((Label)gvOrder.Rows[e.RowIndex].FindControl("lblidOrder")).Text);
        if (qr.searchOrder(id).status1 != true)
        {
            int result = qr.updatepayment(id, true);
            if (result == 1)
            {
                loadData();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", "<script type=text/javascript> alert('Hóa đơn đã bị hủy.');</script>", false);
        }
    }
}