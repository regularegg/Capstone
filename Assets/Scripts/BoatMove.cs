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
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected");
        if (other.transform.CompareTag("Hazard"))
        {
            SR.color = Color.red;
            healthDispaly.text = "Health: "+ --health;
            Debug.Log("Ouch");
            if (health < 1)
            {
                SceneManager.LoadScene("Calibration");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SR.color = Color.white;
    }
}
