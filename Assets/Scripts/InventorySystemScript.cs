using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystemScript : MonoBehaviour
{
    public GameObject highlight;
    public GameObject[] items = {null, null, null, null, null}; 
    public GameObject[] icons;
    public GameObject itemShow;
    private bool hasPetFood = false;


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
        if(Input.GetKeyDown(KeyCode.K)){ 
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

        if(Input.GetKeyDown(KeyCode.Q)){
            itemShow.SetActive(false);
        }


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

        highlight.transform.position = icons[currentObject].transform.position;
    }

    public GameObject GetCurrentObject(){
        return items[currentObject];
    }

    public bool addToInventory(GameObject item, Sprite icon){
        for(int i = 0; i < 5; i++){
            if(items[i] == null){
                items[i] = item;
                icons[i].GetComponent<Image>().sprite = icon;

                if (item.GetComponent<InteractableScript>().isPetFood)
                {
                    hasPetFood = true;
                }


                return true;
            }
        }
        return false;
    }

    public void removeFromInventory(GameObject item){
        for(int i = 0; i < 5; i++){
            if(items[i] == item){
                items[i] = null;
                icons[i].GetComponent<Image>().sprite = null;

                if (item.GetComponent<InteractableScript>().isPetFood)
                {
                    hasPetFood = false;
                }
            }
        }
    }

    public bool HasPetFood()
    {
        return hasPetFood;
    }


}
