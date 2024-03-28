using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    int maxHealth;
    public int health;
    [SerializeField] Image healthUI;

    void Start()
    {
        maxHealth = 30;
        health = maxHealth;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(true);
    }
    public void DealDamage(int damage)
    {
        health -= damage;
        healthUI.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void ResetHealth(int newHealth)
    {
        health = newHealth;
        healthUI.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);
    }
}