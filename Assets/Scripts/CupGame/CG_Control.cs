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

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPosition;
        Collider2D col = Physics2D.OverlapPoint(transform.position);
        if (col != null)
        {
            CG_Cup button = col.gameObject.GetComponent<CG_Cup>();
            if (button != null)
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
