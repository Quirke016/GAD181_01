using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class TheFallBorder : MonoBehaviour
{
    public TheFallPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<TheFallPlayer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.kill = true;
    }
}
