using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadePlatform : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    private float alpha = 1;
    private void Start()
    {
        Debug.Log(transform.Find("Tempo Platforms").GetComponent<Tilemap>().color);
    }
    void Update()
    {
        // Close Eyes
        if (Input.GetMouseButton(0))
        {
            if (alpha > 0)
                alpha -= fadeSpeed * Time.fixedDeltaTime;
        }
        else
        {
            if (alpha < 1)
                alpha += fadeSpeed * Time.fixedDeltaTime;
        }
        
        transform.Find("Tempo Platforms").GetComponent<Tilemap>().color = new Color(255f, 255f, 255f, alpha);

        if (alpha <= 0)
            transform.Find("Collision").GetComponent<TilemapCollider2D>().enabled = false;
        else
            transform.Find("Collision").GetComponent<TilemapCollider2D>().enabled = true;
    }
}
