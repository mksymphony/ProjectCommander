using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSetting : MonoBehaviour
{
    [SerializeField] private GunManager _guns;

    [SerializeField] private int _damage;
    [SerializeField] private int _ammo;
    [SerializeField] private int _range;

    [SerializeField] private Transform _playerCam;
    [SerializeField] private GunManager.Gun gunName;
    private AudioSource _gunSound;

    public int ammo => _ammo;
    private void Start()
    {
        _gunSound = GetComponent<AudioSource>();
        _guns.SendGunsData("DsertEagle", ref gunName);
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
        RaycastHit hit;
        _gunSound.Play();
        if (Physics.Raycast(gameObject.transform.position, transform.forward, out hit, _range))
        {
            if (hit.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= _damage;
                Debug.DrawLine(transform.position, hit.point, Color.red, _range);
            }
        }
    }
}
