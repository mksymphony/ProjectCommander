using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Entity : MonoBehaviour
{
    [SerializeField] private float _startingHealth;
    [SerializeField] private GameObject _deadBlood;
    [SerializeField] private Animator _Ani;
    [SerializeField] private Collider _col;
    private bool _Death = false;
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
                _Ani.SetBool("IsDead", true);
                _Ani.SetBool("Move", false);
                Destroy(gameObject, 10f);
                Instantiate(_deadBlood, transform);
                _nav.speed = 0f;
                _Death = true;
                _col.enabled = false;
            }
        }
    }
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _nav;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        Health = _startingHealth;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _Ani.SetBool("IsSpawn", true);
        yield return new WaitForSeconds(2);
        _Ani.SetBool("IsSpawn", false);
    }
    private void Update()
    {
        if (_Death == false)
            Destination();
    }

    private void Destination()
    {
        _nav.SetDestination(_target.position);
        _Ani.SetBool("Move", _nav.velocity.magnitude > 0.1f);
    }
}
