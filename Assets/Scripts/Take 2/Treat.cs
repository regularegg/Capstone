using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mary
public class Treat : Monster
{
    public Vector3 StartPos;
    public float speed;
    public SpriteRenderer SR;

    public Sprite[] Sprites;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartPos.x = Random.Range(-5, 5);
        GetComponent<Transform>().position = StartPos;
        speed = Improved_GameManager.GM.speed;
        SR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            Move();
        }

        if (transform.position.y < OffScreen)
        {
            ResetTreat();
        }
    }
    
    void Move()
    {
        transform.position += Vector3.down * speed;
    }

    void ResetTreat()
    {
        Deactivate();
        SR.sprite = Sprites[Random.Range(0, 2)];
    }
}
