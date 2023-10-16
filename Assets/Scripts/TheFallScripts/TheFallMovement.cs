using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheFallMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float playerX = -3.5f;
    [SerializeField] private float playerY = 1.5f;
    

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector2(playerX, playerY);

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W pressed");
            PlayerOneMoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S pressed");
            PlayerOneMoveDown();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D pressed");
            PlayerOneMoveRight();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A pressed");
            PlayerOneMoveLeft();
        }
    }

    void PlayerOneMoveUp()
    {
        playerY = playerY + moveSpeed;
    }
    void PlayerOneMoveDown()
    {
        playerY = playerY - moveSpeed;
    }

    void PlayerOneMoveRight()
    {
        playerX = playerX + moveSpeed;
    }

    void PlayerOneMoveLeft()
    {
        playerX = playerX - moveSpeed;
    }
}
