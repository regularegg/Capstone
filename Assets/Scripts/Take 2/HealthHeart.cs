using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeart : MonoBehaviour
{
    public AudioSource AS;

    private bool lowHealth = false;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BoatMove.BM.health == 1 && !lowHealth)
        {
            Debug.Log("lo helht");
            lowHealth = true;
            AS.Play();
        }
    }
}
