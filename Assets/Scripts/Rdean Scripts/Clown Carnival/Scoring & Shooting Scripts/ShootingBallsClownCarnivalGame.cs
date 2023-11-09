using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClowncarnivalShooting : MonoBehaviour
{

    public GameObject BallSpawn;
    public GameObject BallImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BallSpawnPoint();
    }

    public void BallSpawnPoint()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(BallImage, BallSpawn.transform.position, BallSpawn.transform.rotation);
            Debug.Log("Spacebar has been pressed!");
        }

        
    }
}
