using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothing;
    public Vector3 minVal, maxVal;
    public bool hasBound;
    private bool follow = true;
    private void FixedUpdate()
    {
        if (target != null)
        {
            if (follow)
            {
                if (hasBound)
                {
                    Vector3 targetpos = target.position + offset;
                    Vector3 boundpos = new Vector3(
                        Mathf.Clamp(targetpos.x, minVal.x, maxVal.x),
                        Mathf.Clamp(targetpos.y, minVal.y, maxVal.y),
                        Mathf.Clamp(targetpos.z, minVal.z, maxVal.z)
                        );
                    Vector3 newPosition = Vector3.Lerp(transform.position, boundpos, smoothing * Time.fixedDeltaTime);
                    transform.position = newPosition;
                }
                else
                {
                    Vector3 targetpos = target.position + offset;
                    Vector3 newPosition = Vector3.Lerp(transform.position, targetpos, smoothing * Time.fixedDeltaTime);
                    transform.position = newPosition;
                }
            }
        }
    }

    public void StopFollowing()
    {
        follow = false;
    }
}
