using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    public enum ChestType
    {
        Weapon,
        Armor,
        Treasure
    }

    public ChestType chestType;
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI displayText2;
    public TextMeshProUGUI displayText3;
    public GameObject weaponPanel;
    public GameObject armorPanel;
    public GameObject treasurePanel;

    public InventoryManager inventoryManager;
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI armorText;

    string selectedWeapon;
    string selectedArmor;

    private Animator chestUnlocking;
    bool isOpen = false;

    void Start()
    {
        chestUnlocking = GetComponent<Animator>();
        displayText.text = "";
        displayText2.text = "";
        displayText3.text = "";
        weaponPanel.SetActive(false);
        armorPanel.SetActive(false);
        treasurePanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            chestUnlocking.SetTrigger("Chest Unlocked");
            isOpen = true;
        }
        OpenChest();
    }
    private void OnTriggerExit(Collider other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            chestUnlocking.SetTrigger("Chest Closed");
            isOpen = false;
        }
        CloseChest();
    }
    public void OpenChest()
    {
        switch (chestType)
        {
            case ChestType.Weapon:
                DisplayWeapons();
                weaponPanel.SetActive(true);
                armorPanel.SetActive(false);
                treasurePanel.SetActive(false);
                break;
            case ChestType.Armor:
                DisplayArmor();
                weaponPanel.SetActive(false);
                armorPanel.SetActive(true);
                treasurePanel.SetActive(false);
                break;
            case ChestType.Treasure:
                DisplayTreasure();
                weaponPanel.SetActive(false);
                armorPanel.SetActive(false);
                treasurePanel.SetActive(true);
                break;
        }
    }
    public void CloseChest()
    {
        displayText.text = "";
        displayText2.text = "";
        displayText3.text = "";
        weaponPanel.SetActive(false);
        armorPanel.SetActive(false);
        treasurePanel.SetActive(false);
    }
    public void DisplayWeapons()
    {
        string[] weapons =
        {
            "Sword",
            "Axe",
            "Bow",
            "Staff",
            "Dagger",
            "Pistol",
            "Nunchucks",
            "Spear",
            "Baseball Bat",
            "Fishing Rod",
            "Rock"
        };
        string displayText = $"";
        string displayText2 = $"";
        string displayText3 = $"";

        for (int i = 0; i < 1; i++)
        {
            int random = Random.Range(0, weapons.Length);
            int random2 = Random.Range(0, weapons.Length);
            int random3 = Random.Range(0, weapons.Length);
            displayText += weapons[random];
            displayText2 += weapons[random2];
            displayText3 += weapons[random3];
        }
        this.displayText.text = displayText;
        this.displayText2.text = displayText2;
        this.displayText3.text = displayText3;
    }
    public void DisplayArmor()
    {
        string[] armor =
       {
            "Chestplate",
            "Helmet",
            "Boots",
            "Leggings",
            "Chainmail",
            "Mask",
            "Gloves",
            "Kneepads",
            "Elbowpads",
            "Gauntlets",
            "Leather"
        };
        string displayText = $"";
        string displayText2 = $"";
        string displayText3 = $"";

        for (int i = 0; i < 1; i++)
        {
            int random = Random.Range(0, armor.Length);
            int random2 = Random.Range(0, armor.Length);
            int random3 = Random.Range(0, armor.Length);
            displayText += armor[random];
            displayText2 += armor[random2];
            displayText3 += armor[random3];
        }
        this.displayText.text = displayText;
        this.displayText2.text = displayText2;
        this.displayText3.text = displayText3;
    }
    public void DisplayTreasure()
    {
        string[] treasure =
       {
            "Keys",
            "Diamonds",
            "Rubies",
            "Gold Coins",
            "Silver Coins",
            "Cake",
            "Emeralds",
            "Sapphires",
            "Guard Dog",
            "Gold Cheese",
            "Gems"
        };
        string displayText = $"";
        string displayText2 = $"";
        string displayText3 = $"";

        for (int i = 0; i < 1; i++)
        {
            int random = Random.Range(0, treasure.Length);
            int random2 = Random.Range(0, treasure.Length);
            int random3 = Random.Range(0, treasure.Length);
            displayText += treasure[random];
            displayText2 += treasure[random2];
            displayText3 += treasure[random3];
        }
        this.displayText.text = displayText;
        this.displayText2.text = displayText2;
        this.displayText3.text = displayText3;
    }
    public void SetSelectedWeapon1(string weaponName)
    {
        weaponText.text = displayText.text;
    }
    public void SetSelectedWeapon2(string weaponName)
    {
        weaponText.text = displayText2.text;
    }
    public void SetSelectedWeapon3(string weaponName)
    {
        weaponText.text = displayText3.text;
    }
    public void SetSelectedArmor1(string armorName)
    {
        armorText.text = displayText.text;
    }
    public void SetSelectedArmor2(string armorName)
    {
        armorText.text = displayText2.text;
    }
    public void SetSelectedArmor3(string armorName)
    {
        armorText.text = displayText3.text;
    }
}