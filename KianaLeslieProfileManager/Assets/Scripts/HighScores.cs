using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScores
{
    //saving the name and timer data
    public string name;
    public float time;

    public HighScores()
    {
        name = "None";
        time = 0;
    }
    public HighScores(string changeName, int changeTime)
    {
        name = changeName;
        time = changeTime;
    }
    public string Name()
    {
        return name;
    }
    public float Time()
    {
        return time;
    }
    public void SetName(string changeName)
    {
        name = changeName;
    }
    public void SetTime(float setTime)
    {
        time = setTime;
    }
}