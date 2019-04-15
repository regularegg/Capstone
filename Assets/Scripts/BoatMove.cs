using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoatMove : MonoBehaviour
{
    private SpriteRenderer SR;

    public Text healthDispaly;

    public int health = 100;

    public int score;
    
    public LineRenderer lrLeft, lrRight;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        
        lrLeft.SetPosition(0,lrLeft.transform.position);
        lrLeft.SetPosition(1,new Vector3(-3,5,0));
        
        lrRight.SetPosition(0,lrRight.transform.position);
        lrRight.SetPosition(1,new Vector3(3,5,0));
    }

    void Update()
    {
        lrLeft.SetPosition(0,lrLeft.transform.position);
        lrRight.SetPosition(0,lrRight.transform.position);
    
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Collision detected");
        if (other.transform.CompareTag("Hazard"))
        {
            SR.color = Color.red;
            healthDispaly.text = "Health: "+ --health;
            Debug.Log("Ouch");
            if (health < 1)
            {
                //if u die, do death sequence, and go to death scene

                SceneManager.LoadScene("Calibration");
            }
        }
        else if (other.transform.CompareTag("Treat"))
        {
            score++;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SR.color = Color.white;
    }
}
