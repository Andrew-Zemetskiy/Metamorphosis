using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public Vector3 ObjectRotation;
    void FixedUpdate()
    {
        transform.Rotate(ObjectRotation * Time.deltaTime);
    }
}
