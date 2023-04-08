using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedChestPuzzle : MonoBehaviour
{
    public GameObject puzzle;

    public Toggle[] beTrue;
    public Toggle[] beFalse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteraction>().ChangeSolvingPuzzle(false);
            gameObject.SetActive(false);
        }
        CheckAnswer();
    }

    void CheckAnswer(){
        bool solved = true;
        foreach(Toggle t in beTrue){
            if(!t.isOn){
                solved = false;
            }
        }
        foreach(Toggle t in beFalse){
            if(t.isOn){
                solved = false;
            }
        }
        if(solved){
            Solved();
        }
    }

    void Solved(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzle.GetComponent<PuzzleScript>().Solved();
        gameObject.SetActive(false);
    }
}
