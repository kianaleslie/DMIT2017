using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction movementAction;
    Vector2 movementValue;
    float initialSpeed;
    float fullSpeed;

    void Start()
    {
        initialSpeed = 4.0f;
        fullSpeed = Time.deltaTime * initialSpeed;
    }
    void Update()
    {
        movementValue = movementAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(movementValue.x, 0, movementValue.y) * initialSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        movementAction.Enable();
    }
    private void OnDisable()
    {
        movementAction.Disable();
    }
}