using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class STORECONTROLLER : MonoBehaviour
{
    public Transform[] trans;
    public GameObject[] go;
    public Transform transObj;
    public int count;
    public static int blueBallCount;
    public static int purpleBallCount;




    void Start()
    {
        trans = new Transform[4];
        go = new GameObject[4];
        for (int i = 4; i < transform.childCount; i++)
        {
            trans[i - 4] = transform.GetChild(i);

        }
    }

    void Update()
    {


    }
    public GameObject ChoosenBall()
    {
        return go[count - 1];

    }


    public Transform yerDon()
    {
        Transform tempa = trans[count];
        countIncrease();
        return tempa;
    }

    public Transform ballPos()
    {
        return trans[count];
    }

    public bool isOver()
    {
        return true;
    }

    public void countIncrease()
    {
        count++;
    }
    public void countDecrease()
    {
        count--;
    }

    public void SetBallInList(GameObject ball)
    {
        go[count - 1] = ball;

    }
    public void PopBallInList()
    {
        go[count - 1] = null;
        countDecrease();
    }

    public void AddBallInList(GameObject ball2)
    {
        if (count == 0)
        {
            go[0] = ball2;
            count++;
        }
        else
        {
            go[count] = ball2;
            countIncrease();

        }
    }


    public bool storeIsFull(Color col)
    {
        if (count == 4 && col == go[3].GetComponent<BALLCOLOR>().ballColor )
        {
            if ((go[0].GetComponent<BALLCOLOR>().ballColor == go[1].GetComponent<BALLCOLOR>().ballColor) && (go[2].GetComponent<BALLCOLOR>().ballColor == go[3].GetComponent<BALLCOLOR>().ballColor) && go[1].GetComponent<BALLCOLOR>().ballColor == go[2].GetComponent<BALLCOLOR>().ballColor)
            {
                return true;
            }
            else
                return false;
        }
        return false;

    }

}
