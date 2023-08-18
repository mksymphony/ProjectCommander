using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log(_health);
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        Health = _startingHealth;
    }
}
