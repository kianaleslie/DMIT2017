using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{ 
    public InputAction movementAction;
    Vector2 movementValue;
    public float currentSpeed = 0.0f;
    bool isUpdating = true;

    void Start()
    {

    }
    void Update()
    {
        movementValue = movementAction.ReadValue<Vector2>();

        if(!isUpdating && Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Acceleration());
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            StopCoroutine(Acceleration());
            isUpdating = false;
        }
        transform.Translate(new Vector3(movementValue.x, 0, movementValue.y) * currentSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("SpeedBoost"))
        {
            currentSpeed += 5.0f;
            collision.gameObject.SetActive(false);
            StartCoroutine(RemoveSpeedBoost());
        }
        else 
            if(collision.gameObject.CompareTag("Obstacle"))
        {
            currentSpeed -= 5.0f;
            collision.gameObject.SetActive(false);
        }
    }
    IEnumerator RemoveSpeedBoost()
    {
        yield return new WaitForSeconds(3.0f);
        currentSpeed -= 5.0f;
    }
    IEnumerator Acceleration()
    {
        isUpdating = false;
        currentSpeed = 3.0f;
        yield return new WaitForSeconds(2.0f);
        currentSpeed = 5.0f;
        yield return new WaitForSeconds(2.0f);
        currentSpeed = 7.0f;
        yield return new WaitForSeconds(2.0f);
        currentSpeed = 9.0f;
        yield return new WaitForSeconds(2.0f);
        currentSpeed = 11.0f;
        yield return new WaitForSeconds(2.0f);
        currentSpeed = 14.0f;
        //isUpdating = true;
    }
    //public void FinishGame()
    //{
    //    GetComponent<PlayerSaveData>().SaveScore(score);
    //}
    private void OnEnable()
    {
        movementAction.Enable();
    }
    private void OnDisable()
    {
        movementAction.Disable();
    }
}