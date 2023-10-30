using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class CG_Control : MonoBehaviour
{
    CG_Cup lastButton = null;
    // Start is called before the first frame update
    void Start()
    {

        xyOffSet = new Vector3(0.335f, 0.36f, 0f);
        nxyOffSet = new Vector3(-0.335f, 0.36f, 0f);
    }

    Vector3 xyOffSet;
    Vector3 nxyOffSet;
    // Update is called once per frame
    void Update()
    {

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
            CG_Cup button = col.gameObject.GetComponent<CG_Cup>();
            if (button != null && button.selectTime == true) //
            {
                button.ballSelected = true;
                lastButton = button;
            }
            else
            {
                if (lastButton != null)
                    lastButton.ballSelected = false;
            }
        }
        else
        {
            if (lastButton != null)
                lastButton.ballSelected = false;
        }
    }
}
