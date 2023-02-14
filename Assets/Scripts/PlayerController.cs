using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;

    CharacterController controller;
    Vector3 input;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        input = transform.right * moveHorizontal + transform.forward * moveVertical;

        input *= moveSpeed;

        controller.Move(input * Time.deltaTime);

    }
}
