using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string CS1, level1, level2, level3;

    public void StartGame()
    {
        SceneManager.LoadScene(CS1);
    }

    public void ContinueGame()
    {
        if(PlayerPrefs.GetInt("currentLevel", 0) == 0)
        {
            SceneManager.LoadScene(level1);
        }

        if (PlayerPrefs.GetInt("currentLevel", 1) == 1)
        {
            SceneManager.LoadScene(level2);
        }

        if (PlayerPrefs.GetInt("currentLevel", 2) == 2)
        {
            SceneManager.LoadScene(level3);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
