using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI dialogText;

    public GameObject playerResponse1;
    public GameObject playerResponse2;
    public AudioSource thunderSound;
    public AudioSource crySound;
    public GameObject umbrella;
    public GameObject reloadUI;

    bool hasResponded = false;

    void Start()
    {
        sentences = new Queue<string>();
        playerResponse1.SetActive(false);
        playerResponse2.SetActive(false);
        umbrella.SetActive(false);
        reloadUI.SetActive(false);
    }

    private void Update()
    {
        if (hasResponded)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Respond(true);
        }
        else
            if (Input.GetKeyDown(KeyCode.N))
        {
            Respond(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartDialog(Dialog dialog)
    {
        Debug.Log("conversation start");
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
        }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
        if (sentence.Contains("Oh no! Looks like a storm is brewing!"))
        {
            playerResponse1.SetActive(true);
        }
        if (sentence.Contains("I can help you!"))
        {
            playerResponse2.SetActive(true);
        }
    }

    public void Respond(bool response)
    {
        if (response)
        {
            if (playerResponse1.activeSelf)
            {
                thunderSound.Play();
                StartCoroutine(Wait());
                playerResponse1.SetActive(false);
            }
            else if (playerResponse2.activeSelf)
            {
                umbrella.SetActive(true);
                StartCoroutine(Wait());
                playerResponse2.SetActive(false);
            }
        }
        else
        {
            crySound.Play();
            StartCoroutine(Wait());
            playerResponse1.SetActive(false);
            playerResponse2.SetActive(false);
        }
        hasResponded = true;

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
    }
    public void EndDialog()
    {
        reloadUI.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}