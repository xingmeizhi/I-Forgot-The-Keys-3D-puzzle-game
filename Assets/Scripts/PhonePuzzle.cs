using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhonePuzzle : MonoBehaviour
{
    public GameObject puzzle;
    
    public TMP_Text t;
    public Button[] buttons;


    Queue<int> nums = new Queue<int>();
    int[] answer = {3, 0, 0, 7, 7, 3, 3, 5, 8, 6}; //phone numbers too large for ints
    // Start is called before the first frame update
    void Start()
    {
        nums.Clear(); //start with 4 0s
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);
        nums.Enqueue(0);

        foreach(Button b in buttons){
            Button btn = b.GetComponent<Button>();
            btn.onClick.AddListener(delegate {ButtonClicked(btn.name);});
        }
    }

    void AddNumber(int n){ // keeps the number amount
        nums.Enqueue(n);
        nums.Dequeue();
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
        DisplayNumbers();
    }

    void DisplayNumbers(){
        int index = 0;
        string text = "";
        bool win = true;
        foreach(int i in nums){
            text = text + i;
            if(index == 2 || index == 5){
                text = text + "-";
            }
            if(i != answer[index]){
                win = false;
            }
            index++;
        }
        t.text = text;
        if(win){
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
