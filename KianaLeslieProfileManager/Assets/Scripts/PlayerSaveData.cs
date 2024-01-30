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
        //LoadData();
        saveController = DataManager.LoadData();
        gameObject.GetComponent<MeshFilter>().sharedMesh = vehicles[saveController.profiles[DataManager.currentIndex].Vehicle()].GetComponent<MeshFilter>().sharedMesh;
        gameObject.GetComponent<Renderer>().material = colours[saveController.profiles[DataManager.currentIndex].Colour()];

    }

    //public void LoadData()
    //{
    //    if (File.Exists("SaveFiles\\Profiles"))
    //    {
    //        Stream stream = File.Open("SaveFiles\\Profiles", FileMode.Open);
    //        XmlSerializer serializer = new XmlSerializer(typeof(SaveController));
    //        saveController = serializer.Deserialize(stream) as SaveController;
    //        stream.Close();
    //    }
    //}

    public void SaveTime(float changeTime)
    {
        saveController = DataManager.LoadData();
        if (changeTime > saveController.profiles[DataManager.currentIndex].Time())
        {
            saveController.profiles[DataManager.currentIndex].SetTime(changeTime);
        }

        CheckTopTimes(changeTime, saveController.profiles[DataManager.currentIndex].Name());

        Stream stream = File.Open("SaveFiles\\Profiles", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveController));
        serializer.Serialize(stream, saveController);
        stream.Close();
    }

    void CheckTopTimes(float checkTime, string checkName)
    {
        float tempTime;
        string tempName;

        for (int i = 0; i < saveController.topTimes.Length; i++)
        {
            if (checkTime > saveController.topTimes[i].Time())
            {
                tempTime = saveController.topTimes[i].Time();
                tempName = saveController.topTimes[i].Name();

                saveController.topTimes[i].SetTime(checkTime);
                saveController.topTimes[i].SetName(checkName);

                checkTime = tempTime;
                checkName = tempName;
            }
        }
    }
}