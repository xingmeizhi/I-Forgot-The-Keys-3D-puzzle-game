using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystemScript : MonoBehaviour
{
    public GameObject[] items = {null, null, null, null, null}; 
    public Image[] icons;

    public int currentObject;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++){
            items[i] = null;
        }
        currentObject = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){ // TODO : Add highlights to inventory system, if time
            currentObject++;
            if(currentObject >= 5){
                currentObject = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.J)){
            currentObject--;
            if(currentObject < 0){
                currentObject = 4;
            }
        }

        //TODO: Change Highlights of inventory system here


        if(Input.GetKeyDown(KeyCode.Return)){
            if(items[currentObject] != null){
                items[currentObject].GetComponent<InteractableScript>().Selected();
            }
        }

        if(Input.GetKeyDown(KeyCode.F)){
            if(items[currentObject] != null){
                items[currentObject].GetComponent<InteractableScript>().PutDown();
                removeFromInventory(items[currentObject]);
            }
        }
    }

    public GameObject GetCurrentObject(){
        return items[currentObject];
    }

    public bool addToInventory(GameObject item, Sprite icon){
        for(int i = 0; i < 5; i++){
            if(items[i] == null){
                items[i] = item;
                icons[i].sprite = icon;
                return true;
            }
        }
        return false;
    }

    public void removeFromInventory(GameObject item){
        for(int i = 0; i < 5; i++){
            if(items[i] == item){
                items[i] = null;
                icons[i].sprite = null;
            }
        }
    }
}
