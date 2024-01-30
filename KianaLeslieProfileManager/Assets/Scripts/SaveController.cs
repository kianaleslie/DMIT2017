using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveController 
{
    //saves profile data for highscores
    public List<ProfileManager> profiles;
    public HighScores[] topScores;
    public int currentIndex;

    public SaveController()
    {
        profiles = new List<ProfileManager>();
        topScores = new HighScores[5];

        for (int index = 0; index < topScores.Length; index++)
        {
            topScores[index] = new HighScores();
        }
    }
    public void AddProfile()
    {
        profiles.Add(new ProfileManager("New", 0, 0, 0));
    }
    public void RemoveProfile(int index)
    {
        profiles.RemoveAt(index);
    }
}