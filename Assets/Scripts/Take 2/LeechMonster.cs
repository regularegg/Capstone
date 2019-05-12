using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechMonster : Monster
{
    public Sequence SQ;
    public Vector3 Target;

    private bool _Alive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            
        }
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
