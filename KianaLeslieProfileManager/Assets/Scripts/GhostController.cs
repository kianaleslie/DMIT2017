using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostController : MonoBehaviour
{
    Rigidbody rBody;
    SaveController saveController;
    int index;
    bool isThereGhostData = false;
    public GameObject[] vehicles;
    public Material transparentMaterial;

    void Start()
    {
        saveController = new SaveController();

        if (saveController.profiles[saveController.currentIndex].ghostData.ghostPos.Count > 0)
        {
            rBody = GetComponent<Rigidbody>();
            isThereGhostData = true;
            gameObject.GetComponent<MeshFilter>().sharedMesh = vehicles[saveController.profiles[saveController.currentIndex].ghostData.vehicleType].GetComponent<MeshFilter>().sharedMesh;
            gameObject.GetComponent<Renderer>().material = transparentMaterial;
        }
        else
        {
            saveController.profiles[saveController.currentIndex].ghostData.ghostPos = new List<GhostPosition>();
        }
    }
    void Update()
    {
        //check if there is ghost data
        if (isThereGhostData)
        {
            //check if the index is in range of the data
            if(index < saveController.profiles[saveController.currentIndex].ghostData.ghostPos.Count)
            {
                rBody.MovePosition(new Vector3(saveController.profiles[saveController.currentIndex].ghostData.ghostPos[index].x, saveController.profiles[saveController.currentIndex].ghostData.ghostPos[index].y, saveController.profiles[saveController.currentIndex].ghostData.ghostPos[index].z));
                index += 1;
            }  
        }
    }
}