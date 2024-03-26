using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public EnemyController enemyHealth;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealth.health.DealDamage(10);
            gameObject.SetActive(false);
        }
    }
}