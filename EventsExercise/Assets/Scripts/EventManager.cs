using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

static public class EventManager
{
    static public UnityEvent Activate = new UnityEvent();
    static public UnityEvent<int> CollectCoin = new UnityEvent<int>();
    static public UnityEvent SpawnCoin = new UnityEvent();
}