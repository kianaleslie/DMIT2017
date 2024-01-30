using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public InputAction movementAction;
    Vector2 movementValue;

    public float currentSpeed = 0.0f;
    float timer = 30.0f;

    bool isUpdating = true;
    bool isTimerRunning = false;
    bool isFinished = false;

    [SerializeField] public TMP_Text timerText;
    [SerializeField] public TMP_Text currentSpeedText;
    [SerializeField] public GameObject ghostUI;
    public List<GhostPosition> ghost;
    SaveController saveController;
    SaveLoadManager saveLoadManager;

    void Start()
    {
        saveController = new SaveController();
        saveLoadManager = new SaveLoadManager();
        ghostUI.SetActive(false);
        ghost = new List<GhostPosition>();
    }
    void Update()
    {
        //player can move as long as the game is not finished
        if (!isFinished)
        {
            GhostPosition ghostPosition = new GhostPosition();
            ghostPosition.x = gameObject.transform.position.x;
            ghostPosition.y = gameObject.transform.position.y;
            ghostPosition.z = gameObject.transform.position.z;
            ghost.Add(ghostPosition);

            movementValue = movementAction.ReadValue<Vector2>();
            if (!isUpdating && Input.GetKeyDown(KeyCode.W))
            {
                isTimerRunning = true;
                StartCoroutine(Acceleration());
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                StopCoroutine(Acceleration());
                isUpdating = false;
            }
            transform.Translate(new Vector3(movementValue.x, 0, movementValue.y) * currentSpeed * Time.deltaTime);
            currentSpeedText.text = $"Current Speed: {currentSpeed}";
            if (isTimerRunning)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                    timerText.text = $"Time: {timer}";
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            currentSpeed += 5.0f;
            collision.gameObject.SetActive(false);
            StartCoroutine(RemoveSpeedBoost());
        }
        else
            if (collision.gameObject.CompareTag("Obstacle"))
        {
            currentSpeed -= 5.0f;
            collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            isTimerRunning = false;
            timerText.text = $"Time: {timer}";
            isFinished = true;
            Time.timeScale = 0f;
            ghostUI.SetActive(true);
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
    public void OverwriteGhostData()
    {
        saveController.profiles[saveController.currentIndex].ghostData.vehicleType = saveController.profiles[saveController.currentIndex].vehicleType;
        saveController.profiles[saveController.currentIndex].ghostData.ghostPos = ghost;
        saveLoadManager.SaveData();
    }
    public void FinishGame()
    {
        GetComponent<PlayerSaveData>().SaveScore(timer);
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