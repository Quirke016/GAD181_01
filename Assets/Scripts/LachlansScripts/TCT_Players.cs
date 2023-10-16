using System.Collections;
using System.Collections.Generic;
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

    float gameTimer; 

    #endregion
    // Start is 
    // Start is called before the first frame update
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
        
    }

    void PlayerOne()
    {
        if (Input.GetKeyDown(KeyCode.~))
        {
            playerOneCounter++;
            playerOnePoints++;
        }
    }

    void PlayerTwo()
    {
        if (Input.GetKeyDown(KeyCode.~))
        {
            playerTwoCounter++;
            playerTwoPoints++;
        }
    }

    void PlayerThree()
    {
        if (Input.GetKeyDown(KeyCode.~))
        {
            playerThreeCounter++;
            playerThreePoints++;
        }
    }

    void PlayerFour()
    {
        if (Input.GetKeyDown(KeyCode.~))
        {
            playerFourCounter++;
            playerFourPoints++;
        }
    }




}
