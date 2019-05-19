using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{

    public TextMeshPro TM_Death, TM_Score;
    
    public AudioClip LoopClip;

    public GameObject cv;

    private int _counter;
    public int Counter
    {
        get { return _counter; }
        set
        {
            switch (value)
            {
                    case 1:
                        BoatMove.BM.AS.clip = BoatMove.BM.backgroundLoop;
                        BoatMove.BM.AS.volume = 0.2f;
                        BoatMove.BM.AS.Play();
                        BoatMove.BM.AS.loop = true;
                        StartCoroutine(Timer(2));
                        break;
                    case 2:
                        DisplayLargeText("Your Score: ");
                        DisplaySmallText(BoatMove.BM.score);
                        StartCoroutine(Timer(5));
                        break;
                    case 3:
                        ChangeScene();
                        break;
            }
            _counter = value;
        }
    }

    void DisplayDeath()
    {
        TM_Death.enabled = true;
        TM_Score.enabled = true;
        
        TM_Score.sortingOrder = 10;
        TM_Death.sortingOrder = 10;
        Counter = 0;
        StartCoroutine(MoveTextDown());
        
        
        cv = GameObject.Find("Subscreen");
        cv.SetActive(false);
    }

    IEnumerator MoveTextDown()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        Vector3 startPos = new Vector3(0,10,0);
        Vector3 endPos = new Vector3(0,0,0);
        float count = 0;
        while (count < 1)
        {
            TM_Death.transform.position= Vector3.Lerp(startPos,endPos,count);
            count+= 0.004f;
            yield return wait;
        }

        Counter++;
    }
    IEnumerator Timer(float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);

        for (int i = 0; i < 1; i++)
        {
            yield return wait;
        }

        Counter++;
    }

    void DisplayLargeText(string text)
    {
        TM_Death.text = text;
    }
    
    void DisplaySmallText(int text)
    {
        TM_Score.text = "" + text;
    }
    
    void ChangeScene()
    {
        Improved_GameManager.GM.AS.loop = true;
        Improved_GameManager.GM.AS.clip = LoopClip;

        BoatMove.BM.score = 0;
        SceneManager.LoadScene("StartMenuScene");
    }
    
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    
}
