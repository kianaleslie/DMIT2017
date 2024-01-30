using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileManager
{
    //saving profile name, vehicle type, colour, and highscore for each profile - referenced "Debugging exercise"
    public string name;
    public int vehicleType;
    public int colour;
    public float score;
    public GhostData ghostData;

    public ProfileManager()
    {
        name = "Profile";
        vehicleType = 0;
        colour = 0;
        score = 0;
        ghostData = new GhostData();
    }
    public ProfileManager(string changeName, int changeVehicle, int changeColour, int changeScore)
    {
        name = changeName;
        vehicleType = changeVehicle;
        colour = changeColour;
        score = changeScore;
        ghostData = new GhostData();
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
    public float Score()
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
    public void SetScore(float setScore)
    {
        score = setScore;
    }
}