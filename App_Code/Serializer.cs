using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

/// <summary>
/// Summary description for Serializer
/// </summary>
public class Serializer
{
    public Serializer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void SerializeObject(string path, Object obj)
    {
        Stream str = File.Open(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(str, obj);
        str.Close();
    }
    public Object DeserializeObject(string path, Object obj)
    {
        Stream stream = File.Open(path, FileMode.OpenOrCreate);
        if (stream.Length == 0)
        {
            stream.Close();
            return null;
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
    }
}