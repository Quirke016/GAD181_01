using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFallPlatform : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    [SerializeField] private bool active = false;
    [SerializeField] private bool destroy = false;
    [SerializeField] private float gameTimer;
    [SerializeField] private float timer;
    [SerializeField] private SpriteRenderer tf_spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        tf_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer = Time.time;

        if (gameTimer < 10)
        {
            timeToDestroy = 2;
        }

        if (gameTimer > 10 && gameTimer < 20)
        {
            timeToDestroy = 1.5f;
        }

        if (gameTimer > 20 && gameTimer < 30)
        {
            timeToDestroy = 1;
        }

        if (gameTimer > 30)
        {
            timeToDestroy = 0.5f;
        }

        //When the platform is stepped on it begins a timer until it is destroyed
        if (active == true)
        {
            SetTimer();
            active = false;
            destroy = true;
            
        }

        if(destroy == true)
        {
            if (gameTimer >= timer)
            {
                tf_spriteRenderer.color = Color.red;
            }
        }
    }

    void SetTimer()
    {
        timer = gameTimer + timeToDestroy;
    }
}
