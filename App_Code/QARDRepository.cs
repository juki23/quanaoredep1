using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for QARDRepository
/// </summary>
public sealed class QARDRepository : IQARDRepository
{
    quanaoredepDataContext db = new quanaoredepDataContext();
    Serializer sr = new Serializer();
    #region Category
    public IList<sp_selectallCategoryResult> getAllCategory()
    {
        return (IList<sp_selectallCategoryResult>)db.sp_selectallCategory().ToList();
    }
    public IList<sp_selectallCategorynorootResult> getAllCategorynoroot(int idCate)
    {
        return (IList<sp_selectallCategorynorootResult>)db.sp_selectallCategorynoroot(idCate).ToList();
    }
    public IList<sp_selectallCategoryResult> getlsCategory()
    {
        IList<sp_selectallCategoryResult> ls = (IList<sp_selectallCategoryResult>)db.sp_selectallCategory().ToList();
        ls.Insert(0, new sp_selectallCategoryResult() { idCate = -1, nameCate = "Chọn danh mục" });
        return ls;
    }
    public IList<sp_selectallCategorynorootResult> getlsCategorynoroot(int idCate)
    {
        IList<sp_selectallCategorynorootResult> ls = (IList<sp_selectallCategorynorootResult>)db.sp_selectallCategorynoroot(idCate).ToList();
        ls.Insert(0, new sp_selectallCategorynorootResult() { idCate = -1, nameCate = "Chọn danh mục" });
        return ls;
    }
    public int insertCategory(string nameCate, int idRoot, string detailCate, bool active)
    {
        db.sp_insertCategory(nameCate, idRoot, detailCate, active);
        return 1;
    }
    public int insertCategorynoroot(string nameCate, string detailCate, bool active)
    {
        db.sp_insertCategorynoroot(nameCate, detailCate, active);
        return 1;
    }
    public int updateCategory(int idCate, string nameCate, int idRoot, string detailCate, bool active)
    {
        db.sp_updateCategory(idCate, nameCate, idRoot, detailCate, active);
        return 1;
    }
    public int updateCategorynoroot(int idCate, string nameCate, string detailCate, bool active)
    {
        db.sp_updateCategorynoroot(idCate, nameCate, detailCate, active);
        return 1;
    }
    public int deleteCategory(int idCate)
    {
        try
        {
            db.sp_deleteCategory(idCate);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public IList<sp_searchnameCateResult> searchnameCate(string nameCate)
    {
        return (IList<sp_searchnameCateResult>)db.sp_searchnameCate(nameCate).ToList();
    }
    public sp_searchbyIDCateResult getbyidCate(int idCate)
    {
        return (sp_searchbyIDCateResult)db.sp_searchbyIDCate(idCate).SingleOrDefault();
    }
    public int updateactiveCate(int idCate, bool activeCate)
    {
        try
        {
            db.sp_updateactiveCate(idCate, activeCate);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public int updateactiveCatebyidRoot(int idRoot, bool activeCate)
    {
        db.sp_updateactiveCatebyIdroot(idRoot, activeCate);
        return 1;
    }
    public IList<sp_searchbyidrootCateResult> searchidrootCate(int idRoot)
    {
        return (IList<sp_searchbyidrootCateResult>)db.sp_searchbyidrootCate(idRoot).ToList();
    }
    #endregion

    #region Product
    public IList<sp_selectallProductResult> getAllProduct()
    {
        return (IList<sp_selectallProductResult>)db.sp_selectallProduct().ToList();
    }
    public int insertProduct(string namePro, int price, string img, string detailPro, DateTime dateup, bool active, int idCate)
    {
        db.sp_insertProduct(namePro, price, img, detailPro, dateup, active, idCate);
        return 1;
    }
    public int updateProduct(int idPro, string namePro, int price, string img, string detailPro, DateTime dateup, bool active, int idCate)
    {
        try
        {
            db.sp_updateProduct(idPro, namePro, price, img, detailPro, dateup, active, idCate);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public int deleteProduct(int idPro)
    {
        try
        {
            db.sp_deleteProduct(idPro);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }

    }
    public IList<sp_searchnameProResult> searchnamePro(string namePro)
    {
        return (IList<sp_searchnameProResult>)db.sp_searchnamePro(namePro).ToList();
    }
    public sp_searchbyIDProductResult searchbyidPro(int idPro)
    {
        return (sp_searchbyIDProductResult)db.sp_searchbyIDProduct(idPro).SingleOrDefault();
    }
    public IList<sp_selectbyidCateProResult> getAllbyidCatePro(int idCate)
    {
        return (IList<sp_selectbyidCateProResult>)db.sp_selectbyidCatePro(idCate).ToList();
    }
    public IList<sp_getproductbyIdRootResult> getproductbyIdRoot(int idRoot)
    {
        return (IList<sp_getproductbyIdRootResult>)db.sp_getproductbyIdRoot(idRoot).ToList();
    }
    public int updateactiveProbyCate(int idCate, bool active)
    {
        db.sp_updateactiveProbyCate(idCate, active);
        return 1;
    }
    public int updateactivePro(int idPro, bool activePro)
    {
        db.sp_activeProduct(idPro, activePro);
        return 1;
    }
    #endregion

    #region Customer
    public IList<sp_selectallCustomerResult> getAllCustomer()
    {
        return (IList<sp_selectallCustomerResult>)db.sp_selectallCustomer().ToList();
    }
    public int insertCustomer(string nameCus, string password1, string email, string address1, DateTime birthday, int phone, bool sex, DateTime registerDate)
    {
        db.sp_insertCustomer(nameCus, password1, email, birthday, sex, address1, phone, registerDate);
        return 1;
    }
    public int updateCustomer(int idCus, string nameCus, string password1, string email, string address1, DateTime birthday, int phone, bool sex, DateTime registerDate)
    {
        db.sp_updateCustomer(idCus, nameCus, password1, email, birthday, sex, address1, phone, registerDate);
        return 1;
    }
    public int deleteCustomer(int idCus)
    {
        try
        {
            db.sp_deleteCustomer(idCus);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public IList<sp_searchnameCusResult> searchnameCus(string nameCus)
    {
        return (IList<sp_searchnameCusResult>)db.sp_searchnameCus(nameCus).ToList();
    }
    public bool checkemailCus(string email)
    {
        if (db.sp_checkemail(email) == 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool checklogin(string email, string pass)
    {

        if (db.sp_checklogin(email, pass) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public sp_selectCustomerbyemailResult getCusbyemail(string email)
    {
        return (sp_selectCustomerbyemailResult)db.sp_selectCustomerbyemail(email).SingleOrDefault();
    }
    #endregion

    #region Order
    public IList<sp_selectallOrdersResult> getAllOrder()
    {
        return (IList<sp_selectallOrdersResult>)db.sp_selectallOrders().ToList();
    }
    public IList<sp_selectbyidCusOrdersResult> getAllbyidCusOrder(int idCus)
    {
        return (IList<sp_selectbyidCusOrdersResult>)db.sp_selectbyidCusOrders(idCus).ToList();
    }
    public int insertOrder(int idCus, string codes, DateTime dateBuy, DateTime dateDelivery, string notes, bool active, bool status)
    {
        db.sp_insertOrders(idCus, codes, dateBuy, dateDelivery, notes, active, status);
        return 1;
    }
    public int updateOrder(int idOrder, int idCus, string codes, DateTime dateBuy, DateTime dateDelivery, string notes, bool active, bool status)
    {
        db.sp_updateOrders(idOrder, idCus, codes, dateBuy, dateDelivery, notes, active, status);
        return 1;
    }
    public int updatestatusOrder(int idOrder, bool status)
    {
        db.sp_updatestatusOrders(idOrder, status);
        return 1;
    }
    public int updatepayment(int idOrder, bool active)
    {
        db.sp_paymentsOrder(idOrder, active);
        return 1;
    }
    public int deleteOrder(int idOrder)
    {
        try
        {
            db.sp_deleteOrders(idOrder);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public sp_searchbyIDOrderResult searchOrder(int idOrder)
    {
        return (sp_searchbyIDOrderResult)db.sp_searchbyIDOrder(idOrder).SingleOrDefault();
    }
    public IList<sp_searchcodesOrderResult> searchcodesOder(string codes)
    {
        return (IList<sp_searchcodesOrderResult>)db.sp_searchcodesOrder(codes).ToList();
    }
    #endregion

    #region OrderDetail
    public IList<OrdersDetail> getAllOrderDetail()
    {
        return (IList<OrdersDetail>)db.sp_selectallOdersdetail();
    }
    public IList<sp_selectbyidOrderOdersdetailResult> getAllbyidOrderOrdersdetail(int idOrder)
    {
        return (IList<sp_selectbyidOrderOdersdetailResult>)db.sp_selectbyidOrderOdersdetail(idOrder).ToList();
    }
    //public IList<sp_searchbyIDOrdersDetailResult> getAllbyOderdetail(int idOrderdetail);
    public int insertOderDetail(int idOrder, int idPro, int price, int quantity)
    {
        db.sp_insertOrdersdetail(idOrder, idPro, price, quantity);
        return 1;
    }
    public int updateOrderDetail(int idOrderD, int idOrder, int idPro, int price, int quantity)
    {
        db.sp_updateOrdersdetail(idOrderD, idOrder, idPro, price, quantity);
        return 1;
    }
    public int deleteOrderDetail(int idOrderD)
    {
        try
        {
            db.sp_deleteOrdersdetail(idOrderD);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    #endregion

    #region Regisnews
    public IList<sp_selectallRegisnewsResult> getAllRegisNews()
    {
        return (IList<sp_selectallRegisnewsResult>)db.sp_selectallRegisnews().ToList();
    }
    public int insertRegisNews(string email)
    {
        db.sp_insertRegisnews(email);
        return 1;
    }
    public int updateRegisNews(int idRegisNews, string email)
    {
        db.sp_updateRegisnews(idRegisNews, email);
        return 1;
    }
    public int deleteRegisNews(int idRegisNews)
    {
        try
        {
            db.sp_deleteRegisnews(idRegisNews);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public IList<sp_searchEmailResult> searchEmail(string email)
    {
        return (IList<sp_searchEmailResult>)db.sp_searchEmail(email).ToList();
    }
    public sp_searchbyIDRegisNewResult searchidRegisnew(int idRegisNew)
    {
        return (sp_searchbyIDRegisNewResult)db.sp_searchbyIDRegisNew(idRegisNew).SingleOrDefault();
    }
    public bool checkemailRegisnews(string email)
    {
        if (db.sp_checkemailRegisnew(email).SingleOrDefault() == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Information
    public IList<sp_selectallInformationResult> getAllInformation()
    {
        return (IList<sp_selectallInformationResult>)db.sp_selectallInformation().ToList();
    }
    public IList<sp_selectallInformationnorootResult> getAllInformationnoroot(int idCate)
    {
        return (IList<sp_selectallInformationnorootResult>)db.sp_selectallInformationnoroot(idCate).ToList();
    }
    public int insertInformation(string nameInfo, string detailInfo, string imgInfo, int idRoot)
    {
        db.sp_insertInformation(nameInfo, detailInfo, imgInfo, idRoot);
        return 1;
    }
    public int insertInformationnoroot(string nameInfo, string detailInfo, string imgInfo)
    {
        db.sp_insertInformationnoroot(nameInfo, detailInfo, imgInfo);
        return 1;
    }
    public int updateInformation(int idInfo, string nameInfo, string detailInfo, string imgInfo, int idRoot)
    {
        db.sp_updateInformation(idInfo, nameInfo, detailInfo, imgInfo, idRoot);
        return 1;
    }
    public int updateInformationnoroot(int idInfo, string nameInfo, string detailInfo, string imgInfo)
    {
        db.sp_updateInformationnoroot(idInfo, nameInfo, detailInfo, imgInfo);
        return 1;
    }
    public int deleteInformation(int idInfo)
    {
        db.sp_deleteInformation(idInfo);
        return 1;
    }
    public int deletefollowrootInfo(int idInfo)
    {
        db.sp_deletefollowrootInfo(idInfo);
        return 1;
    }
    public IList<sp_searchnameInfoResult> searchnameInfo(string nameInfo)
    {
        return (IList<sp_searchnameInfoResult>)db.sp_searchnameInfo(nameInfo).ToList();
    }
    public IList<sp_searchbyDetailInfoResult> searchbydetailInfo(string detailInfo)
    {
        return (IList<sp_searchbyDetailInfoResult>)db.sp_searchbyDetailInfo(detailInfo).ToList();
    }
    public sp_searchbyIDInformationResult searchidInfo(int idInfo)
    {
        return (sp_searchbyIDInformationResult)db.sp_searchbyIDInformation(idInfo).SingleOrDefault();
    }
    public IList<sp_selectallInformationResult> getListInfo()
    {
        IList<sp_selectallInformationResult> ls = getAllInformation();
        ls.Insert(0, new sp_selectallInformationResult() { idInfo = -1, nameInfo = "Chọn thông tin" });
        return ls;
    }
    public IList<sp_selectallInformationnorootResult> getListInfonoroot(int idInfo)
    {
        IList<sp_selectallInformationnorootResult> ls = getAllInformationnoroot(idInfo);
        ls.Insert(0, new sp_selectallInformationnorootResult() { idInfo = -1, nameInfo = "Chọn thông tin" });
        return ls;
    }
    #endregion

    #region Admin
    public int loginAdmin(string username, string password)
    {
        UserAdmin ad = new UserAdmin();
        Object ob = sr.DeserializeObject(HttpContext.Current.Server.MapPath("../App_Data/UserAdmin.txt"), ad);
        ad = (UserAdmin)ob;
        if (ad.Username == username && ad.Password == password)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    public int updatePassAdmin(string password)
    {
        UserAdmin ad = new UserAdmin();
        Object ob = sr.DeserializeObject(HttpContext.Current.Server.MapPath("../App_Data/UserAdmin.txt"), ad);
        ad = (UserAdmin)ob;
        ad.Password = password;
        sr.SerializeObject(HttpContext.Current.Server.MapPath("../App_Data/UserAdmin.txt"), ad);
        return 1;
    }
    public UserAdmin getDataAdmin()
    {
        UserAdmin ad = new UserAdmin();
        Object ob = sr.DeserializeObject(HttpContext.Current.Server.MapPath("../App_Data/UserAdmin.txt"), ad);
        ad = (UserAdmin)ob;
        return ad;
    }
    #endregion

    public bool checkimg(string path)
    {
        string ext = Path.GetExtension(path);
        switch (ext.ToLower().Trim())
        {
            case ".png":
                return true;
            case ".gif":
                return true;
            case ".jpg":
                return true;
            case ".jpeg":
                return true;
            default:
                return false;
        }
    }
    public bool checkmail(string mail)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(mail);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public void deleteImage(string filename)
    {
        if (File.Exists(HttpContext.Current.Server.MapPath("../Upload/" + filename)))
        {
            File.Delete(HttpContext.Current.Server.MapPath("../Upload/" + filename));
        }
    }
    public int sendmail(string mailto, string mailfrom, string message, string subject)
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(mailto);
        mail.From = new MailAddress(mailfrom);
        mail.Subject = subject;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = message;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential(mailfrom, "Quanaoredep12");
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.Timeout = 10000;
        client.EnableSsl = true;

        try
        {
            client.Send(mail);
            return 1;
        }
        catch (Exception)
        {
            //Exception ex2 = ex;
            //string errorMessage = string.Empty;
            //while (ex2 != null)
            //{
            //    errorMessage += ex2.ToString();
            //    ex2 = ex2.InnerException;
            //}
            //HttpContext.Current.Response.Write(errorMessage);
            return 0;
        }
    }
}