using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMonster : Monster
{

    
    
    // Start is called before the first frame update
    void Start()
    {
        StartPos.x = Random.Range(-5, 5);
        GetComponent<Transform>().position = StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        while (Alive)
        {
            yield return wait;
        }  
    }
        
}
