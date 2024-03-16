using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private InventoryData playerInventory;

    private void Start()
    {
        playerInventory = new InventoryData();
    }

    //get and set methods to save the current game data
    public void SetWeapon(string weapon)
    {
        playerInventory.WeaponSlot = weapon;
    }
    public string GetWeapon()
    {
        return playerInventory.WeaponSlot;
    }
    public void SetArmor(string armor)
    {
        playerInventory.ArmorSlot = armor;
    }
    public string GetArmor()
    {
        return playerInventory.ArmorSlot;
    }

    //get and set for the current inventory 
    public InventoryData GetInventory()
    {
        return playerInventory;
    }
    public void SetInventory(InventoryData inventory)
    {
        playerInventory = inventory;
    }
}