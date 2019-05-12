using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaclesMonster : Monster
{
    
    public Sequence SQ;
    public float speed = 0;
    public Animator Anim;
    public AudioSource AS;
    public AudioClip Attack;
    
    public bool arrivedAtTarget = false;

    
    // Start is called before the first frame update
    void Start()
    {
        if (Activated)
        {
            if (arrivedAtTarget)
            {
                Debug.Log("new target");
                Target = new Vector3(transform.position.x * -1, transform.position.y + 3f);

                arrivedAtTarget = false;
                StartCoroutine(MoveToTarget());
            }
        }

        if (transform.position.y < OffScreen)
        {
            Deactivate();
        }
    }

    
   
    IEnumerator MoveToTarget()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        
        float startX = transform.position.x;
        float startY = transform.position.y;
        float inc = 0.0001f;
        //while (transform.position.y != target.y)
        while (inc < 0.99f)
        {
            //move enemy towards new point in an exponential curve
            float currX = Mathf.Lerp(startX, Target.x, inc);
            float currY = Mathf.Lerp(startY, Target.y, inc);

            inc = Mathf.Pow(inc,speed);
            
            transform.position = new Vector3(currX,currY);
            yield return wait;
        }

        //update the target position for next round
        arrivedAtTarget = true;
    }
}
