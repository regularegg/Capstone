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
    

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 100)
        {
            Debug.Log("Next scene");
            SceneManager.LoadScene(sceneToChange);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countdown+= 0.5f;
            LoadingBar.fillAmount = countdown / 100;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countdown = 0;
            LoadingBar.fillAmount = countdown / 100;

        }
    }
}
