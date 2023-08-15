using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCamerraMove : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;

    private void Update()
    {
        transform.position = _cameraPosition.transform.position;
    }
}
