using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BoatMove : MonoBehaviour
{
    private SpriteRenderer SR;

    public Text healthDispaly;

    public TextMeshPro textDisplay;

    public int health = 100;
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

    private void OnCollisionStay2D(Collision2D other)
    {
        /*
        Debug.Log("Collision detected");
        if (other.transform.CompareTag("Hazard"))
        {
            SR.color = Color.red;
            healthDispaly.text = "Health: "+ --health;
            Debug.Log("Ouch");
            if (health == 0)
            {
                //if u die, do death sequence, and go to death scene

                SceneManager.LoadScene("Calibration");
            }
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Hazard"))
        {
            StartCoroutine(OnHitHazardWait());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SR.color = Color.white;
        BeingHit = false;
        StopCoroutine(OnHitHazardWait());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.transform.CompareTag("Treat"))
        {
            AS.clip = HappyClips[Random.Range(0, HappyClips.Length)];
            AS.Play();
            score++;
        }
    }

    IEnumerator OnHitHazardWait()
    {
        WaitForSeconds wait = new WaitForSeconds(1.5f);
        while (BeingHit)
        {
            health--;
            AS.clip = Ouch[Random.Range(0,Ouch.Length)];
            AS.Play();
            yield return wait;
        }
    }
}
