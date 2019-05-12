using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mary
public class Monster : MonoBehaviour
{
    protected bool Activated = false;
    //Target Position to Move to
    protected Vector3 Target, StartPos = new Vector3(0,-10,0);
    protected bool Alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    protected virtual void Update ()
    {
        Debug.Log("PowerUp");
    }*/

    public void Move()
    {
        
    }
    
    public void Activate()
    {
        Activated = true;
        
    }

    public void Deactivate()
    {
        
    }
    public void PlaySound()
    {
        
    }
}
