using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject[] inside; //items behind locked item
    public bool solved = false;

    // Start is called before the first frame update
    void Start()
    {
        solved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractedWith(){
        if(!solved){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            puzzle.SetActive(true);
        }
    }

    public void Solved(){
        solved = true;
        //TODO: Add animation for opening in here, possibly in seperate script
        //replace itself with open area

        foreach (GameObject i in inside){
            i.SetActive(true);
        }
    }
}
