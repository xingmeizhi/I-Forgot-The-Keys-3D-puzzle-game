using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public GameObject keyLock; //the key to unlock the lock
    public GameObject[] inside; //items behind locked item

    public Animator animator;


    public AudioSource openaudio;
    public AudioSource closeaudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractedWith(GameObject obj){
        /*if(keyLock != null){ //if it's automatically unlocked - TODO: move to script when it matters
            Debug.Log("nokey");
            Open();
        } else */if(obj == null){
            //nothing happens
        } else if(obj == keyLock){
            FindObjectOfType<InventorySystemScript>().removeFromInventory(obj);
            Open();
        }
    }

    void Open(){ 
        playOpen();

        foreach (GameObject i in inside){
            i.SetActive(true);
        }

        if(gameObject.tag == "exit"){
            Debug.Log("Won!");
            //TODO: add something to end current level and start next level
            //win condition

            FindObjectOfType<LevelManager>().LevelBeat();
        }
    }

    private void playOpen()
    {
        animator.Play("CupBoardOpen");
        openaudio.Play();
    }

    private void playClose()
    {
        animator.Play("CupBoardClose");
        closeaudio.Play();
    }
}
