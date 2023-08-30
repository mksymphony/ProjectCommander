using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    [SerializeField] private GunManager _guns;

    [SerializeField] private int _damage;
    [SerializeField] private int _ammo;
    [SerializeField] private int _range;

    [SerializeField] private Transform _playerCam;

    [SerializeField] private GunManager.Gun gunName;

    private void Start()
    {
        _guns.SendGunsData("M1911", ref gunName);
        SetValue();
    }
    private void SetValue()
    {
        _damage = gunName.power;
        _ammo = gunName.ammo;
        _range = gunName.range;
    }

    public void Shoot()
    {
        Ray gunray = new Ray(_playerCam.position, _playerCam.forward);
        if (Physics.Raycast(gunray, out RaycastHit hitInfo, _range))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= _damage;
                Debug.Log("Shoot");
            }
        }
    }
}
