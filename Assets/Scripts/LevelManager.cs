using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DialogueSystem;

public class LevelManager : MonoBehaviour
{

    public float levelDuration = 180.0f;
    public Text timerText;
    public Text gameText;
    public string nextLevel;
    public DialogueLine dialogueLine;

    public static bool isGameOver = false;

    private AudioSource audioSource;
    public AudioClip bgm;

    float countDown;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        countDown = levelDuration;
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && bgm != null)
        {
            audioSource.clip = bgm;
            audioSource.Play();
        }
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueLine != null && dialogueLine.Finished)
        {
            Invoke("LoadNextLevel", 2);
        }

        if (!isGameOver)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                countDown = 0.0f;
                LevelLost();
            }
            SetTimerText();

        }
    }

    void SetTimerText()
    {
        if (timerText != null)
        {
            timerText.text = countDown.ToString("f2");
        }
    }

    public void LevelLost()
    {
        isGameOver = true;
        if (gameText != null)
        {
            gameText.text = "GAME OVER";
            gameText.gameObject.SetActive(true);
            gameText.color = Color.red;
        }
        if (audioSource != null)
        {
            audioSource.Stop();
        }


        Invoke("LoadCurrentLevel", 2);

    }

    public void LevelBeat()
    {
        isGameOver = true;
        if (gameText != null)
        {
            gameText.text = "YOU ESCAPE";
            gameText.color = Color.green;
            gameText.gameObject.SetActive(true);
        }
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        if (!string.IsNullOrEmpty(nextLevel))
        {
            Invoke("LoadNextLevel", 2);
        }


    }

    void LoadNextLevel()
    {
        if(audioSource != null) {
            audioSource.Play();
        }

        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
