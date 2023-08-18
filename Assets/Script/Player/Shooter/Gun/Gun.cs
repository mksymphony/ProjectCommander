using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGunShoot;
    [SerializeField] private float _fireCoolDown;

    [SerializeField] private bool _isAuto;

    [SerializeField] private float _currCoolDown;

    private void Awake()
    {
        _currCoolDown = _fireCoolDown;
    }
    private void Update()
    {
        if (_currCoolDown <= 0)
            _currCoolDown = 0;
        else
            _currCoolDown -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (_isAuto)
        {
            if (_currCoolDown <= 0f)
            {
                _onGunShoot?.Invoke();
                _currCoolDown = _fireCoolDown;
            }
        }
    }
}
