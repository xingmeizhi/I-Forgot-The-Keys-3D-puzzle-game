using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoardAnimation : MonoBehaviour
{


    public float raycastDistance = 10f;

    public Animator anim;

    public GameObject targetObject;

    public AudioSource openaudio;
    public AudioSource closeaudio;

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
            anim.Play("CupBoardClose");
            open = false;
            closeaudio.Play();
        }
        else if (Input.GetKeyDown(KeyCode.E) && IsPlayerNear() && !open)
        {
            anim.Play("CupBoardOpen");
            open = true;
            openaudio.Play();
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
}
