using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for UserAdmin
/// </summary>
[Serializable]
public class UserAdmin : ISerializable
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public UserAdmin()
    {
        Username = "";
        Password = "";
        Email = "";
    }
    public UserAdmin(SerializationInfo info, StreamingContext context)
    {
        Username = (string)info.GetValue("Account", typeof(string));
        Password = (string)info.GetValue("Password", typeof(string));
        Email = (string)info.GetValue("Email", typeof(string));
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Account", Username);
        info.AddValue("Password", Password);
        info.AddValue("Email", Email);
    }
}