using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreOutput;

    public String scoreText = "";

    public bool highscore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (highscore)
        {
            scoreOutput.text = scoreText+ BoatMove.BM.highestScore;

        }
        else
        {
            scoreOutput.text = scoreText+ BoatMove.BM.score;

        }
    }
}
