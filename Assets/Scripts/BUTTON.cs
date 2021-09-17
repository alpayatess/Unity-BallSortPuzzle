using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUTTON : MonoBehaviour
{

    public Image[] stars;
    public float[] score;


    void Start()
    {
        stars = new Image[3];
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i] = transform.GetChild(i + 1).GetComponent<Image>();
        }
    }

    void Update()
    {

    }





}
