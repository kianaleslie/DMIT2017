using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] public int coin;
    [SerializeField] bool isCoinRed;
    bool hasTimerStarted = false;

    private void Update()
    {
        if(isCoinRed && !hasTimerStarted)
        {
            hasTimerStarted = true;
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
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