using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableScript : MonoBehaviour
{

    public Sprite icon; //icon for item
    public string itemInfo; //later replace with UI
    public Sprite itemShow;
    public GameObject toShowItem;
    public AudioClip pickupSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickedUp(){
        if(FindObjectOfType<InventorySystemScript>().addToInventory(gameObject, icon)){
            PlayPickupSound();
            gameObject.SetActive(false);
            Debug.Log("Added to inventory."); //Replace with a message for player?

        } else {
            Debug.Log("Inventory Full."); //Replace with a message for player
        }
    }

    public void Selected(){
        Debug.Log(itemInfo);
        
        toShowItem.GetComponent<Image>().sprite = itemShow;
        toShowItem.SetActive(true);
    }

    public void PutDown(){
        gameObject.SetActive(true);
        Debug.Log("Removed from inventory");
    }

    void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            AudioManager.Instance.PlayOneShot(pickupSound);
        }
    }


}