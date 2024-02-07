using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameObject pauseMenu;
    private static bool isGamePaused = false;
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadPauseMenu()
    {
        if (pauseMenu != null)
        {
            isGamePaused = !isGamePaused;

            pauseMenu.SetActive(isGamePaused);
            Time.timeScale = isGamePaused ? 0 : 1;
        }
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}