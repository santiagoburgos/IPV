using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }
    
    public virtual void Reload()
    {
        throw new System.NotImplementedException();
    }
}
