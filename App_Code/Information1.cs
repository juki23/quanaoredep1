using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Information1
/// </summary>
public class Information1
{
    public int idInfo { get; set; }
    public string nameInfo { get; set; }
    public string detailInfo { get; set; }
    public string imgInfo { get; set; }
    public int idRoot { get; set; }
    public string rootname { get; set; }
	public Information1()
	{
	}
}
public sealed class InformationList : List<Information1>
{
    public InformationList()
    {

    }
    public void getAllInfo(IList<sp_selectallInformationResult> val)
    {
        foreach (var item in val)
        {
            Information1 info = new Information1();
            info.idInfo = item.idInfo;
            info.nameInfo = item.nameInfo;
            info.detailInfo = item.detailInfo;
            info.imgInfo = item.imgInfo;
            if (item.idRoot != null)
            {
                info.idRoot = (int)item.idRoot;
            }
            info.rootname = item.rootname;
            this.Add(info);
        }
    }
    public void getAllSearchnameInfo(IList<sp_searchnameInfoResult> val)
    {
        foreach (var item in val)
        {
            Information1 info = new Information1();
            info.idInfo = item.idInfo;
            info.nameInfo = item.nameInfo;
            info.detailInfo = item.detailInfo;
            info.imgInfo = item.imgInfo;
            if (item.idRoot != null)
            {
                info.idRoot = (int)item.idRoot;
            }
            info.rootname = item.rootname;
            this.Add(info);
        }
    }
    public void getAllSearchsearchdetailInfo(IList<sp_searchbyDetailInfoResult> val)
    {
        foreach (var item in val)
        {
            Information1 info = new Information1();
            info.idInfo = item.idInfo;
            info.nameInfo = item.nameInfo;
            info.detailInfo = item.detailInfo;
            info.imgInfo = item.imgInfo;
            if (item.idRoot != null)
            {
                info.idRoot = (int)item.idRoot;
            }
            info.rootname = item.rootname;
            this.Add(info);
        }
    }
}