using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mary
public class Treat : MonoBehaviour
{
    public Vector3 StartPos;
    public float speed;
    public SpriteRenderer SR;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPos.x = Random.Range(-5, 5);
        GetComponent<Transform>().position = StartPos;
        speed = Improved_GameManager.GM.speed;
        SR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
