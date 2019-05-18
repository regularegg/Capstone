using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{

    public TextMeshPro TM_Death, TM_Score;
    
    public AudioClip LoopClip;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    void DisplayDeath()
    {
        TM_Death.enabled = true;
        TM_Score.enabled = true;
        
        TM_Score.sortingOrder = 10;
        TM_Death.sortingOrder = 10;
        StartCoroutine(MoveTextDown());
    }

    IEnumerator MoveTextDown()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        Vector3 startPos = new Vector3(0,10,0);
        Vector3 endPos = new Vector3(0,0,0);
        float count = 0;
        while (count < 1)
        {
            Debug.Log("woo");
            TM_Death.transform.position= Vector3.Lerp(startPos,endPos,count);
            count+= 0.008f;
            yield return wait;
        }
        
    }
    IEnumerator Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(5);

        for (int i = 0; i < 1; i++)
        {
            yield return wait;
        }
        Improved_GameManager.GM.AS.loop = true;
        Improved_GameManager.GM.AS.clip = LoopClip;

        BoatMove.BM.score = 0;
        SceneManager.LoadScene("StartMenuScene");
    }
    
    
}
