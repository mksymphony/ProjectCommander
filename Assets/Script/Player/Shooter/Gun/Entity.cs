using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Entity : MonoBehaviour
{
    private enum EnemyState
    {
        idel,
        Move,
        Attack,
        Dead
    }
    private EnemyState _state;

    [SerializeField] private float _enemyAttackRange;
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

            }
        }
    }

    private IEnumerator DeadObject()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _nav;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _state = EnemyState.idel;
        Health = _startingHealth;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _Ani.SetBool("IsSpawn", true);
        yield return new WaitForSeconds(2);
        _Ani.SetBool("IsSpawn", false);
        _state = EnemyState.Move;
    }
    private void Update()
    {
        UpdateState(_state);
    }
    private void MoveToTarget()
    {
        _nav.SetDestination(_target.position);
        _Ani.SetBool("Move", _nav.velocity.magnitude > 0.1f);
        RayCheck();
    }

    private void RayCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, transform.forward, out hit, _enemyAttackRange))
        {
            if (hit.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, _enemyAttackRange);
            }
        }
    }

    private void UpdateState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.idel:
                StartCoroutine(Spawn());
                break;
            case EnemyState.Move:
                MoveToTarget();
                break;
            case EnemyState.Attack:
                StartCoroutine(AttackTarget());
                break;
            case EnemyState.Dead:
                Dead();
                break;
            default:
                break;
        }
    }

    private void Dead()
    {
        _Ani.SetBool("IsDead", true);
        _Ani.SetBool("Move", false);
        StartCoroutine(DeadObject());
        Instantiate(_deadBlood);
        _nav.speed = 0f;
        _Death = true;
        _col.enabled = false;
    }

    private IEnumerator AttackTarget()
    {
        yield return new WaitForSeconds(2f);
    }

    private void ChangeState(EnemyState state)
    {
        _state = state;
    }
}
