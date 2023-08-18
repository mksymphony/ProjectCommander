using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;

    [SerializeField] private float _distance = 3f;
    [SerializeField] private LayerMask _mask;
    private void Awake()
    {
        _cam = GetComponent<ShooterLook>().cam;
    }
}
