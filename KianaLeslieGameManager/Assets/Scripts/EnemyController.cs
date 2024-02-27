using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    float attackRange = 10f;
    float attackDamage = 3f;
    float attackCooldown = 1f;
    float attackTime;

    int enemyCount = 3;
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

    void AttackPlayer()
    {
        if (Time.time - attackTime >= attackCooldown)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.health.DealDamage((int)attackDamage);
            }
            attackTime = Time.time;
        }
    }
    //public Image mapImage;
    //public Image youAreHereImage;
    //public Image xImage;
    //public TMP_Text youAreHereText;
    //public TMP_Text xText;
    //public TMP_Text itemCountText;
    //[SerializeField] public GameObject treasureChest;
    //[SerializeField] public GameObject questCube;

    //int itemCount = 0;
    //int enemyCount = 3;

    //private void Start()
    //{
    //    mapImage.enabled = false;
    //    youAreHereImage.enabled = false;
    //    xImage.enabled = false;
    //    youAreHereText.enabled = false;
    //    xText.enabled = false;
    //    treasureChest.SetActive(false);
    //    questCube.SetActive(false);

    //    //initialize the UI text with the item count
    //    UpdateItemCountText();
    //}

    public void EnemyDefeated()
    {
        enemyCount--;
        //save enemy count

        if (enemyCount == 0)
        {
           //save treasure collected 

        }
    }
    //public void UpdateItemCountText()
    //{
    //    itemCountText.text = "Items: " + itemCount.ToString();
    //}
    //public void ChestCollected()
    //{
    //    itemCount = 10;
    //    UpdateItemCountText();
    //    mapImage.enabled = false;
    //    youAreHereImage.enabled = false;
    //    xImage.enabled = false;
    //    youAreHereText.enabled = false;
    //    xText.enabled = false;
    //}
}