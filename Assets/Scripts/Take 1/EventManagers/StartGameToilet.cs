using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameToilet : MonoBehaviour
{
    public float countdown = 0;

    public string sceneToChange;

    public Image LoadingBar;

    public AudioSource AS;
    public AudioClip flush, splash;

    public float speed = 0.5f;
    

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 100 && countdown <= 101.5f) 
        {
            StartCoroutine(changeScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AS.Stop();
            AS.clip = splash;
            AS.Play();
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countdown+= speed;
            LoadingBar.fillAmount = countdown / 100;
            StopCoroutine(emptyBar());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countdown = 0;
            LoadingBar.fillAmount = countdown / 100;
            StartCoroutine(emptyBar());
        }
    }

    IEnumerator emptyBar()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        while (countdown < 0)
        {
            countdown--;
            LoadingBar.fillAmount = countdown / 100;
            yield return wait;
        }
    }

    IEnumerator changeScene()
    {
        AS.clip = flush;
        AS.Play();
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        while (AS.isPlaying)
        {
            yield return wait;
        }
        
        SceneManager.LoadScene(sceneToChange);
    }
}
