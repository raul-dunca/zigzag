using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }

}
