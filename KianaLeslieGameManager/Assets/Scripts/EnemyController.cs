using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    float timer;
    float attackRange = 10.0f;
    float attackCooldown = 1.0f;
    float attackTime;

    public int enemyCount = 3;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] GameObject treasure; 
    public HealthUI health;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        treasure.SetActive(false);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            AttackPlayer();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health.DealDamage(10);
        }
    }
    void AttackPlayer()
    {
        transform.transform.LookAt(player.transform.position);
        var bulletObject = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bulletObject.GetComponent<Rigidbody>().velocity = bulletObject.transform.TransformDirection(Vector3.forward * 15.0f);
        //don't attack too fast - need a cooldown
        if (Time.time - attackTime >= attackCooldown)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.health.DealDamage(3);
            }
            attackTime = Time.time;
        }
    }
    public void EnemyDefeated()
    {
        enemyCount--;
        //save enemy count

        if (enemyCount == 0)
        {
           treasure.SetActive(true);
        }
    }
}