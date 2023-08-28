using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SimpleMove : MonoBehaviour
{
    [SerializeField] private GameObject _playerPosition;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.transform.position, _speed);
    }

}
