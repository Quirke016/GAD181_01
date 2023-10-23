using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFallGameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<GameObject> playersList = new List<GameObject>();
    public List<Vector3> playersPosition = new List<Vector3>();
    public List<float> platformLife = new List<float>();
    public int playersToSpawn;
    public float platformInterval;
    public float playerIdle;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn();
        playerIdle = platformLife[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIdle > 0)
        {
            playerIdle -= Time.deltaTime;
        }
        else
        {
            Debug.Log("player was idle");
            Destroy(playersList[0]);
        }
    }

    private void PlayerSpawn()
    {   
        if(playerPrefab != null)
        {
            for (int i = 0; i < playersToSpawn; i++)
            {
                GameObject clone = Instantiate(playerPrefab, playersPosition[i], Quaternion.identity);
                playersList.Add(clone);
                Debug.Log("Player" + (i + 1) + " Spawned");
            }
        }

    }
}
