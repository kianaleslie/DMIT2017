using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    float timer;
    float attackRange = 7.0f;
    float attackCooldown = 3.0f;
    float attackTime;

    public string currentTown;
    public int enemyCount;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    public HealthUI health;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        //don't attack too fast - need a cooldown
        if (Time.time - attackTime >= attackCooldown)
        {
            transform.transform.LookAt(player.transform.position);
            var bulletObject = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            bulletObject.GetComponent<Rigidbody>().velocity = bulletObject.transform.TransformDirection(Vector3.forward * 15.0f);
            Destroy(bulletObject, 2.0f);

            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.health.DealDamage(3);
            }
            attackTime = Time.time;
        }
    }
}