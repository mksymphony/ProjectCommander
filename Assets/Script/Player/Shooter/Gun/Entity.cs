using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Entity : MonoBehaviour
{
    [SerializeField] private float _startingHealth;
    private float _health;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _nav;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        Health = _startingHealth;
    }
    private void Update()
    {
        Destination();
    }

    private void Destination()
    {
        _nav.SetDestination(_target.position);
    }
}
