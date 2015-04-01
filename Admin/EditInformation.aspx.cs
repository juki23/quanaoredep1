using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditInformation : System.Web.UI.Page
{
    QARDRepository rep = new QARDRepository();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = int.Parse(Request.QueryString["id"]);
            ddlidRoot.DataSource = rep.getListInfonoroot(id);
            ddlidRoot.DataTextField = "nameInfo";
            ddlidRoot.DataValueField = "idInfo";
            ddlidRoot.DataBind();

            var q = rep.searchidInfo(id);
            txtnameInfo.Text = q.nameInfo;
            ddlidRoot.SelectedValue = q.idRoot.ToString();
            ckedetailInfo.Text = q.detailInfo;
        }
    }
    protected void btneditInfo_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["id"]);

        if (txtnameInfo.Text == "" && txtnameInfo.Text == null)
        {
            Response.Write("<script>alert('Tên thông tin chưa nhập !!!')</script>");
        }
        else if (rep.checkimg(fuimgInfo.FileName) == false && fuimgInfo.FileName != "")
        {
            Response.Write("<script>alert('Hình ảnh không đúng !!!')</script>");
        }
        else if (ddlidRoot.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == true)
        {
            string filename = Path.GetFileName(fuimgInfo.FileName);
            fuimgInfo.SaveAs(MapPath("../Upload/") + filename);
            rep.deleteImage(rep.searchidInfo(id).imgInfo);
            int result = rep.updateInformationnoroot(id, txtnameInfo.Text, ckedetailInfo.Text, filename);
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    InformationList ls = (InformationList)Session["info"];
                    foreach (var item in ls)
                    {
                        if (item.idInfo == id)
                        {
                            item.nameInfo = txtnameInfo.Text;
                            item.detailInfo = ckedetailInfo.Text;
                            item.idRoot = int.Parse(ddlidRoot.SelectedValue);
                            item.rootname = rep.searchidInfo(int.Parse(ddlidRoot.SelectedValue)).nameInfo;
                        }
                    }
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Sửa thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }
        }
        else if (!ddlidRoot.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == true)
        {
            string filename = Path.GetFileName(fuimgInfo.FileName);
            fuimgInfo.SaveAs(MapPath("../Upload/") + filename);
            rep.deleteImage(rep.searchidInfo(id).imgInfo);
            int result = rep.updateInformation(id, txtnameInfo.Text, ckedetailInfo.Text, filename, int.Parse(ddlidRoot.SelectedValue));
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    InformationList ls = (InformationList)Session["info"];
                    foreach (var item in ls)
                    {
                        if (item.idInfo == id)
                        {
                            item.nameInfo = txtnameInfo.Text;
                            item.detailInfo = ckedetailInfo.Text;
                            item.imgInfo = filename;
                            item.idRoot = int.Parse(ddlidRoot.SelectedValue);
                        }
                    }
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Sửa thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }

        }
        else if (ddlidRoot.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == false)
        {
            var q = rep.searchidInfo(id);
            int result = rep.updateInformationnoroot(id, txtnameInfo.Text, ckedetailInfo.Text, q.imgInfo);
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    InformationList ls = (InformationList)Session["info"];
                    foreach (var item in ls)
                    {
                        if (item.idInfo == id)
                        {
                            item.nameInfo = txtnameInfo.Text;
                            item.detailInfo = ckedetailInfo.Text;
                        }
                    }
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Sửa thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }
        }
        else if (!ddlidRoot.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == false)
        {
            var q = rep.searchidInfo(id);
            int result = rep.updateInformation(id, txtnameInfo.Text, ckedetailInfo.Text, q.imgInfo, int.Parse(ddlidRoot.SelectedValue));
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    InformationList ls = (InformationList)Session["info"];
                    foreach (var item in ls)
                    {
                        if (item.idInfo == id)
                        {
                            item.nameInfo = txtnameInfo.Text;
                            item.detailInfo = ckedetailInfo.Text;
                            item.idRoot = int.Parse(ddlidRoot.SelectedValue);
                        }
                    }
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Sửa thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }
        }
    }
}