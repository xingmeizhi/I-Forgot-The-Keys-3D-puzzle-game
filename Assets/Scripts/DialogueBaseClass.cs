using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Learn the code follow the tutorial from https://www.youtube.com/watch?v=8eJ_gxkYsyY 
//Undertale DIALOGUE|CUTSCENE in Unity (Episode 1)
namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }

        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                AudioManager.Instance.PlayOneShot(sound);
                yield return new WaitForSeconds(delay);
            }

    
            finished = true;
        }



    }
}

