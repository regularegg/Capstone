using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHeart : MonoBehaviour
{
    public Image[] hearts;

    public Sprite fullHeart, halfHeart, emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        BoatMove.BM.fullHeart = fullHeart;
        BoatMove.BM.halfHeart = halfHeart;
        BoatMove.BM.emptyHeart = emptyHeart;

        BoatMove.BM.Hearts = hearts;
        
        Improved_GameManager.GM.StartGame();
        Improved_GameManager.GM.AS.Play();
    }
}
