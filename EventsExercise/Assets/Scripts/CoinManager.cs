using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] public GameObject[] coins;

    

    private void Start()
    {
        EventManager.SpawnCoin.AddListener(SpawnCoin);
    }
    void SpawnCoin()
    {
        
        
    }
    void CollectCoin()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EventManager.Activate.AddListener(CollectCoin);
        }
    }
}