using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechMonster : Monster
{
    public Sequence SQ;
    public Vector3 Target;
    public SpriteRenderer SR;
    public int attacks = 0;

    public bool isAttacking, alive; 

    
    // Start is called before the first frame update
    void Start()
    {
        attacks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            if (attacks < 2 && !isAttacking)
            {
                
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
        Vector3 startpos = transform.position;
        while (dist < 1)
        {
            transform.position = Vector3.Lerp(startpos,Target, dist);
            yield return wait;
        }
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
            charge += 0.1f;
            SR.color = new Color(charge, 1, 1);
            yield return wait;
        }

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        
        float dist = 0;
        Vector3 startpos = transform.position;
        while (dist < 1)
        {
            transform.position = Vector3.Lerp(startpos,Target, dist);
            yield return wait;
        }

        isAttacking = false;
    }
}
