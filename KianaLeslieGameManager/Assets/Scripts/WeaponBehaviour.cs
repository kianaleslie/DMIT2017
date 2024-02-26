using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    int bulletAmount;
    int poolCount;
    int index;
    float fireRate;
    float velocity;
    float timeStamp;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] GameObject[] bullets;

    void Start()
    {
        bulletAmount = 200;
        poolCount = 5;
        fireRate = 0.5f;
        velocity = 20.0f;

        GameObject instantiatedObject;

        bullets = new GameObject[poolCount];

        for (int i = 0; i < bullets.Length; i++)
        {
            instantiatedObject = Instantiate(bullet);
            instantiatedObject.SetActive(false);
            bullets[i] = instantiatedObject;
            Physics.IgnoreCollision(GetComponentInChildren<Collider>(), instantiatedObject.GetComponentInChildren<Collider>());
        }
    }

    void Fire()
    {
        if (bulletAmount > 0 && Time.time > timeStamp + fireRate)
        {
            timeStamp = Time.time;
            bulletAmount--;

            bullets[index].transform.position = bulletSpawn.transform.position;
            bullets[index].transform.rotation = bulletSpawn.transform.rotation;
            bullets[index].SetActive(true);
            bullets[index].GetComponent<Rigidbody>().velocity = transform.forward * velocity;

            index++;

            if (index >= poolCount)
            {
                index = 0;
            }
        }
    }
}