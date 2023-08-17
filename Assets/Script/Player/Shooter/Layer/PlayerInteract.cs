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
    private void Update()
    {
        RayCastProcessing();
    }

    private void RayCastProcessing()
    {
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _distance);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _distance, _mask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(hit.collider.GetComponent<Interactable>().promptMessage);
            }
        }

    }
}
