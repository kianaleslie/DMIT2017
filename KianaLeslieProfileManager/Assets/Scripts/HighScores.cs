using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScores
{
    //saving the name and timer for highscore data
    public string name;
    public float score;

    public HighScores()
    {
        name = "None";
        score = 0;
    }
    public HighScores(string changeName, int changeScore)
    {
        name = changeName;
        score = changeScore;
    }
    public string Name()
    {
        return name;
    }
    public float Score()
    {
        return score;
    }
    public void SetName(string changeName)
    {
        name = changeName;
    }
    public void SetScore(float value)
    {
        score = value;
    }
}