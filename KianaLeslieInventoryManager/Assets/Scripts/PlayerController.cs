using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed;
    float rotateSpeed;

    public ChestController uiUpdate;
    public GameObject treasureChest;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 10.0f;
        rotateSpeed = 50.0f;
        treasureChest.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            uiUpdate.UpdateEnemyDefeatedUI();
            treasureChest.SetActive(true);
        }
    }
}