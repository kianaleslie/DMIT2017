using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button button;

    void Start()
    {
        Load();
    }
    public void Load()
    {
        if (File.Exists($"{SaveManager.path} /GameData"))
        {
            Stream stream = File.Open($"{SaveManager.path} /GameData", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerInfo));
            SaveManager.playerInfo = (PlayerInfo)serializer.Deserialize(stream);
            stream.Close();
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
            SaveManager.playerInfo = new PlayerInfo();
        }
    }
    public void Resume()
    {
        SceneManager.LoadScene(SaveManager.playerInfo.currentScene);
    }

    public void New()
    {
        if (File.Exists($"{SaveManager.path} /GameData"))
        {
            File.Delete($"{SaveManager.path} /GameData");
        }
        SaveManager.ResetInfo();
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}