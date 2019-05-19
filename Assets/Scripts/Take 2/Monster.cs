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
    protected Vector3 Target, StartPos;
    protected float OffScreen = -10f;
    protected float OnScreen = 10f;
    
    public Animator Anim;
    public string hitAnim;
    
    protected AudioSource AS;
    public int Row, Col;
    // Start is called before the first frame update
    void Start()
    {
        Activated = false;
        ReadyForPool = false;
    }
    public void Activate()
    {
        Debug.Log("calling for duty");
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
    public void setCol(int x) {
        //On screen between 0-4
        if (x == 0) {
            transform.position = new Vector3(-2.5f, transform.position.y);
        }
        if (x == 1) {
            transform.position = new Vector3(-1.25f, transform.position.y);
        }
        if (x == 2) {
            transform.position = new Vector3(-0f, transform.position.y);
        }
        if (x == 3) {
            transform.position = new Vector3(1.25f, transform.position.y);
        }
        if (x == 4) {
            transform.position = new Vector3(2.5f, transform.position.y);
        }
    }
    public void setRow(int y)
    {
        //Off screen starting at -1
        float scaledY = (y * -1.25f) + 4.25f;
        transform.position = new Vector3(transform.position.x, scaledY);
    }
    public void setPosition(int x, int y)
    {
        Debug.Log(string.Format("{0}{1}",x,y));
        //wrong
        //this.setCol(y);
        //this.setRow(x);
        //right
        this.setCol(x);
        this.setRow(y);
    }
    public void Deactivate()
    {
        Activated = false;
        transform.position = StartPos;
        ReadyForPool = true;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (other.GetComponent<BoatMove>().Alive)
            {
                AS.Play();
                Anim.Play(hitAnim);
            }
        }
    }
}