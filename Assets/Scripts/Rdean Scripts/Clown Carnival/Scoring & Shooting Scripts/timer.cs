using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{

    public TextMeshProUGUI Timer;
    public float timernumber;
    

    // Start is called before the first frame update
    void Start()
    {
        timernumber = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timernumber -= Time.deltaTime;
        Timer.SetText(timernumber.ToString());

        CheckGameConditions();
    }


    public void CheckGameConditions()
    {
        if (timernumber == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
