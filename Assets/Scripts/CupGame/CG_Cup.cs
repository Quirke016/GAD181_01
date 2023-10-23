using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Cup : MonoBehaviour
{
  
    public bool ballUnderThis = false;
    public bool ballSelected = false;
    public bool showTime = false;
    public bool selectTime = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ballUnderThis && !showTime && !selectTime)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if (ballSelected && !showTime && selectTime)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        else if (ballSelected && !showTime && !selectTime)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }

     
    }
}
