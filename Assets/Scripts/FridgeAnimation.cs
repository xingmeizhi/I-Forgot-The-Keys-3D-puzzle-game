using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeAnimation : MonoBehaviour
{


    public float raycastDistance = 10f;

    public Animator animFridge;

    public GameObject targetObject;

    public AudioSource Fridgeopenaudio;
    public AudioSource Fridgecloseaudio;

    private bool open = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerNear() && open)
        {
            playClose();
        }
        else if (Input.GetKeyDown(KeyCode.E) && IsPlayerNear() && !open)
        {
            playOpen();
        }

        bool IsPlayerNear()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.gameObject == targetObject)
                {
                    return true;
                }
            }
            return false;
        }


    }

    public void playOpen()
    {
        animFridge.Play("FridgeOpen");
        open = true;
        Fridgeopenaudio.Play();
    }

    public void playClose()
    {
        animFridge.Play("FridgeClose");
        open = false;
        Fridgecloseaudio.Play();
    }
}
