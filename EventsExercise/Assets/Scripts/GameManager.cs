using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject playAgainUI;

    int score;
    int timer;

    void Start()
    {
        timer = 60;
        playAgainUI.SetActive(false);

        EventManager.SpawnCoin.AddListener(SpawnCoin);
        EventManager.CollectCoin.AddListener(CollectCoin);
    }
    void Update()
    {
        timer -= (int)Time.deltaTime;
        timerText.text = $"Time: {timer}";
    }
    void SpawnCoin()
    {

    }
    void CollectCoin(int value)
    {
        score += value; 
        scoreText.text = $"score: {score}";
    }
}