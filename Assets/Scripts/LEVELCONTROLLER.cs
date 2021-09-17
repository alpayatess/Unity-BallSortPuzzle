using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LEVELCONTROLLER : MonoBehaviour
{
    public Button[] levelBTN;

    public Text levelText;
    public int choosenLevelint;

    Image img;


    public float scoreStar;
    public float maxScore = 100f;


    void Start()
    {


        for (int i = 0; i < PlayerPrefs.GetInt("level"); i++)
        {
            if (levelBTN.Length > i)
            {
                levelBTN[i].interactable = true;

            }
        }
        Debug.Log(PlayerPrefs.GetInt("chosenlvl"));
        Debug.Log(PlayerPrefs.GetInt("level"));

        if (PlayerPrefs.GetInt("chosenlvl") != PlayerPrefs.GetInt("level"))
        {
            //imageFill();
        }


    }
    private void Update()
    {

    }

    public void OpenLevel()
    {
        PlayerPrefs.SetInt("chosenlvl", int.Parse(GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().GetComponentInChildren<Text>().text));
        SceneManager.LoadScene(PlayerPrefs.GetInt("chosenlvl"));

    }
    //public void imageFill()
    //{
    //    float scoreST = 100 - PlayerPrefs.GetFloat("score");
    //    if (scoreST > 66)
    //    {
    //        Debug.Log("2  " + PlayerPrefs.GetInt("chosenlvl"));

    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[0].fillAmount = 1;
    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[1].fillAmount = 1;
    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[2].fillAmount = scoreST / 100;

    //    }
    //    else if (scoreST < 66 && scoreST > 33)
    //    {
    //        Debug.Log("2  " + PlayerPrefs.GetInt("chosenlvl"));

    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[0].fillAmount = 1;
    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[1].fillAmount = scoreST / 100;
    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[2].fillAmount = 0;

    //    }
    //    else
    //    {
    //        Debug.Log("2  " + PlayerPrefs.GetInt("chosenlvl"));

    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[0].fillAmount = scoreST / 100;
    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[1].fillAmount = 0;
    //        levelBTN[PlayerPrefs.GetInt("chosenlvl")-1].GetComponent<BUTTON>().stars[2].fillAmount = 0;

    //    }

    //}

}

