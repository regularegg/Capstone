using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    public GameObject hazardPrefab1;

    public GameObject[] hazards;

    public int numHazards = 5;
    
    
    // Start is called before the first frame update
    void Start()
    {
        hazards = new GameObject[numHazards];
        for (int i = 0; i < numHazards; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-5,5), (i+2)*5);
            hazards[i] = Instantiate(hazardPrefab1, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject Darrel in hazards)
        {
            Darrel.transform.position += Vector3.down * 0.1f;
            if (Darrel.transform.position.y < -10)
            {
                Darrel.transform.position = new Vector3(Random.Range(-5,5), Random.Range(5,10));
            }
        }
    }
}
