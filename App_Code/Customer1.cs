using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer1
/// </summary>
public class Customer1
{
    public int idCus { get; set; }
    public string nameCus { get; set; }
    public string password1 { get; set; }
    public string email { get; set; }
    public DateTime birthday { get; set; }
    public bool sex { get; set; }
    public string address1 { get; set; }
    public int phone { get; set; }
    public DateTime registerdate { get; set; }
    public Customer1()
    {
    }
}
public sealed class CustomerList : List<Customer>
{
    public CustomerList()
    {

    }
    public void getAllCus(IList<sp_selectallCustomerResult> val)
    {
        foreach (var item in val)
        {
            Customer ct = new Customer();
            ct.idCus = item.idCus;
            ct.nameCus = item.nameCus;
            ct.password1 = item.password1;
            ct.email = item.email;
            ct.birthday = item.birthday;
            ct.sex = item.sex;
            ct.address1 = item.address1;
            ct.phone = item.phone;
            ct.registerDate = item.registerDate;
            this.Add(ct);
        }
    }
    public void getAllSearch(IList<sp_searchnameCusResult> val)
    {
        foreach (var item in val)
        {
            Customer ct = new Customer();
            ct.idCus = item.idCus;
            ct.nameCus = item.nameCus;
            ct.password1 = item.password1;
            ct.email = item.email;
            ct.birthday = item.birthday;
            ct.sex = item.sex;
            ct.address1 = item.address1;
            ct.phone = item.phone;
            ct.registerDate = item.registerDate;
            this.Add(ct);
        }
    }
}