using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFade : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    private float alpha = 1;
    private void Start()
    {

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
        GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, alpha);

        if (alpha <= 0)
            GetComponent<BoxCollider2D>().enabled = false;
        else
            GetComponent<BoxCollider2D>().enabled = true;
    }
}
