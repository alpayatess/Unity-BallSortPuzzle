using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICONTROLLER : MonoBehaviour
{
    public GameObject endPanel;
    public bool isLevelOver;
    public bool set;


    void Start()
    {

        if (PlayerPrefs.GetInt("log") == 0)
        {
            PlayerPrefs.SetInt("chosenlvl", 1);
            PlayerPrefs.SetFloat("score", 0);
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("log", 1);
        }

    }

    void Update()
    {
        

    }
    public void levelPassed()
    {
        if (PlayerPrefs.GetInt("chosenlvl") == PlayerPrefs.GetInt("level"))
        {
            IncreaseLevel();
        }
        isLevelOver = true;
        endPanel.SetActive(true);
    }

    public void BackToLevelMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseLevel()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

    }
}





