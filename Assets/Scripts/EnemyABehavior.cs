using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyABehavior : MonoBehaviour
{
    //enemy that appears at top of screen and zig zags down
    public Vector3 target;

    public float speed;

    public bool arrivedAtTarget = false;
    public bool onScreen = false;

    public HazardGenBetter HG;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-5f, 5f), -5f);
        target = new Vector3(3, transform.position.y + 3f);
        HG = FindObjectOfType<HazardGenBetter>();
    }

    IEnumerator moveToTarget(Vector3 target)
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        float startX = transform.position.x;
        float startY = transform.position.y;
        float inc = 0.0001f;
        //while (transform.position.y != target.y)
        while (inc < 0.99f)
        {
            //move enemy towards new point in an exponential curve
            float currX = Mathf.Lerp(startX, target.x, inc);
            float currY = Mathf.Lerp(startY, target.y, inc);

            inc = Mathf.Pow(inc,speed);
            
            Debug.Log(currX + " " + currY + "inc: " + inc);
            transform.position = new Vector3(currX,currY);
            yield return wait;
        }

        //update the target position for next round
        arrivedAtTarget = true;
    }

    void Update()
    {
        
        if (transform.position.y > GameManager.GM.ymax)
        {
            HG.MonstersLeft--;
            Destroy(gameObject);
        }
        if (arrivedAtTarget)
        {
            Debug.Log("new target");
            target = new Vector3(transform.position.x * -1, transform.position.y + 3f);

            arrivedAtTarget = false;
            StartCoroutine(moveToTarget(target));
        }

    }
    
    
}
