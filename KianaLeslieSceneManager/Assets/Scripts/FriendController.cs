using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public Transform player;
    public float friendSpeed = 5.0f;

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.position += direction * friendSpeed * Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        if (player != null)
    //        {
    //            Vector3 dir = player.position - transform.position;
    //            dir.Normalize();
    //            transform.position += dir * friendSpeed * Time.deltaTime;
    //        }
    //    }
    //}
}