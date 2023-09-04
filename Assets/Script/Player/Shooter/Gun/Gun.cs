using UnityEngine.Events;
using UnityEngine;
using System;
using System.Collections;

public class Gun : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGunShoot;
    [SerializeField] private Animator _ani;
    [SerializeField] private GunSetting _gunSetting;
    [SerializeField] private float _fireCoolDown;

    [SerializeField] private bool _isAuto;

    [SerializeField] private float _currCoolDown;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _shootParticle;
    private void Awake()
    {
        _currCoolDown = _fireCoolDown;
        _ani = GetComponent<Animator>();
        _gunSetting = GetComponent<GunSetting>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (_currCoolDown <= 0)
        {
            _currCoolDown = 0;
        }
        else
            _currCoolDown -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (_isAuto)
        {
            if (_currCoolDown <= 0f)
            {
                StartCoroutine(StartRecoil());
                _onGunShoot?.Invoke();
                _currCoolDown = _fireCoolDown;
                var particel = Instantiate(_shootParticle);
                particel.transform.position = _shootPoint.transform.position;
            }
        }
    }
    IEnumerator StartRecoil()
    {
        _ani.SetBool("Fire", true);
        yield return new WaitForSeconds(0.20f);
        _ani.SetBool("Fire", false);
    }

}
