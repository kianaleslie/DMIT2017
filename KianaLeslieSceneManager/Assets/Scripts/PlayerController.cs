using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed;
    float rotateSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    public HealthUI health;
    //[SerializeField] GameObject followPlayer;
    //public bool isSaved;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 15.0f;
        rotateSpeed = 50.0f;
        //isSaved = false;
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bulletObject = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            bulletObject.GetComponent<Rigidbody>().velocity = bulletObject.transform.TransformDirection(Vector3.forward * 15.0f);
            Destroy(bulletObject, 2.0f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            health.DealDamage(3);
            if (health.health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("FriendSpot"))
    //    {
    //        if (!isSaved)
    //        {
    //            isSaved = true;
    //            GameObject friend = GameObject.FindGameObjectWithTag("Friend");
    //            friend.transform.SetParent(followPlayer.transform);
    //            friend.transform.localPosition = Vector3.zero;
    //            friend.transform.localRotation = followPlayer.transform.localRotation;
    //        }
    //    }
    //}
}