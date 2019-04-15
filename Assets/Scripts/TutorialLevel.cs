using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Special tutorial level manager. will manage the events happening
public class TutorialLevel : MonoBehaviour
{
    //Prefabs for treats, treat generator, and premade level set called "TutorialAvoidEnemy"
    public GameObject TreatPrefab, TreatGenPrefab, TutorialAvoidEnemy;

    //The text display
    public Text textOutput;

    
    private GameObject holder;

    //The state machine that manages when each event will happen
    private int _currentEvent;
    public int currentEvent
    {
        get { return _currentEvent; }
        set
        {
            switch (value)
            {
                
                case 0:
                    //Event 1: instantiate and move down a treat
                    //pause treat when it is at position y
                    GameObject treat1 = Instantiate(TreatPrefab, new Vector3(-2, GameManager.GM.ymax + 1),
                        Quaternion.identity);
                    treat1.GetComponent<TreatBehavior>().autonomous = false;
                    StartCoroutine(MoveTreatToPosition(treat1, 1f));
                    break;
                case 1:
                    //text display tells player to go to the thing
                    //wait for player to go and get the treat
                    textOutput.text = "Move the turtle to the coin to collect it!";
                    break;
                case 2:
                    //After player gets the coin, display the text prompt for 3 seconds
                    StartCoroutine(GeneralTextWait("Cool! Keep collecting those coins!", 3));
                    break;
                case 3:
                    //After the text has been displayed, instantiate the tutorial Treat Generator
                    GameObject TG = Instantiate(TreatGenPrefab);
                    TG.GetComponent<TreatGenerator>().TutorialLevel = true;
                    break;
                case 4:
                    //After the tutorial treat generator has destroyed self,
                    //instantiate the avoidEnemy tutorial level
                    //Then, move the entire holder to y = -2 and pause.
                    holder = Instantiate(TutorialAvoidEnemy, Vector3.zero, Quaternion.identity);
                    StartCoroutine(MoveTreatToPosition(holder, -2));
                    break;
                case 5:
                    //Give text prompt to watch out for frogs for 2 secnds
                    StartCoroutine(GeneralTextWait("Watch out for the poisonous frogs!", 2f));
                    break;
                case 6:
                    //Start moving the whole level prefab until everything is offscreen
                    StartCoroutine(MoveTreatToPosition(holder, -36f));
                    break;
            }

            Debug.Log("Current event: " + value);
            _currentEvent = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textOutput = GameObject.Find("ANNOUNCEMENT").GetComponent<Text>();
        currentEvent = 0;
    }


    //Move Treat to Y position and stop
    IEnumerator MoveTreatToPosition(GameObject Treat, float yPos)
    {
        Debug.Log("moviing: " + Treat.name);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        float progress = 0;
        while (Treat.transform.position.y > yPos)
        {
            //Debug.Log("moving holder with name " + Treat.name + " at " + Treat.transform.position.y);

            Treat.transform.position += Vector3.down * 0.05f;
            yield return wait;
        }

        currentEvent++;
    }

    //Display the announcement text for x seconds
    IEnumerator GeneralTextWait(string txt, float seconds)
    {
        WaitForSeconds wait = new WaitForSeconds(seconds);
        bool cont = false;

        textOutput.text = txt;
        while (!cont)
        {
            Debug.Log("showing text: " + txt);
            cont = true;
            yield return wait;
        }

        textOutput.text = "";
        Debug.Log("ok text done shown");
        currentEvent++;
    }
}
