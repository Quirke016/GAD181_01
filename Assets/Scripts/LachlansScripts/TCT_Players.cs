using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TCT_Players : MonoBehaviour
{
    #region Vars
    public int playerOnePoints;
    public int playerTwoPoints;
    public int playerThreePoints;
    public int playerFourPoints;

    public int playerOneCounter;
    public int playerTwoCounter;
    public int playerThreeCounter;
    public int playerFourCounter;

    public TextMeshProUGUI red;
    public TextMeshProUGUI green;
    public TextMeshProUGUI blue;
    public TextMeshProUGUI yellow;
    public TextMeshProUGUI timer;

    bool gameStarted = false;
    bool gameOver = false;
    float timeLeft = 45;

    float gameTimer; 

    #endregion
    void Start()
    {
        playerOnePoints = 0;
        playerTwoPoints = 0;
        playerThreePoints = 0;
        playerFourPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            playerOnePoints++;
            Debug.Log("P1");
            gameStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerTwoPoints++;
            Debug.Log("P2");
            gameStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            playerThreePoints++;
            Debug.Log("P3");
            gameStarted = true;
        }
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            playerFourPoints++;
            Debug.Log("P4");
            gameStarted = true;
        }

        red.SetText(playerOnePoints.ToString());

        green.SetText(playerTwoPoints.ToString());

        blue.SetText(playerThreePoints.ToString());

        yellow.SetText(playerFourPoints.ToString());


        if (gameStarted)
        {
            // start animations



            bool hasbegun = true;
            if (hasbegun)
            {
                StartCoroutine(CountDown());
                hasbegun = false;
            }

            timer.SetText(timeLeft.ToString() + "seconds");
            
            if (timeLeft <= 0)
            {
                gameOver = true;
            }
        }
        if (gameOver)
        {
            Debug.Log("game ended");
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        timeLeft--;
        StartCoroutine(CountDown());

    }

}
