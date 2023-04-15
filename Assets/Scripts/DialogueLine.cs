using System.Collections;
using UnityEngine;
using UnityEngine.UI;


//Learn the code follow the tutorial from https://www.youtube.com/watch?v=8eJ_gxkYsyY 
//Undertale DIALOGUE|CUTSCENE in Unity (Episode 1)
namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {

        private Text textHolder;

        [Header ("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }

        public bool Finished
        {
            get { return finished; }
        }
    }
}