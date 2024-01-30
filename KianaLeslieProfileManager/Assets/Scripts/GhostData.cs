using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhostData
{
    public List<GhostPosition> ghostPos;
    public int vehicleType;

    public GhostData()
    {
        ghostPos = new List<GhostPosition>();
    }
}

[System.Serializable]
public class GhostPosition
{
    public float x;
    public float y;
    public float z;
}