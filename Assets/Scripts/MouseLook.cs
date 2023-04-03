using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    Transform playerbody;

    public float mouseSensitivity = 10;

    float pitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerbody = transform.parent.transform;

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteraction>().GetSolvingPuzzle()){
            float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            playerbody.Rotate(Vector3.up * moveX);

            pitch -= moveY;


            pitch = Mathf.Clamp(pitch, -90f, 90f);
            transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        }
    }
}
