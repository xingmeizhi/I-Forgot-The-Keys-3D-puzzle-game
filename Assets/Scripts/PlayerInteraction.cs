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
                    if(hit.collider.CompareTag("lock") || hit.collider.CompareTag("exit")){
                        Debug.Log("lock");
                        var lockScript = hit.transform.gameObject.GetComponent<LockScript>();
                        lockScript.InteractedWith(FindObjectOfType<InventorySystemScript>().GetCurrentObject());
                    }
                    if(hit.collider.CompareTag("puzzle")){
                        Debug.Log("puzzle");
                        var puzzleScript = hit.transform.gameObject.GetComponent<PuzzleScript>();
                        puzzleScript.InteractedWith();
                    }
            }
        }
    }
}
