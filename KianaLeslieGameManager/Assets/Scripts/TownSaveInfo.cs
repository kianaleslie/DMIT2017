using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TownSaveInfo : MonoBehaviour
{
    public string town;
    public List<int> enemies;
    public bool hasTreasureBeenCollected;
}