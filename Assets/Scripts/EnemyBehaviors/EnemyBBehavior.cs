using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NAME: CHASER
public class EnemyBBehavior : MonoBehaviour
{
    //enemy that ducks underwater and tries to chase the player
    //chases for 10 seconds and gets tired and gets washed away

    //phase 1. come alive - start chasing player
    //phase 2. chase player
    //phase 3. deactivate and get swept away
    
    public GameObject target;

    public bool Active = false;

    public bool underwater;
    public Collider2D coll;

    public float speed = 0.005f;
    public float dangerRadius = 0.2f;

    public HazardGenBetter HG;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-5f, 5f), -5f);
        coll = GetComponent<Collider2D>();

        target = GameObject.FindWithTag("Player");
        Active = true;
        HG = FindObjectOfType<HazardGenBetter>();
        StartCoroutine(liveCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        //if target distance is within 2 units 
        if (Vector3.Distance(transform.position,target.transform.position) < dangerRadius)
        {
            underwater = false;
            coll.enabled = false;
        }
        else
        {
            underwater = true;
            coll.enabled = true;
        }

        if (Active)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position,speed);
        }

        if (!Active)
        {
            //start drowning and get offscreen
            //1. play deactivate animation
            //2. start sliding off the screen
            //3. once offscreen, self destruct
            
            transform.position += Vector3.down * GameManager.GM.RiverSpeed;
            if (transform.position.y < GameManager.GM.ymin)
            {
                Destroy(gameObject);
                HG.MonstersLeft--;
            }
        }
    }

    IEnumerator liveCountdown()
    {
        int count = 0;
        WaitForSeconds wait = new WaitForSeconds(1);

        while (count < 10)
        {
            count++;
            yield return wait;
        }
        Debug.Log("I am ded");

        //maybe play a running out of energy animation
        Active = false;
    }

}
