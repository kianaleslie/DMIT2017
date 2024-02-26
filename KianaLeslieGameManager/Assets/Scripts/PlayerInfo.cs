using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo piInstance = null;
    public Vector3 spawnLocation;
    public Vector3 townLocation;
    public string currentScene;

    private void Awake()
    {
        if (piInstance == null) 
        {
            piInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (piInstance != this) 
        {
            Destroy(gameObject);
        }
    }
}