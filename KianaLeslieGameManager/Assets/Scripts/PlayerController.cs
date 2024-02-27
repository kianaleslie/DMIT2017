using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public InputAction movementAction;
    //public InputAction rotationAction;
    //Vector2 movementValue;
    //Vector2 rotationValue;

    Rigidbody rb;
    //float verticleInput;
    //float horizontalInput;
    float moveSpeed;
    float rotateSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    public HealthUI health;
    [SerializeField] GameObject treasure;
    [SerializeField] TextMeshProUGUI treasureText;
    [SerializeField] TextMeshProUGUI restText;
    bool isPlayerResting;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 10.0f;
        rotateSpeed = 50.0f;
        isPlayerResting = false;
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
        //movementValue = movementAction.ReadValue<Vector2>();
        //rotationValue = rotationAction.ReadValue<Vector2>();

        if (!isPlayerResting)
        {
            //verticleInput = Input.GetAxis("Vertical");
            //horizontalInput = Input.GetAxis("Horizontal");

            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            //transform.Translate(new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, verticleInput * moveSpeed * Time.deltaTime));
            //transform.rotation = Quaternion.identity;

            //transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
            //rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed);

            //transform.Translate(new Vector3(movementValue.x, 0, movementValue.y) * moveSpeed * Time.deltaTime);
            //transform.Rotate(Vector3.up, rotationValue.x * rotateSpeed * Time.deltaTime);

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
    //private void OnEnable()
    //{
    //    movementAction.Enable();
    //    rotationAction.Enable();
    //}
    //private void OnDisable()
    //{
    //    movementAction.Disable();
    //    rotationAction.Disable();
    //}
}