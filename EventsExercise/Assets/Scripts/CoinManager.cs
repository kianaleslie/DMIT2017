using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] public int coin;
    [SerializeField] bool isCoinRed;

    private void Update()
    {
        if(isCoinRed)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        isCoinRed = true; 
        yield return new WaitForSeconds(10.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EventManager.CollectCoin.Invoke(coin);
            Destroy(gameObject);
        }
    }
}