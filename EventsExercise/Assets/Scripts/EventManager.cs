using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

static public class EventManager
{
    static public UnityEvent Activate = new UnityEvent();
    static public UnityEvent CollectCoin = new UnityEvent();
    static public UnityEvent SpawnCoin = new UnityEvent();
}