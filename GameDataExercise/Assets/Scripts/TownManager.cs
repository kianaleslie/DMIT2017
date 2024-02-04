using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownManager : MonoBehaviour
{
    [SerializeField] Transform spawnLocation;
    PlayerController player;
    bool transition = false;

    // Start is called before the first frame update
    void Start()
    {                                                                                                //center of scene                       //the area where the player spawns, 7.5 is just distance from center of town
        GameObject.FindGameObjectWithTag("Player").transform.position = /*spawnLocation.position*/ transform.position + PlayerInfo.piInstance.spawnLocation.normalized * 7.5f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.Fade(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transition && !player.Fading())
        {
            SceneManager.LoadScene("Overworld", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(PlayerInfo.piInstance.currentScene);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //                                    players last pos the moment it hit the trigger - the angle of the spawn 
        PlayerInfo.piInstance.spawnLocation = other.transform.position - transform.position;
        player = other.GetComponent<PlayerController>();
        player.Fade(true);
        transition = true;        
    }
}
