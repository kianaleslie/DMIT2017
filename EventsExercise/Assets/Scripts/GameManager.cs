using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ui variables
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject playAgainUI;

    //game handler variables
    [SerializeField] GameObject[] coins;
    float counter;
    int score;
    float timer;
    bool hasGameEnded = false;

    void Start()
    {
        timer = 30.0f;
        playAgainUI.SetActive(false);

        EventManager.SpawnCoin.AddListener(SpawnCoin);
        EventManager.CollectCoin.AddListener(CollectCoin);
    }
    void Update()
    {
        //if the game hasn't ended the timer starts and coins start spawning
        if (!hasGameEnded)
        {
            if (timer > 0)
            {
                if (counter > 0)
                {
                    counter -= Time.deltaTime;
                }
                else
                {
                    EventManager.SpawnCoin.Invoke();
                    counter = 2.0f;
                }
                scoreText.text = $"Score: {score}";
                timerText.text = $"Time: {timer.ToString("0.0")}";
                timer -= Time.deltaTime;
            }
            else
            {
                EndGame();
            }
        }
    }
    void EndGame()
    {
        Time.timeScale = 0f;
        playAgainUI.SetActive(true);
        hasGameEnded = true;    
    }
    void SpawnCoin()
    {
        Vector3 randomSpawn = new Vector3(Random.Range(-3.0f, 3.0f), 1, Random.Range(-9.0f, 1.0f));
        int randomIndex = Random.Range(0, coins.Length);
        Instantiate(coins[randomIndex], randomSpawn, coins[randomIndex].transform.rotation);
    }
    void CollectCoin(int value)
    {
        score += value;
    }
}