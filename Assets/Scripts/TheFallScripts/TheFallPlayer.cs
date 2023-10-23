using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFallPlayer : MonoBehaviour
{
    public bool kill;
    public TheFallGameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<TheFallGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kill == true)
        {
            Destroy(gameObject);
        }
    }
}
