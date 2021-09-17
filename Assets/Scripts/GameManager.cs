using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public bool chosenOne;
    public bool isStoreOver;

    public GameObject[] storeList;
    public GameObject[] ballList;

    GameObject temp;
    Vector3 piv;
    Vector3 onPiv;
    Vector3[] path = new Vector3[2];

    //Raycast process
    RaycastHit hitObject;
    RaycastHit preHitObject;

    int a, b;
    int blueCount, purpleCount, redCount, blackCount;
    int fullStore;

    UICONTROLLER UICont;
    Color tempColor;

    // Time process
    public bool timerActive = true;
    public float currentTime;


    void Start()
    {
        UICont = GameObject.FindGameObjectWithTag("canvas").GetComponent<UICONTROLLER>();
        ballCreate();
    }

    void Update()
    {
        if (timerActive)
        {
            timeGoing();
        }


        if (!UICont.isLevelOver)
        {
            transportShpere();
        }


    }

    public void ballCreate()
    {

        for (int i = 0; i < (storeList.Length - 1) * 4; i++)
        {
            a = StoreCountCheck();
            Transform temp = storeList[a].GetComponent<STORECONTROLLER>().yerDon();

            b = BallCountCheck();
            increaseColor(b);
            GameObject sphereObj = Instantiate(ballList[b], temp.position, Quaternion.identity, storeList[a].transform);
            storeList[a].GetComponent<STORECONTROLLER>().SetBallInList(sphereObj);
        }
    }
    public int StoreCountCheck()
    {
        int a1 = Random.Range(0, storeList.Length);
        if (storeList[a1].GetComponent<STORECONTROLLER>().count < 4)
        {
            return a1;
        }
        else
        {
            return StoreCountCheck();
        }
    }
    public int BallCountCheck()
    {
        int b2 = Random.Range(0, ballList.Length);
        if (blueCount < 4)
        {
            return 0;
        }
        if (purpleCount < 4)
        {
            return 1;
        }
        if (redCount < 4)
        {
            return 2;
        }
        if (blackCount < 4)
            return 3;
        else
        {
            return 100;
        }

    }
    public void increaseColor(int b1)
    {
        if (b1 == 0)
        {
            blueCount++;
        }
        if (b1 == 1)
        {
            purpleCount++;
        }
        if (b1 == 2)
        {
            redCount++;
        }
    }

    private void transportShpere()
    {
        Ray cameraRay = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hitObject))
        {
            if (hitObject.collider.gameObject.tag == "store" && Input.GetMouseButtonDown(0))
            {
                if (temp == null)
                {
                    temp = hitObject.transform.GetComponent<STORECONTROLLER>().ChoosenBall();
                    tempColor = temp.GetComponent<BALLCOLOR>().ballColor;
                    piv = temp.transform.position;
                    onPiv = new Vector3(piv.x, 4.5f, piv.z);
                }

                if (!chosenOne && temp != null)
                {
                    setRay(hitObject);
                    chosenOne = true;
                    temp.transform.DOMove(onPiv, 0.25f).SetEase(Ease.Flash);
                    hitObject.transform.GetComponent<STORECONTROLLER>().PopBallInList();

                }
                else if (chosenOne && !hitObject.Equals(preHitObject) && hitObject.transform.GetComponent<STORECONTROLLER>().count < 4)
                {
                    chosenOne = false;
                    path[0] = new Vector3(hitObject.transform.position.x, 4.5f, hitObject.transform.position.z);// gideceği yerin trans objsi üst
                    path[1] = hitObject.transform.GetComponent<STORECONTROLLER>().ballPos().position; // gideceği yerin transı
                    temp.transform.DOPath(path, 0.25f);
                    hitObject.transform.GetComponent<STORECONTROLLER>().AddBallInList(temp);



                    temp = null;
                }
                else if (hitObject.Equals(preHitObject))
                {
                    chosenOne = false;
                    temp.transform.position = piv;
                    hitObject.transform.GetComponent<STORECONTROLLER>().AddBallInList(temp);
                    temp = null;
                }


                // STORELAR DOLDU MU?
                if (hitObject.transform.GetComponent<STORECONTROLLER>().storeIsFull(tempColor))
                {
                    fullStore++;
                }

                // LEVEL SONU
                if (hitObject.transform.GetComponent<STORECONTROLLER>().count == 4 && fullStore == ballList.Length)
                {
                    timerActive = false;
                    PlayerPrefs.SetFloat("score", currentTime);
                    UICont.levelPassed();
                }

            }
        }
    }

    public void setRay(RaycastHit rayy)
    {
        preHitObject = rayy;
    }




    public void timeGoing()
    {
        currentTime += Time.deltaTime;
    }


}
