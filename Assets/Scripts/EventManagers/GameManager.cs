using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> ActiveEnemies;

    //same generator that generates both
    public GameObject[] hazardGenerators;
    public GameObject[] TreatGenerators;
    public GameObject[] PrebuiltLevels;
    public GameObject Tutorial;

    public SpriteRenderer AnnouncementBG;
    public float RiverSpeed;
    public float difficulty = 0; 
        
    //player stuff
    public int PlayerScore = 0;
    public float timeSinceStart = 0;
    public bool alive = true;

    public float xmin, xmax, ymin, ymax;

    public static GameManager GM = null;

    public Text AnnouncementCenter, Points;

    //Event manager lol
    private int _currentEvent;
    public int currentEvent
    {
        get { return _currentEvent; }
        set
        {
            switch (value)
            {
                    case 1: Instantiate(Tutorial);
                        break;
                    case 2: Instantiate(PrebuiltLevels[0]);
                        break;
                    case 3:
                        StartCoroutine(IncreaseSpeed());
                        Instantiate(PrebuiltLevels[1]);
                        Instantiate(hazardGenerators[3]);
                        break;
                    case 4: AnnouncementCenter.text = "Cool u win!";
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
        //Points.text = ""+ PlayerScore;

        if (!alive)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Death();
        }
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

    IEnumerator IncreaseSpeed()
    {
        
        WaitForSeconds wait = new WaitForSeconds(10);
        while (true)
        {
            RiverSpeed += 0.05f;
            yield return wait;
        }
    }

    void Death()
    {
        Debug.Log("U died");
        if (PlayerScore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", PlayerScore);
        }

        SceneManager.LoadScene("GamePlay");

    }

    IEnumerator GeneralTextWait(string txt, float seconds)
    {
        WaitForSeconds wait = new WaitForSeconds(seconds);
        bool cont = false;

        AnnouncementBG.enabled = true;
        AnnouncementCenter.text = txt;
        while (!cont)
        {
            Debug.Log("showing text: " + txt);
            cont = true;
            yield return wait;
        }

        AnnouncementBG.enabled = false;
        AnnouncementCenter.text = "";
        Debug.Log("ok text done shown");
        currentEvent++;
    }
}
