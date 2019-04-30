using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] Enemies;

    public List<GameObject> ActiveEnemies;

    public int Difficulty = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateHazard()
    {
        while (true)
        {
            if (ActiveEnemies.Count < 5)
            {
                if (Difficulty == 0)
                {
                    
                }else if (Difficulty == 1)
                {
                    
                }else if (Difficulty == 2)
                {
                    
                }else if (Difficulty == 3)
                {
                    
                }
                else
                {
                    
                }
            }
        }
        
    }

    void InstantiateLeech()
    {
        
    }

    void InstantiateGas()
    {
        
    }
}
