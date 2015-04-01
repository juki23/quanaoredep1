using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InsertInformation : System.Web.UI.Page
{
    QARDRepository rep = new QARDRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }

    protected void loadData()
    {
        ddlrootInfor.DataSource = rep.getListInfo();
        ddlrootInfor.DataTextField = "nameInfo";
        ddlrootInfor.DataValueField = "idInfo";
        ddlrootInfor.DataBind();
    }
    protected void btnsaveInfo_Click(object sender, EventArgs e)
    {
        if (txtnameInfo.Text == "" && txtnameInfo.Text == null)
        {
            Response.Write("<script>alert('Bạn chưa nhập tên thông tin.')</script>");
        }
        else if (rep.checkimg(fuimgInfo.FileName) == false && fuimgInfo.FileName != "")
        {
            Response.Write("<script>alert('Hình ảnh bạn chọn không đúng.')</script>");
        }
        else if (ddlrootInfor.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == true)
        {
            string filename = Path.GetFileName(fuimgInfo.FileName);
            fuimgInfo.SaveAs(MapPath("img/") + filename);
            int result = rep.insertInformationnoroot(txtnameInfo.Text, ckedetailInfo.Text, filename);
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    int idi = 0;
                    foreach (var item in rep.getAllInformation().OrderByDescending(x => x.idInfo).Take(1))
                    {
                        idi = item.idInfo;
                    }
                    Information1 in1 = new Information1();
                    in1.idInfo = idi;
                    in1.nameInfo = txtnameInfo.Text;
                    in1.imgInfo = filename;
                    InformationList ls = (InformationList)Session["info"];
                    ls.Insert(ls.Count, in1);
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Thêm thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }
        }
        else if (!ddlrootInfor.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == true)
        {
            string filename = Path.GetFileName(fuimgInfo.FileName);
            fuimgInfo.SaveAs(MapPath("img/") + filename);
            int result = rep.insertInformation(txtnameInfo.Text, ckedetailInfo.Text, filename, int.Parse(ddlrootInfor.SelectedValue));
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    int idi = 0;
                    foreach (var item in rep.getAllInformation().OrderByDescending(x => x.idInfo).Take(1))
                    {
                        idi = item.idInfo;
                    }
                    Information1 in1 = new Information1();
                    in1.idInfo = idi;
                    in1.nameInfo = txtnameInfo.Text;
                    in1.imgInfo = filename;
                    in1.rootname = rep.searchidInfo(int.Parse(ddlrootInfor.SelectedValue)).nameInfo;
                    InformationList ls = (InformationList)Session["info"];
                    ls.Insert(ls.Count, in1);
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Thêm thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }

        }
        else if (ddlrootInfor.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == false)
        {
            int result = rep.insertInformationnoroot(txtnameInfo.Text, ckedetailInfo.Text, null);
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    int idi = 0;
                    foreach (var item in rep.getAllInformation().OrderByDescending(x => x.idInfo).Take(1))
                    {
                        idi = item.idInfo;
                    }
                    Information1 in1 = new Information1();
                    in1.idInfo = idi;
                    in1.nameInfo = txtnameInfo.Text;
                    InformationList ls = (InformationList)Session["info"];
                    ls.Insert(ls.Count, in1);
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Thêm thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }
        }
        else if (!ddlrootInfor.SelectedValue.Equals("-1") && rep.checkimg(fuimgInfo.FileName) == false)
        {
            int result = rep.insertInformation(txtnameInfo.Text, ckedetailInfo.Text, null, int.Parse(ddlrootInfor.SelectedValue));
            if (result == 1)
            {
                if (Session["info"] != null)
                {
                    int idi = 0;
                    foreach (var item in rep.getAllInformation().OrderByDescending(x => x.idInfo).Take(1))
                    {
                        idi = item.idInfo;
                    }
                    Information1 in1 = new Information1();
                    in1.idInfo = idi;
                    in1.nameInfo = txtnameInfo.Text;
                    in1.rootname = rep.searchidInfo(int.Parse(ddlrootInfor.SelectedValue)).nameInfo;
                    InformationList ls = (InformationList)Session["info"];
                    ls.Insert(ls.Count, in1);
                    Session["info"] = ls;
                }
                Response.Write("<script>alert('Thêm thông tin thành công.')</script>");
                Response.Redirect("Information.aspx");
            }
            Response.Write("<script>alert('Thêm thông tin thành công.')</script>");
            Response.Redirect("Information.aspx");
        }
    }
}