using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScores
{
    //saving the name and score for highscore data
    public string name;
    public int score;

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
    public int Score()
    {
        return score;
    }
    public void SetName(string changeName)
    {
        name = changeName;
    }
    public void SetScore(int value)
    {
        score = value;
    }
}