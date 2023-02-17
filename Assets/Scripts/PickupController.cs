using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{


    public GameObject hintmessage;
    public float pickupRange = 2.0f;
    public GameObject win;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position,
                transform.TransformDirection(Vector3.forward), out RaycastHit hit, pickupRange))
            {
                PickupObject(hit.transform.gameObject);
            }
        }
    }

    void PickupObject(GameObject pickObj)
    {
       

        if (pickObj.CompareTag("hint"))
        {
            Destroy(pickObj);
            hintmessage.SetActive(true);
            Destroy(hintmessage, 3);
        }
        else if (pickObj.CompareTag("key"))
        {
            Destroy(pickObj);
            flag = true;
        }
        else if (pickObj.CompareTag("exit") & flag == true)
        {
            win.SetActive(true);
        }
       }
    
}
