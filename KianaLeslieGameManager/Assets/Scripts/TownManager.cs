using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownManager : MonoBehaviour
{
    [SerializeField] Transform spawnLocation;
    PlayerController player;
    bool transition = false;

    void Start()
    {                                 
        GameObject.FindGameObjectWithTag("Player").transform.position = /*spawnLocation.position*/ transform.position + PlayerInfo.piInstance.spawnLocation.normalized * 3f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (transition)
        {
            SceneManager.LoadScene("Overworld", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(PlayerInfo.piInstance.currentScene);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerInfo.piInstance.spawnLocation = other.transform.position - transform.position;
        player = other.GetComponent<PlayerController>();
        transition = true;
    }
}