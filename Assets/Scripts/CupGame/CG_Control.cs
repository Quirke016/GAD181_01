using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class CG_Control : MonoBehaviour
{
    public int timeScore;
    public int timesCheated;

    public CG_Shuffle shuffleScript;


    CG_Cup lastButton = null;
    // Start is called before the first frame update
    void Start()
    {
        shuffleScript = GameObject.Find("Table").GetComponent<CG_Shuffle>(); // Get the renfenct to stuffle script component 


        xyOffSet = new Vector3(0.335f, 0.36f, 0f);
        nxyOffSet = new Vector3(-0.335f, 0.36f, 0f);
    }

    Vector3 xyOffSet;
    Vector3 nxyOffSet;
    // Update is called once per frame
    void Update()
    {
        bool showTimeC = shuffleScript.cupColors[0].showTime;
        bool selectTimeC = shuffleScript.cupColors[0].selectTime;


        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);


        float distanceFromMid = 0.5f;



        if (worldPosition.x > 0)
        {

            transform.position = worldPosition - nxyOffSet;
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);

        }
        else
        {
            transform.position = worldPosition - xyOffSet;
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }


        if ((distanceFromMid * -1) < worldPosition.x && worldPosition.x < distanceFromMid)
        {
            Debug.Log("work6s");
            
            transform.localScale = new Vector3(transform.position.x * -0.5f, transform.localScale.y, transform.localScale.z);
            transform.position = worldPosition - new Vector3(nxyOffSet.x* transform.position.x, nxyOffSet.y, 0);
            //transform.position = transform.position* transform.position.x;
        }



        Collider2D col = Physics2D.OverlapPoint(transform.position);
        if (col != null)
        {
            CG_Cup cgCup = col.gameObject.GetComponent<CG_Cup>();

            



            if (cgCup != null && cgCup.selectTime == true) //
            {
                cgCup.ballSelected = true;
                lastButton = cgCup;


                
            }
            else
            {
                if (lastButton != null)
                    lastButton.ballSelected = false;
            }


            //check to see if you go the ext round with the cup withb the ballunder selected
            if (Input.GetKeyDown(KeyCode.Space) && cgCup.ballUnderThis && cgCup != null && cgCup.ballSelected)
            {
                timeScore += 1;
                Debug.Log("Points Scored is " + timeScore);


            }



        }
        else
        {
            if (lastButton != null)
                lastButton.ballSelected = false;
        }



        if (Input.GetKeyDown(KeyCode.M) && selectTimeC && !showTimeC)
        {
            timesCheated += 1;
            Debug.Log("times cheat is " + timesCheated);
        }


        Debug.Log("test02  ShowTime " + showTimeC + "     SelectTime " + selectTimeC);


    }
}
