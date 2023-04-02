using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CDPuzzleScript : MonoBehaviour
{
    public GameObject puzzle;
    
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Button b in buttons){
            Button btn = b.GetComponent<Button>();
            btn.onClick.AddListener(delegate {ButtonClicked(btn);});
        }
    }

    //ANSWER for puzzle: 4935 (DICE)
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteraction>().ChangeSolvingPuzzle(false);
            gameObject.SetActive(false);
        }
        CheckNumbers();
    }

    void CheckNumbers(){
        int ans = 0;
        foreach(Button b in buttons){
            Button btn = b.GetComponent<Button>();
            TMP_Text t = btn.gameObject.GetComponentInChildren<TMP_Text>();
            ans = ans * 10;
            ans = ans + int.Parse(t.text);
        }
        if(ans == 4935){
            Solved();
        }
    }

    void Solved(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzle.GetComponent<CDpuzzleonly>().Solved();
        gameObject.SetActive(false);
    }

    void ButtonClicked(Button btn){
        GameObject button = btn.gameObject;
        TMP_Text text = button.GetComponentInChildren<TMP_Text>();
        int currentNum = int.Parse(text.text);
        currentNum++;
        if(currentNum == 10){
            currentNum = 0;
        }
        text.text = currentNum.ToString();
    }
}
