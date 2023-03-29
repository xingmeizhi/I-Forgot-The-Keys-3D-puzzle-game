using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayImage : MonoBehaviour
{
    public GameObject image;
    public Sprite showImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            image.SetActive(false);
        }
    }
    
    public void InteractedWith(){
        image.GetComponent<Image>().sprite = showImage;
        image.SetActive(true);
    }
}
