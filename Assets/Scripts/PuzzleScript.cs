using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject[] inside; //items behind locked item
    public bool solved = false;

    public Animator animator;
    public AudioSource dooraudio;

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
        if(animator != null){
            animator.Play("doorOpen");
        }
        if(dooraudio != null){
            dooraudio.Play();
        }

        foreach (GameObject i in inside){
            i.SetActive(true);
        }
    }
}
