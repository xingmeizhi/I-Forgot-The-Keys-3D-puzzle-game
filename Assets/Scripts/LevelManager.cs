using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float levelDuration = 180.0f;
    public Text timerText;
    public Text gameText;
    public string nextLevel;

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
        audioSource.clip = bgm;
        audioSource.Play();
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
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
        timerText.text = countDown.ToString("f2");
    }

    public void LevelLost()
    {
        isGameOver = true;
        gameText.text = "GAME OVER";
        gameText.gameObject.SetActive(true);
        gameText.color = Color.red;
        audioSource.Stop();


        Invoke("LoadCurrentLevel", 2);

    }

    public void LevelBeat()
    {
        isGameOver = true;
        gameText.text = "YOU ESCAPE";
        gameText.color = Color.green;
        gameText.gameObject.SetActive(true);
        audioSource.Stop();

        if (!string.IsNullOrEmpty(nextLevel))
        {
            Invoke("LoadNextLevel", 2);
        }


    }

    void LoadNextLevel()
    {
        audioSource.Play();
        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
