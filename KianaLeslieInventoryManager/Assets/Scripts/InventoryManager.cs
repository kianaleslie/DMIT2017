using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    string currentWeapon;
    string currentArmor;

    public void SetWeapon(string weapon)
    {
        currentWeapon = weapon;
    }
    public string GetWeapon()
    {
        return currentWeapon;
    }
    public void SetArmor(string armor)
    {
        currentArmor = armor;
    }
    public string GetArmor()
    {
        return currentArmor;
    }
}