using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveController 
{
    //saves profile data for highscores
    public List<ProfileManager> profiles;
    public HighScores[] topThreeHighScores;
    public int currentIndex;

    public SaveController()
    {
        profiles = new List<ProfileManager>();
        topThreeHighScores = new HighScores[5];

        for (int index = 0; index < topThreeHighScores.Length; index++)
        {
            topThreeHighScores[index] = new HighScores();
        }
    }
    public void AddProfile()
    {
        profiles.Add(new ProfileManager($"Profile {profiles.Count + 1}", 0, 0, 0));
    }
    public void RemoveProfile(int index)
    {
        profiles.RemoveAt(index);
    }
}