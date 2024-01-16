using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataFileManager : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] PlayerData highScoreData;
    [SerializeField] TMP_InputField playerNameInputField;
    string filePath = $"SaveData\\HighScore";
    string highScorePath = $"SaveData\\HighScore\\HighScoreData";

    [SerializeField] Button startButton;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text clicksText;
    [SerializeField] TMP_Text countDownText;

    float timer = 0f;
    float gameTimer = 10.0f;
    int score = 0;
    int highScore = 0;
    bool playingGame = false;

    void Start()
    {
        playerData = new PlayerData();
        highScoreData = new PlayerData();
        startButton.interactable = false;
        LoadHighScore();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ChangePlayerName(string newName)
    {
        playerData.name = newName;
        if (string.IsNullOrEmpty(newName))
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }
    }
    public void SaveHighScore()
    {
        if (playerData.score > highScoreData.score)
        {
            CreateFile();
            Stream stream = File.Open(highScorePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
            serializer.Serialize(stream, playerData);
            stream.Close();
        }
    }
    public void LoadHighScore()
    {
        if (File.Exists(highScorePath))
        {
            Stream stream = File.Open(highScorePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
            highScoreData = (PlayerData)serializer.Deserialize(stream);
            stream.Close();
        }
    }
    public void StartGame()
    {
        StartCoroutine(StartGameCountDown());
    }
    IEnumerator StartGameCountDown()
    {
        //diasble input field, countdown including go, start clicking and keeping track, end game and update high score
        playerNameInputField.interactable = false;

        for(int index = 3; index > 0; index--)
        {
            countDownText.text = index.ToString();
            yield return new WaitForSeconds(1.0f);
        }
        countDownText.text = "Go";
        playingGame = true;
        startButton.interactable = true;

        yield return new WaitForSeconds(1.0f);
        countDownText.text = "";
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            UpdateScoreText();
        }
        timer = gameTimer;
        while(timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        playingGame = false;
        UpdateHighScoreText();
    }
     void UpdateScoreText()
    {
        clicksText.text = "Clicks: " + score.ToString();
    }
     void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + playerData.name + " - " + highScore.ToString();
    }
    void CreateFile()
    {
        if (Directory.Exists(filePath))
        {
            Debug.Log("Folder already exists.");
        }
        else
        {
            Directory.CreateDirectory(filePath);
        }
    }
}

[Serializable]
public struct PlayerData
{
    public string name;
    public int score;

}