using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatBehavior : MonoBehaviour
{
    public TreatGenerator TG;
    public TutorialLevel TL;
    public float speed;
    public bool autonomous = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (autonomous)
        {
            TG = FindObjectOfType<TreatGenerator>();
            speed = GameManager.GM.RiverSpeed;
        }
        else
        {
            TL = FindObjectOfType<TutorialLevel>();
            speed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed;
        if (transform.position.y < GameManager.GM.ymin)
        {
            TG.AmountOfTreats--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //if they are moving by themselves and not during the tutorial level, 
            if (autonomous)
            {
                Debug.Log("Cool treat eaten");
                TG.AmountOfTreats--;
            }
            //If they are being moved for the tutorial level, reduce the current event count
            else
            {
                Debug.Log("cooler");
                TL.currentEvent++;
            }

            //Increase player score 
            GameManager.GM.PlayerScore++;
            Destroy(gameObject);
        }
    }
}
