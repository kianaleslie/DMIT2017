using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    bool isLookingAt = false;
    PlayerController player;

    private void Update()
    {
        if(PlayerFound.found)
        {
            isLookingAt = true;
        }
        if(isLookingAt)
        {
            transform.LookAt(player.transform);
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

    //public void EnemyDefeated()
    //{
    //    enemyCount--;

    //    //check if the player has defeated all 3 enemies
    //    if (enemyCount == 0)
    //    {
    //        //show the map when enemies = 0
    //        mapImage.enabled = true;
    //        youAreHereImage.enabled = true;
    //        xImage.enabled = true;
    //        youAreHereText.enabled = true;
    //        xText.enabled = true;
    //        treasureChest.SetActive(true);
    //        questCube.SetActive(true);
    //        itemCount = 1;
    //    }

    //    //update the UI text with the current item count
    //    UpdateItemCountText();
    //}
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