using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BoatMove : MonoBehaviour
{
    private SpriteRenderer SR;

    public AudioClip deathClip, backgroundLoop;

    public int highestScore;

    public TextMeshPro textDisplay;
    public GameObject Death;

    public Image[] Hearts;
    public Sprite fullHeart, halfHeart, emptyHeart;
    private int _health;
    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            switch (value)
            {
                case 5: Hearts[0].sprite = halfHeart;
                     break;
                case 4: Hearts[0].sprite = emptyHeart;
                    break;
                case 3: Hearts[1].sprite = halfHeart;
                    break;
                case 2: Hearts[1].sprite = emptyHeart;
                    break;
                case 1: Hearts[2].sprite = halfHeart;
                    break;
                case 0: Hearts[2].sprite = emptyHeart;
                    Die();
                    //play death animation
                    break;
            }
        }

    }

    public bool Alive = true;
    
    public int score;

    public bool BeingHit;

    public static BoatMove BM;
    public LineRenderer lrLeft, lrRight;

    public AudioSource AS;
    public AudioClip[] HappyClips;
    public AudioClip[] Ouch;
    //


    public bool UseMouse;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
        
        lrLeft.SetPosition(0,lrLeft.transform.position);
        lrLeft.SetPosition(1,new Vector3(-3,5,0));
        
        lrRight.SetPosition(0,lrRight.transform.position);
        lrRight.SetPosition(1,new Vector3(3,5,0));
        
        if (BM == null)
        {
            BM = this;
        }
        else if(BM != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);

        health = 6;
        
        SR.color = Color.black;
    }

    void Update()
    {
        if (UseMouse)
        {
            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = targetPos;
        }
        lrLeft.SetPosition(0,lrLeft.transform.position);
        lrRight.SetPosition(0,lrRight.transform.position);

        if (SceneManager.GetActiveScene().name == "StartMenuScene")
        {
            textDisplay.text = "Lower me into toilet to start";
        }
        else
        {
            textDisplay.text = "";
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        BeingHit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.transform.CompareTag("Treat") && Alive)
        {
            AS.clip = HappyClips[Random.Range(0, HappyClips.Length)];
            AS.Play();
            score++;
        }
        
        if (other.transform.CompareTag("Hazard") && Alive)
        {
            health--;
            AS.clip = Ouch[Random.Range(0,Ouch.Length)];
            AS.Play();
        }
    }

    void Die()
    {
        if (score > highestScore)
        {
            highestScore = score;
        }

        Alive = false;
        Improved_GameManager.GM.Permadeath();
        Improved_GameManager.GM.AS.Stop();
        Improved_GameManager.GM.AS.clip = deathClip;
        Improved_GameManager.GM.AS.Play();
        Improved_GameManager.GM.AS.loop = false;
        Instantiate(Death);
        
        health = 6;
    }
}
