using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBodyMovement : MonoBehaviour
{
    public GameObject Player; //игрок
    public Vector3 offset; //отступ от объекта
    public float sensitivity = 15; // чувствительность мышки
    public float limit = 80; // ограничение вращения по Y

    private Transform tr;
    private float X, Y;

    void Start()
    {
        tr = Player.GetComponent<Transform>();
        transform.position = Player.transform.position + offset;
    }

    void FixedUpdate()
    {
        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        Y += Input.GetAxis("Mouse Y") * sensitivity;
        Y = Mathf.Clamp(Y, -limit, limit);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * offset + tr.position;
    }
}
