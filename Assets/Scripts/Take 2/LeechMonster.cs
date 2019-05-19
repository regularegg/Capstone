using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechMonster : Monster
{
    public Sequence SQ;
    public Vector3 Target;
    public SpriteRenderer SR;

    public bool isAttacking, alive;
    public float speed = 0.1f;
    public AudioClip Attack_Clip;



    void MeMove()
    {
        float xMove = Mathf.Sin(Time.frameCount) * 0.01f;
        transform.position += Vector3.down * speed + Vector3.right * xMove;
    }
    
    void Start()
    {
        AS.GetComponent<AudioSource>();
        alive = true;
        AS.clip = Attack_Clip;
        Anim = GetComponent<Animator>();
        hitAnim = "LeechAnim";
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            MeMove();
        }

        if (transform.position.y < OffScreen)
        {
            Deactivate();
        }
    }
}
