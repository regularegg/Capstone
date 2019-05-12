using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    public GameObject wat_blob;
    public float camera_left_bound = -5.5f;
    public float camera_right_bound = 5.5f;
    public float camera_upper_bound = 5.19f;
    public float camera_lower_bound = -16.3f;
    public int layer_order = -2;

    // Start is called before the first frame update
    void Start() {
        float x_off = camera_left_bound - .2f;
        while (x_off < camera_right_bound + .2f) {
            GameObject water = Instantiate(wat_blob);
            WaterBlob blob = water.GetComponent<WaterBlob>();
            blob.setLayer(layer_order);
            blob.setLocation(x_off - .3f, camera_upper_bound - Random.value * 3f);
            blob.setUpper(camera_upper_bound);
            blob.setLower(camera_lower_bound);

            water = Instantiate(wat_blob);
            blob = water.GetComponent<WaterBlob>();
            blob.setLayer(layer_order);
            blob.setLocation(x_off + .3f, camera_upper_bound - blob.spr.sprite.bounds.size.y - 1f - Random.value * 3f);
            blob.setUpper(camera_upper_bound);
            blob.setLower(camera_lower_bound);

            x_off += blob.spr.sprite.bounds.size.x;
        }
    }
}
