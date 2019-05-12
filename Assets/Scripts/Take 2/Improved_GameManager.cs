using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Doron
public class Improved_GameManager : MonoBehaviour
{
    public static Improved_GameManager GM;

    public float Difficulty;

    // 0 = nothing
    // 1 = treat
    // 2 = frog
    // 3 = leech
    // 4 = mr. tenticles
    public GameObject treat;
    public GameObject frog;
    public GameObject leech;
    public GameObject tenticles;
    public List<Queue<Monster>> pools;
    public List<TextAsset> levels_0_difficulty;
    public List<TextAsset> levels_1_difficulty;
    public List<TextAsset> levels_2_difficulty;
    public List<TextAsset> levels_3_difficulty;
    public List<TextAsset> levels_4_difficulty;
    private List<TextAsset>[] allLevels;
    private List<Monster> floatinDownTheRiver;
    private List<Monster> toFloatDownTheRiver;
    private List<Monster> toCheckForPooling;
    public int currentLevel = 0;

    //Player stats
    public int Score;
    public int Health;

    public float speed = 1f;
    
    
    // Start is called before the first frame update
    void Start() {
        if (GM == null)
        {
            GM = this;
        }
        else if(GM != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);


        instatiatePoolObjects();

        fillAllLevels();

    }

    private void instatiatePoolObjects() {
        // instantiate objects in pools
        //pools.Add(null);
        for (int i = 0; i < 5; i++) {
            pools.Add(new Queue<Monster>());
        }
        for (int m = 0; m < 25; m++) {
            GameObject gameObj = Instantiate(treat);
            pools[1].Enqueue(gameObj.GetComponent<Monster>());
        }
        for (int m = 0; m < 25; m++) {
            GameObject gameObj = Instantiate(frog);
            pools[2].Enqueue(gameObj.GetComponent<Monster>());
        }
        for (int m = 0; m < 25; m++) {
            GameObject gameObj = Instantiate(leech);
            pools[3].Enqueue(gameObj.GetComponent<Monster>());
        }
        for (int m = 0; m < 25; m++) {
            GameObject gameObj = Instantiate(tenticles);
            pools[4].Enqueue(gameObj.GetComponent<Monster>());
        }
    }

    private void fillAllLevels() {
        allLevels = new List<TextAsset>[5];
        allLevels[0] = levels_0_difficulty;
        allLevels[1] = levels_1_difficulty;
        allLevels[2] = levels_2_difficulty;
        allLevels[3] = levels_3_difficulty;
        allLevels[4] = levels_4_difficulty;
    }

    // Update is called once per frame
    void Update() {
        if ( floatedDownTheRiver()) {
            toCheckForPooling = floatinDownTheRiver;
            floatinDownTheRiver = toFloatDownTheRiver;
            releaseTheHounds();
            toFloatDownTheRiver = setUpTheHounds();
        }
        
    }

    private List<Monster> setUpTheHounds() {
        List<Monster> returnValue = new List<Monster>();
        string initialGridString = allLevels[currentLevel][Random.Range(0, allLevels[currentLevel].Count)].text;
        string[] rows = initialGridString.Trim().Split('\n');
        int width = rows[0].Trim().Split(',').Length;
        int height = rows.Length;
        int start_row = -1;
        int[,] indexGrid = new int[width, height];
        for (int r = 0; r < height; r++) {
            string row = rows[height - r - 1];
            string[] cols = row.Trim().Split(',');
            for (int c = 0; c < width; c++) {
                indexGrid[c, r] = int.Parse(cols[c]);
            }
        }
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                int monsterType = indexGrid[j, height + start_row];
                if (monsterType != 0) {
                    Monster newMonsty = pools[monsterType].Dequeue();
                    returnValue.Add(newMonsty);
                    newMonsty.setPosition(j, start_row);
                    //might need to signify that not in pool?
                }
            }
            start_row--;
        }

        return returnValue;
        //Instantiate(null);
    }

    private void releaseTheHounds() {
        for (int i = 0; i < floatinDownTheRiver.Count; i++) {
            floatinDownTheRiver[i].Activate();
        }
    }

    private bool floatedDownTheRiver() {
        for ( int i = 0; i < floatinDownTheRiver.Count; i++) {
            if (floatinDownTheRiver[i].row() < 5) {
                return false;
            }
        }
        return true;
    }
}
