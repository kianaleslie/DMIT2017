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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 3.0f;
        rotateSpeed = 15.0f;
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed);
    }
}