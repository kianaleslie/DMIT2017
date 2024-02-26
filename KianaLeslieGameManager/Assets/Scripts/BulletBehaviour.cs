using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    int damage = 10;
    private void OnCollisionEnter(Collision collision)
    {
        HealthUI health = collision.gameObject.GetComponent<HealthUI>();
        if (health != null)
        {
            health.DealDamage(damage);
        }

        gameObject.SetActive(false);
    }

}