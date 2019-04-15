using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The real hazardgenerator~~~
// Spawns enemies at specified X positions using MonstersPerRow.
// After it is done, it deletes itself and tells GameManager to continue spawning the next monster set

public class HazardGenBetter : MonoBehaviour
{
    public float SpawnInterval;

    public float IncrementInterval;

    //The X values for each vector 3 to be used for generation
    public float[] XPositions;

    //The type of Monster to be spawned at each point
    public int[] MonsterIndex;

    //The amount of monsters that are spawned at this row
    public int[] monstersPerRow;

    //Library of monsters for spawning
    public GameObject[] MonsterPrefabs;

    //Number of monsters left alive or unspawned
    public int MonstersLeft;

    //Use default values or custom input from inspector
    public bool DefaultValues;
    
    // Start is called before the first frame update
    void Start()
    {
       
        //Default values
        if (DefaultValues)
        {
            SpawnInterval = 2.3f;
            IncrementInterval = 0.001f;
            XPositions = new float[8];
            MonsterIndex = new int[8];
            monstersPerRow = new int[9];

            for (int i = 0; i < XPositions.Length-2; i++)
            {
                MonsterIndex[i] = 0;
            }

            MonsterIndex[6] = 1;
            MonsterIndex[7] = 3;
            
            XPositions[0] = -2f;
            XPositions[1] = 2f;
            XPositions[2] = 0;
            XPositions[3] = -2f;
            XPositions[4] = 0;
            XPositions[5] = 2f;
            XPositions[6] = -2f;
            XPositions[7] = 2f;

            monstersPerRow[0] = 1;
            monstersPerRow[1] = 1;
            monstersPerRow[2] = 0;
            monstersPerRow[3] = 1;
            monstersPerRow[4] = 0;
            monstersPerRow[5] = 2;
            monstersPerRow[6] = 0;
            monstersPerRow[7] = 1;
            monstersPerRow[8] = 2;
        }
        //Set MonstersLeft to the amount of monsters to be spawned and used
        MonstersLeft = MonsterIndex.Length;

        StartCoroutine(IncrementalSpawner());
    }

    private void Update()
    {
        //If there are no more monsters left alive, increase the event int in the Game Manager
        //and delete itself
        if (MonstersLeft == 0)
        {
            GameManager.GM.currentEvent++;
            Debug.Log("end of current level");
            Destroy(gameObject);
        }
    }

    //Monster Spawning coroutine
    IEnumerator IncrementalSpawner()
    {
        //Interval between each spawn
        float seconds = SpawnInterval;
        WaitForSeconds wait = new WaitForSeconds(seconds);

        //Setup for counting
        int rowCount = 0;
        int monsterCount = 0;
        
        //While there are still rows of monsters that haven't been spawned yet
        while (rowCount < monstersPerRow.Length)
        {
            //for each row
            for (int i = 0; i < monstersPerRow[rowCount]; i++)
            {
                //if there are monsters in this row, spawn a monster[index] at that positionX[index]
                if (monstersPerRow[rowCount] > 0)
                {
                    Instantiate(MonsterPrefabs[MonsterIndex[monsterCount]],
                        new Vector3(XPositions[monsterCount], 6f),
                        Quaternion.identity);

                    monsterCount++;
                }
            }
            //increment row
            rowCount++;
            //Decrease the amount of time between each spawn interval?
            //Doesn't actually work bc there's no new waitforseconds lol
            seconds -= IncrementInterval;
            
            //loop
            yield return wait;
        }
    }
}
