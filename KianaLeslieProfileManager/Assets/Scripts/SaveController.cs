using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveController
{
    //saves profile data for highscores
    public List<ProfileManager> profiles;
    public HighScores[] topTimes;

    public SaveController()
    {
        profiles = new List<ProfileManager>();
        topTimes = new HighScores[5];

        for (int index = 0; index < topTimes.Length; index++)
        {
            topTimes[index] = new HighScores();
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