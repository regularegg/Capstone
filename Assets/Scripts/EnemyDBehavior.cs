using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDBehavior : MonoBehaviour
{
    //Enemy that swoops in from the side and primarily moves horizontally

    public bool onLeftBank = false;
    public bool active = false;

    public float xTarget;
    
    public int swoops = 0;

    public float speed = 1f;
    public HazardGenBetter HG;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0,10)%2 == 0)
        {
            //if even, instantiate on the left bank
            transform.position = new Vector3(GameManager.GM.xmin, 
                Random.Range(GameManager.GM.ymin,GameManager.GM.ymax));

            onLeftBank = true;
        }
        else
        {
            //if odd, instantiate on right bank
            transform.position = new Vector3(GameManager.GM.xmax, 
                Random.Range(GameManager.GM.ymin,GameManager.GM.ymax));

            onLeftBank = false;
        }
        
        HG = FindObjectOfType<HazardGenBetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swoops < 3)
        {
            if (!active)
            {
                StartCoroutine(Perch());
            }
        }
        else
        {
            //fall into water and die
            transform.position+= Vector3.down;
            if (transform.position.y < GameManager.GM.ymin)
            {
                HG.MonstersLeft--;

                Destroy(gameObject);
            }
        }
    }

    IEnumerator Perch()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        int count = 0;
        active = true;

        if (count < 4)
        {
            yield return wait;
        }

        StartCoroutine(Swoop());
    }

    IEnumerator Swoop()
    {
        WaitForFixedUpdate wait = new WaitForFixedUpdate();
        float prog = 0;

        if (onLeftBank)
        {
            if (transform.position.x < xTarget)
            {
                transform.position += Vector3.right * speed;
                yield return wait;
            }
        }
        else
        {
            if (transform.position.x > xTarget)
            {
                transform.position += Vector3.left * speed;
                yield return wait;
            }
        }

        swoops++;
        active = false;
        
    }
}
