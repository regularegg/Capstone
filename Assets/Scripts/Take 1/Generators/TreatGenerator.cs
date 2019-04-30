using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

//Generator that spawns a Treat Level prefab and moves it downwards. 
//When all the treats have been moved offscreen, tell GameManager to advance to next "level"
// and self destruct.

//SPECIAL CASE: If it is a tutorial level, then it will answer
//to the tutorial level manager instead of the overall Game Manager.
public class TreatGenerator : MonoBehaviour
{
    //Treat level set prefab (changes for each level)
    public GameObject TreatPrefab;

    //Tutorial level manager that it will answer to instead of GM
    public TutorialLevel TL;

    //Amount of treats in this prefab set
    public int AmountOfTreats;

    //Should we randomize treats or use premade level?
    public bool RandomizeTreats;

    //Speed of movement and increment speed - kind of redundant bc GM has its own speed
    public float increment = 0, speed;

    //If it has spent all of the treats in this 
    public bool infinite, canDie, TutorialLevel;

    
    
    // Start is called before the first frame update
    void Start()
    {
        //If this is a tutorial level, find the tutorial level manager and only instantiate treats
        //when it is told to.
        if (TutorialLevel)
        {
            TL = FindObjectOfType<TutorialLevel>();
            AmountOfTreats = 3;
        }
        StartCoroutine(IncrementSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        //If all the treats have been spawned and moved offscreen, this gameobject can "die" (destroy self)
        if (canDie)
        {
            //if it is a tutorial level, increment event in tutorial level manager
            if (TutorialLevel)
            {
                TL.currentEvent++;
            }

            //if it is a regular level, increment event in GameManager
            else
            {
                GameManager.GM.currentEvent++;
            }
            
            Destroy(gameObject);
        }
    }

    //Treat spawning coroutine
    IEnumerator IncrementSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(speed);

        //While there are still treats left to be spawned
        if (infinite)
        {
            while (true)
            {
                //If we want randomized treats instead of a premade treat set, spawn random treats.
                if (RandomizeTreats)
                {
                    //The amount of treats to be spawned in this particular row
                    int TreatThisRow = Random.Range(1, 3);
                    //Spawn each treat
                    for (int i = 0; i < TreatThisRow; i++)
                    {
                        Instantiate(TreatPrefab, new Vector3(Random.Range(-2, 2), GameManager.GM.ymax + 1f),
                            Quaternion.identity);
                    }
                }

                //Again, this doesn't actually do anything lol can be deleted
                speed += increment;
                yield return wait;
            }
        }
        else
        {
            while (AmountOfTreats > 0)
            {
                //If we want randomized treats instead of a premade treat set, spawn random treats.
                if (RandomizeTreats)
                {
                    //The amount of treats to be spawned in this particular row
                    int TreatThisRow = Random.Range(1, 3);
                    //Spawn each treat
                    for (int i = 0; i < TreatThisRow; i++)
                    {
                        Instantiate(TreatPrefab, new Vector3(Random.Range(-2, 2), GameManager.GM.ymax + 1f),
                            Quaternion.identity);
                    }
                }

                //Again, this doesn't actually do anything lol can be deleted
                speed += increment;
                yield return wait;
            }
        }

        //After all the treats have been spawned, TreatGenerator can destroy itself.
        canDie = true;
    }
}
