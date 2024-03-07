using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator chestUnlocking;
    bool isOpen = false;

    void Start()
    {
        chestUnlocking = GetComponent<Animator>();
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            chestUnlocking.SetTrigger("Chest Unlocked");
            isOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            chestUnlocking.SetTrigger("Chest Closed");
            isOpen = false;
        }
    }
}