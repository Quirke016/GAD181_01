using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFallPlatform : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    [SerializeField] private bool active = false;
    [SerializeField] private bool destroy = false;
    [SerializeField] private bool killState = false;
    [SerializeField] private float gameTimer;
    [SerializeField] private float timer;
    public float interval;
    public SpriteRenderer tf_spriteRenderer;
    public TheFallPlayer player;
    public TheFallGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if(tf_spriteRenderer == null)
        {
            tf_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if(gameManager == null)
        {
            gameManager = FindObjectOfType<TheFallGameManager>();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (killState == true)
        {
            player.kill = true;
            Destroy(gameManager.playersList[0]);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Is in trigger");
        if (killState == true)
        {
            player.kill = true;
        }
    }




    // Update is called once per frame
    void Update()
    {
        interval = gameManager.platformInterval;
        gameTimer = Time.time;

        if (gameTimer < interval)
        {

            timeToDestroy = gameManager.platformLife[0];
        }

        if (gameTimer > interval && gameTimer < (interval + interval))
        {
            
            timeToDestroy = gameManager.platformLife[1];
        }

        if (gameTimer > interval + interval && gameTimer < interval + interval + interval)
        {
            
            timeToDestroy = gameManager.platformLife[2];
        }

        if (gameTimer > interval + interval + interval)
        {
            
            timeToDestroy = gameManager.platformLife[3];
        }

        //When the platform is stepped on it begins a timer until it is destroyed
        if (active == true)
        {
            SetTimer();
            active = false;
            destroy = true;
            tf_spriteRenderer.color = Color.yellow;
        }

        if(destroy == true)
        {
            if (gameTimer >= timer)
            {
                tf_spriteRenderer.color = Color.red;
                killState = true;
            }
        }

    }

    void SetTimer()
    {
        timer = gameTimer + timeToDestroy;
    }
}
