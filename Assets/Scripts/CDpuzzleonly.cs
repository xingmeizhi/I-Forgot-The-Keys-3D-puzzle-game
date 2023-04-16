using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDpuzzleonly : MonoBehaviour
{

    public GameObject puzzle;
    public GameObject[] inside; //items behind locked item
    public bool solved = false;
    public GameObject player;

    public Animator animator;

    public AnimationClip clip;

    public AudioSource solveAudio;


    // Start is called before the first frame update
    void Start()
    {
        solved = false;
        player = GameObject.FindGameObjectWithTag("MainCamera");

        if (player == null)
        {
            Debug.LogError("Player object not found");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void InteractedWith()
    {
        Debug.Log("Interacted with puzzle");

        npcAI npc = GameObject.FindGameObjectWithTag("cat").GetComponent<npcAI>();

        if (!solved && npc.isCathere())
        {
            player.GetComponent<PlayerInteraction>().ChangeSolvingPuzzle(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            puzzle.SetActive(true);
        }
    }


    public void Solved()
    {
        solved = true;

        if (animator != null)
        {
            Debug.Log("Playing animation: " + clip.name);
            animator.Play(clip.name);
        }
        if (solveAudio != null)
        {
            Debug.Log("Playing solve audio");
            solveAudio.Play();
        }

        player.GetComponent<PlayerInteraction>().ChangeSolvingPuzzle(false);



        foreach (GameObject i in inside)
        {
            i.SetActive(true);
        }
    }
}
