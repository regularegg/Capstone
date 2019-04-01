using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenBetter : MonoBehaviour
{

    public float SpawnInterval;

    public float IncrementInterval;

    public float[] XPositions;

    public int[] MonsterIndex;

    public int[] monstersPerRow;

    public GameObject[] MonsterPrefabs;

    public int MonstersLeft;

    public bool DefaultValues;
    
    // Start is called before the first frame update
    void Start()
    {

        if (DefaultValues)
        {
            SpawnInterval = 1f;
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
        MonstersLeft = MonsterIndex.Length;

        StartCoroutine(IncrementalSpawner());
    }

    IEnumerator IncrementalSpawner()
    {
        float seconds = SpawnInterval;
        WaitForSeconds wait = new WaitForSeconds(seconds);

        int rowCount = 0;
        int monsterCount = 0;
        
        
        while (rowCount < monstersPerRow.Length)
        {
            //for each row
            for (int i = 0; i < monstersPerRow[rowCount]; i++)
            {
                //if there are monsters in this row
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
            
            Debug.Log("rc: " + rowCount);
            seconds -= IncrementInterval;
            yield return wait;
        }

        if (MonstersLeft == 0)
        {
            GameManager.GM.currentEvent++;
            Destroy(gameObject);
        }
    }
}
