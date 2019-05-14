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

    public AudioSource AS;
    public AudioClip Attack_Clip;



    void Move()
    {
        float xMove = Mathf.Sin(Time.frameCount * 0.1f);
        transform.position += Vector3.down * speed + Vector3.right * xMove;
    }
    
    void Start()
    {
        alive = true;
        AS.clip = Attack_Clip;
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
            Deactivate();
        }
    }
    /*
    private int _action;
    public int action
    {
        get { return _action;}
        set
        {
            switch (value)
            {
                   case 1: findRandomTarget();
                       StartCoroutine(MoveToTarget());
                       break;
                   case 2: findRandomTarget();
                       StartCoroutine(MoveToTarget());
                       break;
                   case 3: StartCoroutine(Charge());
                       break;
                   case 4: alive = false;
                       break;
            }
            _action = value;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        action = 1;
        alive = true;
        AS.clip = Attack_Clip;
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            if (!alive)
            {
                Debug.Log("going");
                transform.position += Vector3.down * 0.5f;
            }
        }

        if (transform.position.y < OffScreen)
        {
            Deactivate();
        }
    }

    void findRandomTarget()
    {
        Target = new Vector3(Random.Range(-4,4), Random.Range(10,-10));
    }

    IEnumerator MoveToTarget()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        float dist = 0;
        Vector3 localStartPos = transform.position;
        while (dist < 1)
        {
            transform.position = Vector3.Lerp(localStartPos,Target, dist);
            dist += 0.01f;
            yield return wait;
        }

        action++;
    }
    
    IEnumerator Charge()
    {
        //Nice to have in the future: a red ring around toot to tell palyer it is being targetted
        
        isAttacking = true;
        Target = FindObjectOfType<BoatMove>().transform.position;
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        float charge = 0;
        while (charge < 3f)
        {
            charge += 0.3f;
            SR.color = new Color(charge, 1, 1);
            
            Debug.Log("waiting");
            yield return wait;
            
        }

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        
        float dist = 0;
        Vector3 localStartPos = transform.position;
        while (dist < 1)
        {
            transform.position = Vector3.Lerp(localStartPos,Target, dist);
            dist += 0.01f;
            
            Debug.Log("Attacking");
            yield return wait;
        }

        action++;
        Debug.Log(action);
        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fefef");
        if (other.transform.CompareTag("Player"))
        {
            AS.Play();
        }
    }*/
}
