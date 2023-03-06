using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
        

public class OvenPuzzle : MonoBehaviour
{
    public GameObject puzzle;
    
    public TMP_Text t;
    public Button[] buttons;


    Queue<int> nums = new Queue<int>();
    // Start is called before the first frame update
    void Start()
    {
        nums.Clear(); //start with 4 0s
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);

        foreach(Button b in buttons){
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
            gameObject.SetActive(false);
        }
        DisplayNumbers();
    }

    void AddNumber(int n){ // keeps the number amount at 4
        nums.Enqueue(n);
        nums.Dequeue();
    }

    //display numbers, check if solved
    void DisplayNumbers(){
        int index = 0;
        string text = "";
        int num = 0;
        foreach(int i in nums){
            text = text + i;
            if(index == 1){
                text = text + ":";
            }
            num = num * 10;
            num = num + i;
            index++;
        }
        t.text = text;
        if(num == 356){
            Solved();
        }
    }

    void Solved(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzle.GetComponent<PuzzleScript>().Solved();
        gameObject.SetActive(false);
    }

    void ButtonClicked(string name){
        AddNumber(int.Parse(name));
    }
}