using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    //float verticleInput;
    //float horizontalInput;
    float moveSpeed;
    float rotateSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    HealthUI health;
    [SerializeField] TextMeshProUGUI treasureText;
    [SerializeField] TextMeshProUGUI restText;
    bool isPlayerResting = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 10.0f;
        rotateSpeed = 50.0f;

        restText.text = "";
    }

    private void FixedUpdate()
    {

        if (!isPlayerResting)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
            rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed);
        }
    }

    private void Update()
    {
        if (!isPlayerResting)
        {
            //verticleInput = Input.GetAxis("Vertical");
            //horizontalInput = Input.GetAxis("Horizontal");

            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            //transform.Translate(new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, verticleInput * moveSpeed * Time.deltaTime));
            //transform.rotation = Quaternion.identity;

            if (Input.GetMouseButtonDown(0))
        {
            var bulletObject = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            bulletObject.GetComponent<Rigidbody>().velocity = bulletObject.transform.TransformDirection(Vector3.forward * 15.0f);
        }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            health.DealDamage(3);
        }
        if (collision.gameObject.CompareTag("Treasure"))
        {
            treasureText.text = "Treasure Collected!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inn") && !isPlayerResting)
        {
            isPlayerResting = true;
            StartCoroutine(Rest());
        }
    }
    IEnumerator Rest()
    {
        restText.text = "Resting!";
        yield return new WaitForSeconds(10);
        restText.text = "";
        isPlayerResting = false;
    }
}