using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMonster : Monster
{
    public Sequence SQ;
    public float speed = 0.1f;
    public Animator Anim;
    public AudioSource AS;
    public AudioClip Attack;

    // Start is called before the first frame update
    void Start()
    {
        speed = Improved_GameManager.GM.speed;
        Anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        AS.clip = Attack;
        Anim.enabled = false;
        //TEMP
    }

    /*override protected void Update ()
    {
        
    }*/

    void Update()
    {
        if (Activated)
        {
            Move();

            if (transform.position.y < OnScreen)
            {
                //Anim.enabled = true;
                ///Anim.Play("Attack");
            }
            if (transform.position.y < OffScreen)
            {
                Deactivate();
            }
        }
    }

    void Move()
    {
        transform.position += Vector3.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            AS.Play();
        }
    }
}
