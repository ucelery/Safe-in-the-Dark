using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = player.transform.position;
    }
}
