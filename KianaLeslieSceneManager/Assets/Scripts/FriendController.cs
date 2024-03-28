using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    Transform player;
    public float distance = 2.0f;
    public float minDistance = 1.0f;
    public float friendSpeed = 5.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (player != null)
        {
            Vector3 position = player.position - player.forward * distance;
            Vector3 direction = position - transform.position;
            float currentDistance = direction.magnitude;
            direction.Normalize();
            transform.position += direction * friendSpeed * Time.deltaTime;

            if (currentDistance > minDistance)
            {
                transform.position += direction * friendSpeed * Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }
}