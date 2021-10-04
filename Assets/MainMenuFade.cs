using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFade : MonoBehaviour
{
    private bool isFading = false;
    private float alpha = 0;
    public float fadeSpeed = 0.5f;
    public void Fade()
    {
        isFading = true;
    }

    private void FixedUpdate()
    {
        if (isFading)
        {
            isFading = true;
            if (alpha < 1)
                alpha += fadeSpeed * Time.fixedDeltaTime;
            GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, alpha);
        }
    }
}
