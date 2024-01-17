using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReplayManager : MonoBehaviour
{
    //movement variables 
    public InputAction moveAction;
    Vector2 moveValue;
    float moveSpeed;

    //rotation variables
    public InputAction rotateAction;
    Vector2 rotateValue;
    float rotateSpeed;

    //lists to keep x,y,z values
    List<int> xValue;
    List<int> yValue;
    List<int> zValue;

    void Start()
    {
        moveSpeed = 12.0f;
        rotateSpeed = 150.0f;
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();

        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotateValue.y * rotateSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            //record
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
    }
}