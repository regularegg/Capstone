using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> ActiveEnemies;

    public GameObject[] hazardGenerators;

    public int time;
    public int level;

    public int enemiesPassed = 0;

    public int maxEnemiesOnScreen;

    public GameObject eA, eB, eC, eD;
    
    
    public float RiverSpeed;
    public float difficulty = 0; 
        
    //player stuff
    public int PlayerScore = 0;
    public float timeSinceStart = 0;

    public float xmin, xmax, ymin, ymax;

    public static GameManager GM = null;

    public Text AnnouncementCenter;

    //Event manager lol
    private int _currentEvent;
    public int currentEvent
    {
        get { return _currentEvent; }
        set
        {
            switch (value)
            {
                    case 1: Instantiate(hazardGenerators[0]);
                        break;
                    
                    case 2: AnnouncementCenter.text = "Cool u win!";
                        break;
            }
            _currentEvent = value;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        //do the only 1 gamemanager at a time etc.
        if (GM == null)
        {
            GM = this;
        }
        else if(GM != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        StartCoroutine(ReadySetGo());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReadySetGo()
    {
        
        Debug.Log("IRSG start");
        WaitForSeconds wait = new WaitForSeconds(1.5f);

        int count = 0;

        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0: AnnouncementCenter.text = "Ready";
                    Debug.Log("Ready set go1");
                    break;
                case 1: AnnouncementCenter.text = "Set";
                    Debug.Log("Ready set go2");
                    break;
                case 2: AnnouncementCenter.text = "Go!!!!!!!!";
                    break;
            }

            yield return wait;
        }

        currentEvent++;
        AnnouncementCenter.text = "";
    }
}
