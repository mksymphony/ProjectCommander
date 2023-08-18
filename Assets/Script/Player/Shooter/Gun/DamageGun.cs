using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _bulletRange;
    [SerializeField] private Transform _playerCam;

    public void Shoot()
    {
        Ray gunray = new Ray(_playerCam.position, _playerCam.forward);
        if (Physics.Raycast(gunray, out RaycastHit hitInfo, _bulletRange))
        {
            Debug.DrawRay(_playerCam.transform.position, _playerCam.forward);
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= _damage;
                Debug.Log("Shoot");
            }
        }
    }
}
