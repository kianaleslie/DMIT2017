using System.IO;
using System.Xml.Serialization;
public class SaveManager 
{
    public static void SaveData(string path, ref NameData myName)
    {
        Stream stream = File.Open(path, FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(NameData));
        serializer.Serialize(stream, myName);
        stream.Close();
    }
    public static void LoadData(string path, ref NameData myName)
    {
        if(File.Exists(path))
        {
            Stream stream = File.Open(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(NameData));
            myName = (NameData)serializer.Deserialize(stream);
            stream.Close();
        }
    }
}