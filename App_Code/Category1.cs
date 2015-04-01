using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category1
/// </summary>
public class Category1
{
    public int idCate { get; set; }
    public string nameCate { get; set; }
    public int idRoot { get; set; }
    public string detailCate { get; set; }
    public bool activeCate { get; set; }
    public string rootname { get; set; }
    public Category1()
    {
        idCate = 1;
        nameCate = "";
        idRoot = 1;
        detailCate = "";
        activeCate = false;
        rootname = "";
    }
}
public sealed class CategoryList : List<Category1>
{
    public CategoryList()
    {
    }
    public void getAllCate(IList<sp_selectallCategoryResult> val)
    {
        foreach (var item in val)
        {
            Category1 ca = new Category1();
            ca.idCate = item.idCate;
            ca.nameCate = item.nameCate;
            if (item.idRoot != null)
            {
                ca.idRoot = (int)item.idRoot;
            }
            ca.detailCate = item.detailCate;
            ca.activeCate = (bool)item.activeCate;
            ca.rootname = item.rootname;
            this.Add(ca);
        }
    }
    public void getAllSearchCate(IList<sp_searchnameCateResult> val)
    {
        foreach (var item in val)
        {
            Category1 ca = new Category1();
            ca.idCate = item.idCate;
            ca.nameCate = item.nameCate;
            if (item.idRoot != null)
            {
                ca.idRoot = (int)item.idRoot;
            }
            ca.detailCate = item.detailCate;
            ca.activeCate = (bool)item.activeCate;
            ca.rootname = item.rootname;
            this.Add(ca);
        }
    }
}