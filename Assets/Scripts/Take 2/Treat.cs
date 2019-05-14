using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mary
public class Treat : Monster
{
    public Vector3 StartPos;
    public float speed;
    public SpriteRenderer SR;
    public Sprite[] Sprites;
    public AudioSource AS;
    public AudioClip[] clips;
    
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Improved_GameManager.GM.speed;
        SR = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
        SR.sprite = Sprites[Random.Range(0, 2)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            Move();
        }

        if (transform.position.y < OffScreen)
        {
            ResetTreat();
        }
    }
    
    void Move()
    {
        transform.position += Vector3.down * speed;
    }

    void ResetTreat()
    {
        Deactivate();
        SR.sprite = Sprites[Random.Range(0, 2)];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            AS.clip = clips[Random.Range(0, clips.Length)];
            AS.Play();
            ResetTreat();
        }
    }
}
