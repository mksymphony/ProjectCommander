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
        Damaged,
        Dead
    }
    private EnemyState _state;

    [Header("플레이어를 감지하고 공격할 거리")]
    [SerializeField] private float _enemyAttackRange;

    [Header("이 NPC의 최대 체력")]
    [SerializeField] private float _startingHealth;

    [Header("이 NPC의 속도")]
    [SerializeField] private float _speed;

    [Header("이 Npc가 상대를 확인할 위치")]
    [SerializeField] private Transform _rayShootPosition;

    [Header("적이 공격할때 플레이어를 인식하기위한 콜라이더")]
    [SerializeField] private GameObject _attackChecker;

    [SerializeField] private GameObject _deadBlood;
    [SerializeField] private Animator _Ani;
    private Collider _col;

    [SerializeField] private float _health;
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
                _state = EnemyState.Dead;
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
        _col = GetComponent<Collider>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _nav.speed = _speed;
        _state = EnemyState.idel;
        Health = _startingHealth;
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        UpdateState(_state);
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
            case EnemyState.Damaged:
                StartCoroutine(Damaged());
                break;
            case EnemyState.Dead:
                Dead();
                break;
            default:
                break;
        }
    }
    private IEnumerator Spawn()
    {
        _Ani.SetBool("IsSpawn", true);
        yield return new WaitForSeconds(2);
        _Ani.SetBool("IsSpawn", false);
        _state = EnemyState.Move;
    }

    private void MoveToTarget()
    {
        _nav.speed = _speed;
        _nav.SetDestination(_target.position);
        _Ani.SetBool("Move", _nav.velocity.magnitude > 0.1f);
        StartCoroutine(RayCheck());
    }

    private IEnumerator RayCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(_rayShootPosition.transform.position, transform.forward, out hit, _enemyAttackRange))
        {
            if (hit.collider.CompareTag("Player") && _state == EnemyState.Move)
            {
                Debug.Log("Player Check");
                _state = EnemyState.Attack;
            }
        }
        yield return new WaitForSeconds(1f);
    }


    private IEnumerator Damaged()
    {
        _Ani.SetBool("Move", false);
        _Ani.SetBool("Attack", false);
        _Ani.SetBool("Damaged", true);
        yield return new WaitForSeconds(1.5f);
        _Ani.SetBool("Damaged", false);
        _state = EnemyState.Move;
    }

    private void Dead()
    {
        _Ani.SetBool("IsDead", true);
        StartCoroutine(DeadObject());
        Instantiate(_deadBlood);
        _nav.speed = 0f;
        _col.enabled = false;
    }

    private IEnumerator AttackTarget()
    {
        _Ani.SetBool("Move", false);
        _Ani.SetBool("IsAttack", true);
        _nav.speed = 0f;
        yield return new WaitForSeconds(2f);
        _attackChecker.SetActive(true);
        yield return new WaitForSeconds(1f);
        _attackChecker.SetActive(false);
        _Ani.SetBool("IsAttack", false);
        yield return new WaitForSeconds(1f);
        _state = EnemyState.Move;
    }

    public void OnDamage()
    {
        _state = EnemyState.Damaged;
    }
}
