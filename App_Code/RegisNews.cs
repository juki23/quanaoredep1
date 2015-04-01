using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RegisNews
/// </summary>
public class RegisNews
{
    public int idRegisnew { get; set; }
    public string email { get; set; }
	public RegisNews()
	{
	}
}
public sealed class RegisNewsList : List<Regisnew>
{

    public RegisNewsList()
    {

    }
    public void getAllSearch(List<sp_searchEmailResult> val) {
        foreach (var item in val)
        {
            Regisnew rn = new Regisnew();
            rn.idRegisnew = item.idRegisnew;
            rn.email = item.email;
            this.Add(rn);
        }
    }
    public void getAll(List<sp_selectallRegisnewsResult> val)
    {
        foreach (var item in val)
        {
            Regisnew rn = new Regisnew();
            rn.idRegisnew = item.idRegisnew;
            rn.email = item.email;
            this.Add(rn);
        }
    }
}