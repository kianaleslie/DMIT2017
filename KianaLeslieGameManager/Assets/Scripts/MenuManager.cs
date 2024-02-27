using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    void Start()
    {
        Load();
    }
    public void New()
    {
        if (File.Exists($"{SaveManager.path}/PlayerInfo"))
        {
            File.Delete($"{SaveManager.path}/PlayerInfo");
        }
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        SceneManager.LoadScene(SaveManager.playerInfo.currentScene);
    }
    public void Load()
    {
        if (File.Exists($"{SaveManager.path}/PlayerInfo"))
        {
            Stream stream = File.Open($"{SaveManager.path}/PlayerInfo", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerInfo));
            SaveManager.playerInfo = (PlayerInfo)serializer.Deserialize(stream);
            stream.Close();
            resumeButton.interactable = true;
        }
        else
        {
            resumeButton.interactable = false;
            SaveManager.playerInfo = new PlayerInfo();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}