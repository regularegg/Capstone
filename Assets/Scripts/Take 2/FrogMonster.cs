using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMonster : Monster
{
    public Sequence SQ;
    public float speed = 0.1f;
    public Animator Anim;
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

    void Update()
    {
        if (Activated)
        {
            MeMove();

            if (transform.position.y < OnScreen)
            {
                Anim.enabled = true;
                Anim.Play("Attack");
            }
            if (transform.position.y < OffScreen)
            {
                Deactivate();
            }
        }
    }

    void MeMove()
    {
        transform.position += Vector3.down * speed;
    }

   
}
