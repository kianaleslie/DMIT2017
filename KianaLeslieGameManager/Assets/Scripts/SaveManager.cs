using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static string path = "SaveData";

    public static void SaveData(PlayerInfo playerInfo)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        Stream stream = File.Open($"{path}/GameData", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerInfo));
        serializer.Serialize(stream, playerInfo);
        stream.Close();
    }
    public static PlayerInfo LoadData()
    {
        PlayerInfo loadPlayerInfo = null;
        if (File.Exists($"{path}/GameData"))
        {
            Stream stream = File.Open(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerInfo));
            loadPlayerInfo = (PlayerInfo)serializer.Deserialize(stream);
            stream.Close();
        }
        return loadPlayerInfo;
    }
}