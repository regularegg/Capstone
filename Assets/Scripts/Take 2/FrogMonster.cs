using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMonster : Monster
{
    public Sequence SQ;
    public float speed = 0;
    public Animator Anim;
    public AudioSource AS;
    public AudioClip Attack;

    // Start is called before the first frame update
    void Start()
    {
        StartPos.x = Random.Range(-5, 5);
        transform.position = StartPos;
        speed = Improved_GameManager.GM.speed;
        Anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
    }

    /*override protected void Update ()
    {
        
    }*/

    void Update()
    {
        if (Activated)
        {
            Move();
        }

        if (transform.position.y < -10)
        {
            Deactivate();
        }
    }

    void Move()
    {
        transform.position += Vector3.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AS.Play();
        }
    }
}
