using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float smoothing;
    public Vector3 offset;

    private void FixedUpdate()
    {
        if (lookAt != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, lookAt.transform.position + offset, smoothing);
            transform.position = newPosition;
        }
    }
}
