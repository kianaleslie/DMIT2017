using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    [SerializeField] TextMeshProUGUI treasureText;
    [SerializeField] TextMeshProUGUI restText;
    bool isPlayerResting;
    bool transition = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 30.0f;
        rotateSpeed = 65.0f;
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
                Destroy(bulletObject, 2.0f);
            }
        }
        if (transition)
        {
            SceneManager.LoadScene("Overworld", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(PlayerInfo.piInstance.currentScene);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            health.DealDamage(3);
            PlayerInfo.piInstance.health = health.health;
            if (health.health <= 0)
            {
                gameObject.SetActive(false);
                PauseMenuManager gameOver = GetComponent<PauseMenuManager>();
                gameOver.gameOverUI.SetActive(true);
            }
        }

        if (collision.gameObject.CompareTag("Treasure"))
        {
            PlayerInfo.piInstance.treasure += 1;
            collision.gameObject.SetActive(false);
            treasureText.text = $"Treasure Collected: {PlayerInfo.piInstance.treasure}";
            if (PlayerInfo.piInstance.treasure >= 3)
            {
                PauseMenuManager winUI = GetComponent<PauseMenuManager>();
                winUI.winUI.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inn") && !isPlayerResting)
        {
            isPlayerResting = true;
            health.ResetHealth(30);
            PlayerInfo.piInstance.health = health.health;
            treasureText.text = "";
            StartCoroutine(Rest());
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Inn"))
    //    {
    //        //if (!SceneManager.GetSceneByName("Overworld").isLoaded)
    //        //{
    //        //    SceneManager.LoadScene("Overworld");
    //        //    SceneManager.UnloadSceneAsync("Town1");
    //        //}

    //    }
    //}
    IEnumerator Rest()
    {
        restText.text = "Resting!";
        yield return new WaitForSeconds(5);
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