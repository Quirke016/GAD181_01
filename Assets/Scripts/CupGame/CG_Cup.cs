using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Cup : MonoBehaviour
{
  
    public bool ballUnderThis = false;
    public bool ballSelected = false;
    public bool showTime = false;
    public bool selectTime = false;
    public bool testing = false;
    SpriteRenderer m_SpriteRenderer;
    public Sprite cupUp;
    public Sprite cupDown;

    // Start is called before the first frame update
    void Start()
    {
        testing = false;

        m_SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!testing)
        {
            if (ballUnderThis && !showTime && !selectTime)
            {
                m_SpriteRenderer.sprite = cupUp;
                m_SpriteRenderer.color = Color.white;
            }
            else if (ballSelected && !showTime && selectTime)
            {
                m_SpriteRenderer.color = Color.black;
            }
            else if (ballSelected && !showTime && !selectTime)
            {
                m_SpriteRenderer.material.color = Color.blue;
            }
            else
            {
                m_SpriteRenderer.sprite = cupDown;
                //m_SpriteRenderer
                m_SpriteRenderer.color = Color.white;
                    //.material.SetColor("_Color", Color.white);
                //this.gameObject.GetComponent<SpriteRenderer>().sprite = cupDown;
            }
            

        }
        else
        {
            if (ballUnderThis) {  }
            else {  }



        }

    }
}
