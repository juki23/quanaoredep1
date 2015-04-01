using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IQARDRepository
/// </summary>
public interface IQARDRepository
{
    #region Category
    IList<sp_selectallCategoryResult> getAllCategory();
    IList<sp_selectallCategorynorootResult> getAllCategorynoroot(int idCate);
    IList<sp_selectallCategoryResult> getlsCategory();
    IList<sp_selectallCategorynorootResult> getlsCategorynoroot(int idCate);
    int insertCategory(string nameCate, int idRoot, string detailCate, bool active);
    int insertCategorynoroot(string nameCate, string detailCate, bool active);
    int updateCategory(int idCate, string nameCate, int idRoot, string detailCate, bool active);
    int updateCategorynoroot(int idCate, string nameCate, string detailCate, bool active);
    int deleteCategory(int idCate);
    IList<sp_searchnameCateResult> searchnameCate(string nameCate);
    sp_searchbyIDCateResult getbyidCate(int idCate);
    int updateactiveCate(int idCate, bool activeCate);
    int updateactiveCatebyidRoot(int idRoot,bool activeCate);
    IList<sp_searchbyidrootCateResult> searchidrootCate(int idRoot);
    #endregion

    #region Product
    IList<sp_selectallProductResult> getAllProduct();
    int insertProduct(string namePro, int price, string img, string detailPro, DateTime dateup, bool active, int idCate);
    int updateProduct(int idPro, string namePro, int price, string img, string detailPro, DateTime dateup, bool active, int idCate);
    int deleteProduct(int idPro);
    IList<sp_searchnameProResult> searchnamePro(string namePro);
    sp_searchbyIDProductResult searchbyidPro(int idPro);
    IList<sp_selectbyidCateProResult> getAllbyidCatePro(int idCate);
    IList<sp_getproductbyIdRootResult> getproductbyIdRoot(int idRoot);
    int updateactiveProbyCate(int idCate, bool active);
    int updateactivePro(int idPro,bool activePro);
    #endregion

    #region Customer
    IList<sp_selectallCustomerResult> getAllCustomer();
    int insertCustomer(string nameCus, string password1, string email, string address1, DateTime birthday, int phone, bool sex, DateTime registerDate);
    int updateCustomer(int idCus, string nameCus, string password1, string email, string address1, DateTime birthday, int phone, bool sex, DateTime registerDate);
    int deleteCustomer(int idCus);
    IList<sp_searchnameCusResult> searchnameCus(string nameCus);
    //sp_searchbyIDCustomerResult searchidCus(int idCus);
    bool checkemailCus(string email);
    bool checklogin(string email, string pass);
    sp_selectCustomerbyemailResult getCusbyemail(string email);
    
    #endregion

    #region Order
    IList<sp_selectallOrdersResult> getAllOrder();
    IList<sp_selectbyidCusOrdersResult> getAllbyidCusOrder(int idCus);
    int insertOrder(int idCus, string codes, DateTime dateBuy, DateTime dateDelivery, string notes, bool active, bool status);
    int updateOrder(int idOrder, int idCus, string codes, DateTime dateBuy, DateTime dateDelivery, string notes, bool active, bool status);
    int updatestatusOrder(int idOrder, bool status);
    int updatepayment(int idOrder,bool active);
    int deleteOrder(int idOrder);
    sp_searchbyIDOrderResult searchOrder(int idOrder);
    IList<sp_searchcodesOrderResult> searchcodesOder(string codes);
    
    #endregion

    #region OrderDetail
    IList<OrdersDetail> getAllOrderDetail();
    IList<sp_selectbyidOrderOdersdetailResult> getAllbyidOrderOrdersdetail(int idOrder);
    int insertOderDetail(int idOrder, int idPro, int price, int quantity);
    int updateOrderDetail(int idOrderD, int idOrder, int idPro, int price, int quantity);
    int deleteOrderDetail(int idOrderD);
    #endregion

    #region Regisnews
    IList<sp_selectallRegisnewsResult> getAllRegisNews();
    int insertRegisNews(string email);
    int updateRegisNews(int idRegisNews, string email);
    int deleteRegisNews(int idRegisNews);
    IList<sp_searchEmailResult> searchEmail(string email);
    sp_searchbyIDRegisNewResult searchidRegisnew(int idRegisNew);
    bool checkemailRegisnews(string email);
    #endregion

    #region Information
    IList<sp_selectallInformationResult> getAllInformation();
    IList<sp_selectallInformationnorootResult> getAllInformationnoroot(int idCate);
    int insertInformation(string nameInfo, string detailInfo, string imgInfo, int idRoot);
    int insertInformationnoroot(string nameInfo, string detailInfo, string imgInfo);
    int updateInformation(int idInfo, string nameInfo, string detailInfo, string imgInfo, int idRoot);
    int updateInformationnoroot(int idInfo, string nameInfo, string detailInfo, string imgInfo);
    int deleteInformation(int idInfo);
    int deletefollowrootInfo(int idInfo);
    IList<sp_searchnameInfoResult> searchnameInfo(string nameInfo);
    IList<sp_searchbyDetailInfoResult> searchbydetailInfo(string detailInfo);
    sp_searchbyIDInformationResult searchidInfo(int idInfo);
    IList<sp_selectallInformationResult> getListInfo();
    IList<sp_selectallInformationnorootResult> getListInfonoroot(int idInfo);
    #endregion

    #region Admin
    int loginAdmin(string username, string password);
    int updatePassAdmin(string password);
    UserAdmin getDataAdmin();
    #endregion

    bool checkimg(string path);
    bool checkmail(string mail);
    void deleteImage(string filename);
    int sendmail(string mailto, string mailfrom, string message, string subject);
}