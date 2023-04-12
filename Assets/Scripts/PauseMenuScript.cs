using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject settingsMenu;
    public GameObject Tutorial;
    public GameObject pauseMenu;

    bool isMenuOpen = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) ){
            if(isGamePaused){
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    void PauseGame(){
        isGamePaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame(){
        isGamePaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        CloseTutorial();
        CloseSettings();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene(0); //<- change when main menu is created
        Time.timeScale = 1f;
        isGamePaused = false;
        CloseTutorial();
        CloseSettings();
    }
    
    public void ExitGame(){
        Application.Quit();
    }

    public void ShowTutorial(){
        if(isMenuOpen){
            CloseSettings();
        }
        isMenuOpen = true;
        Tutorial.SetActive(true);
    }

    public void ShowSettings(){
        if(isMenuOpen){
            CloseTutorial();
        }
        isMenuOpen = true;
        settingsMenu.SetActive(true);
    }

    public void CloseTutorial(){
        isMenuOpen = false;
        Tutorial.SetActive(false);
    }

    public void CloseSettings(){
        isMenuOpen = false;
        settingsMenu.SetActive(false);
    }
}
