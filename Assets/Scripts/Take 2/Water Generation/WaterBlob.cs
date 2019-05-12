using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlob : MonoBehaviour {
    int fallDivisor = 10;
    public List<Texture2D> squigs;
    public SpriteRenderer spr;
    private int current_sequence = 0;
    public List<List<Sprite>> sprite_lists;

    private int sprt_wid = 200;
    private int sprt_height = 1060;
    private int speed_denom = 4;
    private float upper;
    private float lower;

    int ctr = 0;

    private void Awake() {
        sprite_lists = new List<List<Sprite>>();
        // pre-process all the squig sheets into lists of sprites
        foreach (Texture2D squig in squigs) {
            List<Sprite> sprite_list = new List<Sprite>();
            for (int y = 0; y < squig.height / sprt_height; y++) {
                for (int x = 0; x < squig.width / sprt_wid; x++) {
                    sprite_list.Add(Sprite.Create(squig, new Rect(x * sprt_wid, y * sprt_height, sprt_wid, sprt_height), Vector2.zero));
                }
            }
            sprite_lists.Add(sprite_list);
        }
        spr = GetComponent<SpriteRenderer>();
        newSquig();
        spr.sprite = sprite_lists[current_sequence][(int)ctr / speed_denom];
    }

    public void setLocation(float x, float y) {
        spr.transform.position = new Vector3(x, y);
    }

    public void setUpper(float y) {
        upper = y;
    }

    public void setColor() {

    }

    public void setLower(float y) {
        lower = y;
    }

    public void setLayer(int lay) {
        spr.sortingOrder = lay;
    }

    // Update is called once per frame
    void Update() {
        ctr++;
        ctr = ctr % (sprite_lists[current_sequence].Count * speed_denom);
        spr.sprite = sprite_lists[current_sequence][(int)ctr/speed_denom];
        spr.transform.position += Vector3.down / fallDivisor;
        if (spr.transform.position.y < lower) {
            setLocation(spr.transform.position.x, upper);
            newSquig();
        }
    }

    private void newSquig() {
        current_sequence = Random.Range(0, sprite_lists.Count);
        //spr.flipX = Random.value < .5;
        //spr.flipY = Random.value < .5;
    }
}
