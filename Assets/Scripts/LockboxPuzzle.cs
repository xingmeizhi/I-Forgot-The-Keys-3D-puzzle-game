using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockboxPuzzle : MonoBehaviour
{
    public GameObject puzzle;
    public TMP_Text[] values;

    // Start is called before the first frame update
    void Start()
    {
        
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
        CheckAnswer();
    }

    void CheckAnswer(){
        int ans = 0;
        foreach(TMP_Text t in values){
            ans = ans * 10;
            ans = ans + int.Parse(t.text);
        }
        if(ans == 0718){
            Solved();
        }
    }

    void Solved(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzle.GetComponent<PuzzleScript>().Solved();
        gameObject.SetActive(false);
    }

    public void IncreaseNum(TMP_Text text){
        int currentNum = int.Parse(text.text);
        currentNum++;
        if(currentNum == 10){
            currentNum = 0;
        }
        text.text = currentNum.ToString();
    }

    public void DecreaseNum(TMP_Text text){
        int currentNum = int.Parse(text.text);
        currentNum--;
        if(currentNum == -1){
            currentNum = 9;
        }
        text.text = currentNum.ToString();
    }
}
