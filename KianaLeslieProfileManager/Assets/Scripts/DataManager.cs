using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public static class DataManager 
{
    public static int currentIndex;

    public static SaveController LoadData()
    {
        Stream stream = File.Open("SaveFiles\\Profiles", FileMode.Open);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveController));
        SaveController tempSaveController = serializer.Deserialize(stream) as SaveController;
        stream.Close();
        return tempSaveController;
    }
    public static void SaveData(SaveController saveController)
    {
        CreateFileStructure();
        Stream stream = File.Open("SaveFiles\\Profiles", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveController));
        serializer.Serialize(stream, saveController);
        stream.Close();
    }
    public static void CreateFileStructure()
    {
        if (Directory.Exists("SaveFiles"))
        {
            Debug.Log("Folder already exists.");
        }
        else
        {
            Directory.CreateDirectory("SaveFiles");
        }
    }
}