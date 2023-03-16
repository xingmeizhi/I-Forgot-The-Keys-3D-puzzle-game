using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public GameObject key; //the key to unlock the lock
    public GameObject[] inside; //items behind locked item

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractedWith(GameObject obj){
        if(key == null){
            Open();
        } else if(obj == null){
            //nothing happens
        } else if(obj == key){
            FindObjectOfType<InventorySystemScript>().removeFromInventory(obj);
            Open();
        }
    }

    void Open(){
        //TODO: play animation for opening item here, possibly from seperate script
        //replace itself with open area
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
}
