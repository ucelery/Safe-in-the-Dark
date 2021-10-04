using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFuncs : MonoBehaviour
{
    private bool isStarting = false;
    public void onStartClick()
    {
        if (!isStarting)
        {
            isStarting = true;

        }
    }
}
