using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    public GameObject hazardPrefab1;

    public int enemyToGenerate;

    public GameObject[] hazards;

    public int numHazards = 5;
    

    //premade hazard formations from easiest to hardest
    public GameObject[] HazardArrays;

    
    //Things to consider:
    //1. enemy "difficulty"
    //2. enemy speed scaling
    //3. how often are sewer jerks gna come out
    //4. how many different types of enemies are there???
    //Potentially fun additions:
    //       a. enemies shooting projectiles
    //       b. powerups
    
    
    
    
    void Start()
    {
       /* hazards = new GameObject[numHazards];
        for (int i = 0; i < numHazards; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-5,5), (i+2)*5);
            hazards[i] = Instantiate(hazardPrefab1, pos, Quaternion.identity);
        }
        
       */
    }

    // Update is called once per frame
    void Update()
    {/*
        foreach (GameObject Darrel in hazards)
        {
            Darrel.transform.position += Vector3.down * 0.1f;
            if (Darrel.transform.position.y < -10)
            {
                Darrel.transform.position = new Vector3(Random.Range(-5,5), Random.Range(5,10));
            }
        }*/
        
    }
}
