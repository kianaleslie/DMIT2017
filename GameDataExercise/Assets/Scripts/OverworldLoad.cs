using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldLoad : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        if (!SceneManager.GetSceneByName("Player").isLoaded)
        {
            SceneManager.LoadScene("Player",LoadSceneMode.Additive);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (PlayerInfo.piInstance.spawnLocation != Vector3.zero)
        {
            //                          what specific town location + player's spawn locaton * 4 because its finding the distance of the center to the spawn but it has to be small because the town in overworld is smaller than in the scene
            player.transform.position = PlayerInfo.piInstance.townLocation + PlayerInfo.piInstance.spawnLocation.normalized * 4f;

        }
        else
        {
            player.transform.position = transform.position;
        }
        player.GetComponent<PlayerController>().Fade(false);
    }
}
