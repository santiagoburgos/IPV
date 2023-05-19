using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : Weapon, IGun
{

    public GameObject BulletPrefab => _bulletPrefab;
    [SerializeField] private GameObject _bulletPrefab;
    
    public List<Transform> BulletSpawners => _bulletSpawners;
    [SerializeField] private List<Transform> _bulletSpawners;

    public int Damage  => _damage;
    [SerializeField] private int _damage = 10;
    
    public int MagSize => _magSize;
    [SerializeField] private int _magSize = 10;

    public int CurrentBulletCount => _currentBulletCount;
    [SerializeField] private int _currentBulletCount = 10;

    public float ShootCooldown => _shootCooldown;
    [SerializeField] private float _shootCooldown = 0.5f;
    private float _currentShootCooldown = 0;
    
    
    public float ReloadCooldown => _reloadCooldown;
    [SerializeField] private float _reloadCooldown = 1f;
    private bool reloading = false;


    protected void Update()
    {
        if (_currentShootCooldown >= 0)
        {
            _currentShootCooldown -= Time.deltaTime;
        }
    }

    public override void Attack()
    {
        
        if (_currentShootCooldown <= 0 && _currentBulletCount >0 && !reloading)
        {
            foreach (Transform bulletSpawner in  _bulletSpawners)
            {
                _currentBulletCount -= 1;
                Instantiate(_bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            }
            _currentShootCooldown = _shootCooldown;
        }
        
    }

    public override void Reload()
    {
        reloading = true;
        _currentBulletCount = _magSize;
        Invoke("ReloadCoolDownFinished", _reloadCooldown);
    }

    private void ReloadCoolDownFinished()
    {
        reloading = false;
    }
    
}
