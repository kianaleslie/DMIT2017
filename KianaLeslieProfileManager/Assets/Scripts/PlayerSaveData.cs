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
        gameObject.GetComponent<MeshFilter>().sharedMesh = vehicles[saveController.profiles[saveController.currentIndex].Vehicle()].GetComponent<MeshFilter>().sharedMesh;
        gameObject.GetComponent<Renderer>().material = colours[saveController.profiles[saveController.currentIndex].Colour()];

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
        if (changeScore > saveController.profiles[saveController.currentIndex].Score())
        {
            saveController.profiles[saveController.currentIndex].SetScore(changeScore);
        }

        CheckTopScores(changeScore, saveController.profiles[saveController.currentIndex].Name());

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

        for (int i = 0; i < saveController.topScores.Length; i++)
        {
            if (checkScore > saveController.topScores[i].Score())
            {
                tempScore = saveController.topScores[i].Score();
                tempName = saveController.topScores[i].Name();

                saveController.topScores[i].SetScore(checkScore);
                saveController.topScores[i].SetName(checkName);

                checkScore = tempScore;
                checkName = tempName;
            }
        }
    }
}