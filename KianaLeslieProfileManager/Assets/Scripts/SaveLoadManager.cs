using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveLoadManager : MonoBehaviour
{
    public SaveController saveController;
    public Button[] profileButtons;
    public Button playButton;
    public Button deleteButton;
    public TMP_Text[] topTimeText;
    public TMP_InputField nameField;
    public TMP_Dropdown vehicleDropdown;
    public TMP_Dropdown colourDropdown;
    public TMP_Text timeText;
    public int index;

    [SerializeField] public GameObject checkDeleteUI;

    void Start()
    {
        saveController = new SaveController();
        LoadData();
        index = 0;
        playButton.interactable = false;
        deleteButton.interactable = false;
        checkDeleteUI.SetActive(false);
    }
    public void SaveData()
    {
        DataManager.SaveData(saveController);
    }
    public void LoadData()
    {
        if (File.Exists("SaveFiles\\Profiles"))
        {
            saveController = DataManager.LoadData();

            for (int index = 0; index < saveController.topTimes.Length; index++)
            {
                topTimeText[index].text = $"{(index + 1)}: {saveController.topTimes[index].Name()} {saveController.topTimes[index].Time()}";
            }
        }
        UpdateProfileButtons();
    }
    public void SelectProfile(int buttonIndex)
    {
        //add a new profile for the button pressed and set the index 
        if (buttonIndex > saveController.profiles.Count - 1)
        {
            saveController.AddProfile();
            index = saveController.profiles.Count - 1;
            DataManager.currentIndex = index;
            UpdateProfileButtons();
        }
        else
        {
            //select the profile and set the index to the seleted profile and update the information associated 
            index = buttonIndex;
            DataManager.currentIndex = index;
        }
        nameField.text = saveController.profiles[index].Name();
        vehicleDropdown.value = saveController.profiles[index].Colour();
        colourDropdown.value = saveController.profiles[index].Vehicle();
        timeText.text = "Best Time: " + saveController.profiles[index].Time();

        playButton.interactable = true;
        deleteButton.interactable = true;
    }
    public void CheckDeleteProfile()
    {
        checkDeleteUI.SetActive(true);
    }
    public void CloseCheckDeleteProfilePanel()
    {
        checkDeleteUI.SetActive(false);
    }
    public void DeleteProfile()
    {
        if (index < saveController.profiles.Count)
        {
            saveController.profiles.RemoveAt(index);
            playButton.interactable = false;

            UpdateProfileButtons();
            CloseCheckDeleteProfilePanel();
        }
    }
    void UpdateProfileButtons()
    {
        //set profile buttons to false, activate the button for each loaded profile, change the text for that profile to the name entered by the user
        for (int i = 0; i < profileButtons.Length; i++)
        {
            profileButtons[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < saveController.profiles.Count; i++)
        {
            profileButtons[i].gameObject.SetActive(true);
            profileButtons[i].GetComponentInChildren<TMP_Text>().text = saveController.profiles[i].Name();
        }
        //if the number of profiles loaded is less than the profile buttons available then activate the next profile button and change the text
        if (saveController.profiles.Count < 3)
        {
            profileButtons[saveController.profiles.Count].gameObject.SetActive(true);
            profileButtons[saveController.profiles.Count].GetComponentInChildren<TMP_Text>().text = "Add Profile";
        }

        if (saveController.profiles.Count == 0)
        {
            nameField.interactable = false;
            vehicleDropdown.interactable = false;
            colourDropdown.interactable = false;
        }
        else
        {
            nameField.interactable = true;
            vehicleDropdown.interactable = true;
            colourDropdown.interactable = true;
        }
        SaveData();
    }
    public void ChangeName(string changeName)
    {
        saveController.profiles[index].SetName(changeName);
        UpdateProfileButtons();
    }
    public void ChangeVehicle(int changeShape)
    {
        saveController.profiles[index].SetVehicle(changeShape);
        UpdateProfileButtons();
    }
    public void ChangeColour(int changeColour)
    {
        saveController.profiles[index].SetColour(changeColour);
        UpdateProfileButtons();
    }
}