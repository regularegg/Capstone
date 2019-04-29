using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefab : MonoBehaviour
{
    public float deathYPosition;
    

    //if this is an autonomous level, delete itself after the last item has been shown on screen
    void Update()
    {
        transform.position += Vector3.down * GameManager.GM.RiverSpeed;
        if (transform.position.y <= deathYPosition)
        {
            //Let its manager know too later
            GameManager.GM.currentEvent++;
            Destroy(gameObject);
        }
    }
}
