using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableScript : MonoBehaviour
{

    public Sprite icon; //icon for item
    public string itemInfo; //later replace with UI

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickedUp(){
        if(FindObjectOfType<InventorySystemScript>().addToInventory(gameObject, icon)){
            gameObject.SetActive(false);
            Debug.Log("Added to inventory."); //Replace with a message for player?
        } else {
            Debug.Log("Inventory Full."); //Replace with a message for player
        }
    }

    public void Selected(){
        Debug.Log(itemInfo);
        
        //TODO: Later replace with an image for canvas which is the icon/clue the interactable gives
    }

    public void PutDown(){
        gameObject.SetActive(true);
        Debug.Log("Removed from inventory");
    }
}