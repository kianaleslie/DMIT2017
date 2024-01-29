using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileManager : MonoBehaviour
{
    //saving profile name, vehicle type, colour, and highscore for each profile - referenced "Debugging exercise"
    public new string name;
    public int vehicleType;
    public int colour;
    public int score;

    public ProfileManager()
    {
        name = "Profile";
        vehicleType = 0;
        colour = 0;
        score = 0;
    }
    public ProfileManager(string changeName, int changeVehicle, int changeColour, int changeScore)
    {
        name = changeName;
        vehicleType = changeVehicle;
        colour = changeColour;
        score = changeScore;
    }
    public string Name()
    {
        return name;
    }
    public int Vehicle()
    {
        return vehicleType;
    }
    public int Colour()
    {
        return colour;
    }
    public int Score()
    {
        return score;
    }
    public void SetName(string nameChange)
    {
        name = nameChange;
    }
    public void SetVehicle(int vehicleChange)
    {
        vehicleType = vehicleChange;
    }
    public void SetColour(int colourChange)
    {
        colour = colourChange;
    }
    public void SetScore(int setScore)
    {
        score = setScore;
    }
}