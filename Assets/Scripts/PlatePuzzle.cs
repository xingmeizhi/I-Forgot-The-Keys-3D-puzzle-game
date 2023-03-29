using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatePuzzle : MonoBehaviour
{
    public GameObject puzzle;
    public Button[] plates; //add plate texture to buttons


    public int[] pressed = {0, 0, 0, 0, 0};
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        for(int i = 0; i < 5; i++){
            pressed[i] = 0;
        }
        foreach(Button b in plates){
            Button btn = b.GetComponent<Button>();
            btn.onClick.AddListener(delegate {ButtonClicked(btn.name);});
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteraction>().ChangeSolvingPuzzle(false);
            gameObject.SetActive(false);
        }
    }

    void Solved(){
        Debug.Log("hi");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzle.GetComponent<PuzzleScript>().Solved();
        gameObject.SetActive(false);
    }

    void ButtonClicked(string name){
        pressed[index] = int.Parse(name);
        index++;
        Debug.Log(int.Parse(name));
        if(index == 5){
            //check if it's in the right order
            if(pressed[0] == 1 && pressed[1] == 2 && pressed[2] == 3 && pressed[3] == 4 && pressed[4] == 5){
                Solved();
            } else {
                for(int i = 0; i < 5; i++){
                    pressed[i] = 0;
                }
                index = 0;
            }
        }
    }
}
