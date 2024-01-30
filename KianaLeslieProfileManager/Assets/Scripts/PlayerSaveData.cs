using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveData : MonoBehaviour
{
    public SaveController saveController;

    public Material[] colours;
    public GameObject[] vehicles;

    void Start()
    {
        LoadData();
        gameObject.GetComponent<MeshFilter>().sharedMesh = vehicles[saveController.profiles[DataManager.currentIndex].Vehicle()].GetComponent<MeshFilter>().sharedMesh;
        gameObject.GetComponent<Renderer>().material = colours[saveController.profiles[DataManager.currentIndex].Colour()];

    }

    public void LoadData()
    {
        if (File.Exists("SaveFiles\\Profiles"))
        {
            Stream stream = File.Open("SaveFiles\\Profiles", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(SaveController));
            saveController = serializer.Deserialize(stream) as SaveController;
            stream.Close();
        }
    }

    public void SaveScore(float changeScore)
    {
        if (changeScore > saveController.profiles[DataManager.currentIndex].Time())
        {
            saveController.profiles[DataManager.currentIndex].SetTime(changeScore);
        }

        CheckTopScores(changeScore, saveController.profiles[DataManager.currentIndex].Name());

        Stream stream = File.Open("SaveFiles\\Profiles", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveController));
        serializer.Serialize(stream, saveController);
        stream.Close();

        SceneManager.LoadScene(0);
    }

    void CheckTopScores(float checkScore, string checkName)
    {
        float tempScore;
        string tempName;

        for (int i = 0; i < saveController.topTimes.Length; i++)
        {
            if (checkScore > saveController.topTimes[i].Score())
            {
                tempScore = saveController.topTimes[i].Score();
                tempName = saveController.topTimes[i].Name();

                saveController.topTimes[i].SetScore(checkScore);
                saveController.topTimes[i].SetName(checkName);

                checkScore = tempScore;
                checkName = tempName;
            }
        }
    }
}