using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float pickupRange = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, pickupRange)) {
                    //interact with object
                    Debug.Log(hit.transform.gameObject.name);
                    if(hit.collider.CompareTag("pickup")){
                        Debug.Log("pickup");
                        var pickupScript = hit.transform.gameObject.GetComponent<InteractableScript>();
                        pickupScript.PickedUp();
                    }
                    //TODO: add lock interaction
                    //TODO: add puzzle interaction
                    //TODO: add exit interaction
            }
        }
    }
}
