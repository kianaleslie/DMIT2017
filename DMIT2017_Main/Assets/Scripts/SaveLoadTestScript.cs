using System;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class SaveLoadTestScript : MonoBehaviour
{
    [SerializeField] NameData profileName;
    [SerializeField] TMP_InputField inputField;
    string filePath = "SaveData\\Profile1";

    [SerializeField] public GameObject[] profileButtons;
    [SerializeField] public GameObject hideInputField;
    [SerializeField] public int profile;
    [SerializeField] public GameObject profile1;
    [SerializeField] public GameObject profile2;
    [SerializeField] public GameObject profile3;
    [SerializeField] public Button createProfileButton;
    [SerializeField] public Button profile1Button;
    [SerializeField] public Button profile2Button;
    [SerializeField] public Button profile3Button;

    void Start()
    {
        profile = 0;
        profileName = new NameData();
        //LoadProfile();
        foreach (var profile in profileButtons)
        {
            profile.SetActive(false);
        }
        hideInputField.SetActive(false);
        if (createProfileButton != null)
        {
            createProfileButton.onClick.AddListener(ShowProfileButtons);
        }
        if (profile1Button != null)
        {
            profile1Button.onClick.AddListener(LoadProfile);
        }
        if (profile2Button != null)
        {
            profile2Button.onClick.AddListener(LoadProfile);
        }
        if (profile3Button != null)
        {
            profile3Button.onClick.AddListener(LoadProfile);
        }
    }
    public void ChangeProfile(int selectProfile)
    {
        filePath = $"SaveData\\Profile{selectProfile}";
        profileName.playerName = "";
    }
    public void ChangeName(string newName)
    {
        profileName.playerName = newName;
    }
    public void ShowProfileButtons()
    {
        if (profile1 != null)
        {
            profile1.SetActive(true);
        }
        if (profile2 != null)
        {
            profile2.SetActive(true);
        }
        if (profile3 != null)
        {
            profile3.SetActive(true);
        }
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
        if (Directory.Exists(filePath))
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