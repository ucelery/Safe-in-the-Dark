using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float count = 5.0f;
    private bool starting = false;
    void FixedUpdate()
    {
        if (starting)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
            }
        }
    }

    public void StartCount()
    {
        starting = true;
    }
}
