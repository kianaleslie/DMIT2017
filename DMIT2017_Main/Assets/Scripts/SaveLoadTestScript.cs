using System;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveLoadTestScript : MonoBehaviour
{
    [SerializeField] NameData profileName;
    [SerializeField] TMP_InputField inputField;
    string filePath = "SaveData\\Profile1";

    [SerializeField] public GameObject[] profileButtons;
    [SerializeField] public GameObject hideInputField;

    void Start()
    {
        profileName = new NameData();
        LoadProfile();
        foreach(var profile in profileButtons)
        {
            profile.SetActive(false);
        }
        hideInputField.SetActive(false);
    }
    public void ChangeName(string newName)
    {
        profileName.playerName = newName;
    }
    public void SaveProfile()
    {
        CreateFileStructure();
        Debug.Log(profileName.playerName);
        SaveManager.SaveData(filePath + "\\PlayerData", ref profileName);
    }
    public void LoadProfile()
    {
        SaveManager.LoadData(filePath + "\\PlayerData", ref profileName);
        inputField.text = profileName.playerName;
    }
    void CreateFileStructure()
    {
        // find if the firectory exists
        if(Directory.Exists(filePath))
        {
            Debug.Log("Folder already exists.");
        }
        else
        {
            //try to create it
            Directory.CreateDirectory(filePath);
        }
    }
    public void CreateProfile()
    {
        hideInputField.SetActive(true);
    }
    ////serializer is translating into a common form, can't save complex data structures like a Transform (BUT can save it by breaking it down (x, y, z)), can put in inheritance 
    //[SerializeField] NameData profileName;
    //[SerializeField] TMP_InputField inputField;
    //[SerializeField] Slider valueSlider;
    //void Start()
    //{
    //    profileName = new NameData();
    //    LoadData();
    //}
    //public void ChangeName(string newName)
    //{
    //    profileName.playerName = newName;
    //}
    //public void SaveData()
    //{
    //    Stream stream = File.Open("PlayerData", FileMode.Create/*New*/);
    //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameData));
    //    xmlSerializer.Serialize(stream, profileName);
    //    stream.Close();
    //}
    //public void LoadData()
    //{
    //    Stream stream = File.Open("PlayerData", FileMode.Open);
    //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameData));
    //    profileName = (NameData)xmlSerializer.Deserialize(stream);
    //    stream.Close();

    //    inputField.text = profileName.playerName;
    //}
}

[Serializable]
public struct NameData
{
    public string playerName;
}