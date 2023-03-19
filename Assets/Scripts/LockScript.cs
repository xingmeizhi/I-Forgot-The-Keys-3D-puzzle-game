using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public GameObject keyLock; //the key to unlock the lock
    public GameObject[] inside; //items behind locked item

    public Animator animator;

    public AnimationClip openClip;
    public AnimationClip closeClip;
    
    public AudioSource openaudio;
    public AudioSource closeaudio;

    public bool isFinalLock;

    

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

        if (isFinalLock)
        {
            FindObjectOfType<LevelManager>().LevelBeat();
        }


    }
    

    private void playOpen()
    {
        animator.Play(openClip.name);
        openaudio.Play();
    }

    private void playClose()
    {
        animator.Play(closeClip.name);
        closeaudio.Play();
    }
}
