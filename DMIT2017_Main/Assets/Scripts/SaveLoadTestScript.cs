using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEditor.Build.Content;
using TMPro;
using UnityEngine.UI;

public class SaveLoadTestScript : MonoBehaviour
{
    //serializer is translating into a common form, can't save complex data structures like a Transform (BUT can save it by breaking it down (x, y, z)), can put in inheritance 
    [SerializeField] NameData myName;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Slider valueSlider;
    void Start()
    {
        myName = new NameData();
        LoadData();
    }
    public void ChangeName(string newName)
    {
        myName.playerName = newName;
    }
    public void SaveData()
    {
        Stream stream = File.Open("PlayerData", FileMode.Create/*New*/);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameData));
        xmlSerializer.Serialize(stream, myName);
        stream.Close();
    }
    public void LoadData()
    {
        Stream stream = File.Open("PlayerData", FileMode.Open);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameData));
        myName = (NameData)xmlSerializer.Deserialize(stream);
        stream.Close();

        inputField.text = myName.playerName;
    }
}

[Serializable]
public struct NameData
{
    public string playerName;
}