using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCBehavior : MonoBehaviour
{
    //frog enemies that just stay there and flow down w the river
    //future goal: have tongue that flicks out w/ spikes?

    
    // Start is called before the first frame update

    public bool autonomous;
    public HazardGenBetter HG;
    void Start()
    {
        //transform.position = new Vector3(Random.Range(GameManager.GM.xmin, GameManager.GM.xmax),GameManager.GM.ymax + 2f);
        HG = FindObjectOfType<HazardGenBetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (autonomous)
        {
            transform.position += Vector3.down * GameManager.GM.RiverSpeed;
        }
        

        if (transform.position.y < GameManager.GM.ymin)
        {
            Debug.Log("Frog off screen bye");
            //Remove decrease the monster count
            //HG.MonstersLeft--;
            Destroy(gameObject);
        }
    }
}
