using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun: IWeapon
{
    GameObject BulletPrefab { get; }

    List<Transform> BulletSpawners{ get; }
    int Damage{ get; }
    int MagSize{ get; }
    int CurrentBulletCount{ get; }
    float ShootCooldown { get; }
    
    float ReloadCooldown { get; }

    void Attack();
    void Reload();

}
