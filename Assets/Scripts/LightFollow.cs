using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    private bool follow = true;
    public GameObject player;
    void FixedUpdate()
    {
        if (follow)
        {
            transform.position = player.transform.position;
        }
    }

    public void StopFollowing()
    {
        follow = false;
    }
}
