using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product1
/// </summary>
public class Product1
{
    public int idPro { get; set; }
    public string namePro { get; set; }
    public int price { get; set; }
    public string img { get; set; }
    public string detailPro { get; set; }
    public DateTime dateUp { get; set; }
    public bool activePro { get; set; }
    public int idCate { get; set; }
    public string nameCate { get; set; }
    public Product1()
    {
    }
}
public sealed class ProductList : List<Product1>
{
    public ProductList()
    {

    }
    public void getAllPro(IList<sp_selectallProductResult> val)
    {
        foreach (var item in val)
        {
            Product1 p = new Product1();
            p.idPro = item.idPro;
            p.namePro = item.namePro;
            p.price = (int)item.price;
            p.img = item.img;
            p.detailPro = item.detailPro;
            p.dateUp = (DateTime)item.dateUp;
            p.activePro = (bool)item.activePro;
            p.idCate = (int)item.idCate;
            p.nameCate = item.nameCate;
            this.Add(p);
        }
    }
    public void getAllSearchPro(IList<sp_searchnameProResult> val)
    {
        foreach (var item in val)
        {
            Product1 p = new Product1();
            p.idPro = item.idPro;
            p.namePro = item.namePro;
            p.price = (int)item.price;
            p.img = item.img;
            p.detailPro = item.detailPro;
            p.dateUp = (DateTime)item.dateUp;
            p.activePro = (bool)item.activePro;
            p.idCate = (int)item.idCate;
            p.nameCate = item.nameCate;
            this.Add(p);
        }
    }
    public void getAllProbyidCate(IList<sp_selectbyidCateProResult> val) {
        foreach (var item in val)
        {
            Product1 p = new Product1();
            p.idPro = item.idPro;
            p.namePro = item.namePro;
            p.price = (int)item.price;
            p.img = item.img;
            p.detailPro = item.detailPro;
            p.dateUp = (DateTime)item.dateUp;
            p.activePro = (bool)item.activePro;
            p.idCate = (int)item.idCate;
            p.nameCate = item.nameCate;
            this.Add(p);
        }
    }
}