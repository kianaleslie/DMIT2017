using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public InputAction movementAction;
    Vector2 movementValue;

    public float currentSpeed = 5.0f;
    float timer;
    float countdown;

    bool isUpdating = true;
    bool isTimerRunning = false;
    bool isFinished = false;
    bool isLeaderboardUpdated = false;
    bool hasSpeedBoost = false;

    [SerializeField] public TMP_Text timerText;
    [SerializeField] public TMP_Text currentSpeedText;
    [SerializeField] public GameObject ghostUI;
    public List<GhostPosition> ghost;
    SaveController saveController;

    void Start()
    {
        timer = 0.0f;
        countdown = 30.0f;
        saveController = new SaveController();
        saveController = DataManager.LoadData();
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
                if (countdown > 0)
                {
                    countdown -= Time.deltaTime;
                    timerText.text = $"Time: {countdown.ToString("0.0")}";
                }
                if (timer < 30)
                {
                    timer += Time.deltaTime;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            hasSpeedBoost = true;
            currentSpeed += 5.0f;
            collision.gameObject.SetActive(false);
            StartCoroutine(RemoveSpeedBoost());
        }
        else
            if (collision.gameObject.CompareTag("Obstacle"))
        {
            currentSpeed -= 2.0f;
            collision.gameObject.SetActive(false);
            StartCoroutine(ReturnRegularSpeed());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            isTimerRunning = false;
            timerText.text = $"Time: {countdown.ToString("0.0")}";
            isFinished = true;
            if (!isLeaderboardUpdated)
            {
                isLeaderboardUpdated = true;
                FinishGame();
            }
            Time.timeScale = 0f;
            ghostUI.SetActive(true);
        }
    }
    IEnumerator RemoveSpeedBoost()
    {
        yield return new WaitForSeconds(3.0f);
        currentSpeed -= 5.0f;
        hasSpeedBoost = false;
    }
    IEnumerator ReturnRegularSpeed()
    {
        yield return new WaitForSeconds(1.5f);
        currentSpeed += 5.0f;
    }
    IEnumerator Acceleration()
    {
        isUpdating = false;
        //if(currentSpeed < 14.0f)
        //{
        //    for(int i = 0; i < currentSpeed; i++)
        //    {
        //        yield return new WaitForSeconds(1.0f);
        //        currentSpeed++;
        //    } 
        //}
        yield return new WaitForSeconds(1.0f);
        currentSpeed = 7.0f;
        yield return new WaitForSeconds(1.0f);
        currentSpeed = 9.0f;
        yield return new WaitForSeconds(1.0f);
        currentSpeed = 10.0f;
        yield return new WaitForSeconds(1.0f);
        currentSpeed = 11.0f;
        yield return new WaitForSeconds(1.0f);
        currentSpeed = 14.0f;
        yield return new WaitForSeconds(1.0f);
        currentSpeed = 16.0f;
        //isUpdating = true;
    }
    public void OverwriteGhostData()
    {
        saveController = DataManager.LoadData();
        saveController.profiles[DataManager.currentIndex].ghostData.vehicleType = saveController.profiles[DataManager.currentIndex].vehicleType;
        saveController.profiles[DataManager.currentIndex].ghostData.ghostPos = ghost;
        DataManager.SaveData(saveController);
    }
    public void FinishGame()
    {
        GetComponent<PlayerSaveData>().SaveTime(timer);
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