using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//serializable classes to hold the game data in order to save to file
[System.Serializable]
public class GameState
{
    public InventoryData PlayerInventory;
    public ChestContents[] ChestContents;
}

[System.Serializable]
public class InventoryData
{
    public string WeaponSlot;
    public string ArmorSlot;
}

[System.Serializable]
public class ChestContents
{
    public ChestController.ChestType ChestType;
    public string Item1;
    public string Item2;
    public string Item3;
}