using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class clowncarnival_ : MonoBehaviour
{

    // The spawn locations of for the aliens
    public GameObject Spawn1;
    public GameObject Spawn2;   
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;
    GameObject whatsSpawning;

    public GameObject Alien;

    // Start is called before the first frame update
    void Start()
    {
        AlienSpawn(); // The alien spawn function being called

    }

    IEnumerator WaitTillAlienSpawn()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Alien awaiting spawn");
        AlienSpawn();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void AlienSpawn()
    {
        int randomnumber;
        randomnumber = Random.Range(0, 5);
        

        if (randomnumber ==1)
        {
            whatsSpawning = Spawn1;

            Debug.Log("Alien 1 spawn");
        }

        if (randomnumber == 2)
        {
            whatsSpawning = Spawn2;
            Debug.Log("Alien 2 spawn");
        }
        
        if(randomnumber == 3)
        {
            whatsSpawning = Spawn3;
            Debug.Log("Alien 3 spawn");
        }

        if (randomnumber == 4)
        {
            whatsSpawning = Spawn4;
            Debug.Log("Alien 4 spawn");
        }

        if (randomnumber == 5)
        {
            whatsSpawning = Spawn5;
            Debug.Log("Alien 5 spawn");
        }


        Instantiate(Alien, whatsSpawning.transform.position, whatsSpawning.transform.rotation);
        StartCoroutine( WaitTillAlienSpawn());
    }
    
    
    
   
    
    
    



}
