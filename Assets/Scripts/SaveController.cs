using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public bool level1, level2, level3;

    void Start()
    {
        if(level1 == true)
        {
            PlayerPrefs.SetInt("currentLevel", 0);
        }
        if (level2 == true)
        {
            PlayerPrefs.SetInt("currentLevel", 1);
        }
        if (level3 == true)
        {
            PlayerPrefs.SetInt("currentLevel", 2);
        }
    }
}
