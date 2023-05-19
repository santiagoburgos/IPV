using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Attack();

    void Reload();
    
    public void SetActive(MonoBehaviour obj, bool active) {
        obj.gameObject.SetActive(active);
    }

}
