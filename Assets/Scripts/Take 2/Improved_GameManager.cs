﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Improved_GameManager : MonoBehaviour
{
    public static Improved_GameManager GM;

    public float Difficulty;
    
    //Player stats
    public int Score;
    public int Health;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (GM == null)
        {
            GM = this;
        }
        else if(GM != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
