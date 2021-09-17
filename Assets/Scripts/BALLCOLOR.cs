using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALLCOLOR : MonoBehaviour
{
    public Renderer ballRend;
    public Color ballColor;


    // Start is called before the first frame update
    void Start()
    {
        ballRend = transform.GetChild(0).GetComponent<Renderer>();
        ballColor = ballRend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
