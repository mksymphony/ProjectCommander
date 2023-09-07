using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterLook : MonoBehaviour
{
    [SerializeField] private Camera _shooterCam;
    private float _xRotation = 0f;

    [SerializeField] private float _xSensitivity = 30f;
    [SerializeField] private float _ySensitivity = 30f;


    public Camera cam => _shooterCam;
    public float xSensitivity => _xSensitivity;
    public float ySensitivity => _ySensitivity;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        _shooterCam.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
    }
}