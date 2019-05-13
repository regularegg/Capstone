using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

//Mary
public class Monster : MonoBehaviour
{
    protected bool Activated = false;

    public bool ReadyForPool;
    //Target Position to Move to
    protected Vector3 Target, StartPos = new Vector3(0,0,0);
    protected float OffScreen = -10f;
    protected bool Alive = true;

    public int Row, Col;
    
    // Start is called before the first frame update
    void Start()
    {
        Activated = false;
        ReadyForPool = false;
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
    
    //row() returns current "row"
    //setRow() if negative, sets row to above top of screen
    //setColumn()

    public int ReturnRow()
    {
        return Row;
    }
    
    public int ReturnCol()
    {
        return Col;
    }

    public void setRow(int x)
    {
        //On screen between 0-4
        float scaledX = (x - 2) * 1.25f;
        transform.position = new Vector3(scaledX,transform.position.y);
    }

    public void setCol(int y)
    {
        //Off screen starting at -1
        float scaledY = (y * 1.25f) - 5f;
        transform.position = new Vector3(transform.position.x, scaledY);
    }
    
    public void setPosition(int x, int y)
    {
        this.setRow(x);
        this.setCol(y);
    }
    
    public void Deactivate()
    {
        Activated = false;
        transform.position = StartPos;
        ReadyForPool = true;
    }
}
