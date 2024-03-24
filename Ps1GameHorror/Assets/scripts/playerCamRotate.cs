using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamRotate : MonoBehaviour
{
    public float sensivity = 2f;
    public float mxYAngle = 90f;
    float rotationX = 0f;
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.parent.Rotate(eulers: Vector3.up * mouseX * sensivity);
        rotationX -= mouseY * sensivity;
        rotationX = Mathf.Clamp(value: rotationX, min: -mxYAngle, mxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, y: 0f, z: 0f);
    }
}
