using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class ProximityExplosion : MonoBehaviour, IExplosive
{
    public Collider triggerCollider => _triggerCollider;
    private Collider _triggerCollider;
    public float explosionDelay => _explosionDelay;
    [SerializeField] private float _explosionDelay;
    public int damage => _damage;
    [SerializeField] private int _damage;

    public LifeController lifeController => _lifeController;
    [SerializeField] private LifeController _lifeController;

    private List<IDamageable> damageGameObjects = new List<IDamageable>();

    private bool exploded = false;
    private bool explosionStarted = false;
    
    private void Start()
    {
        _triggerCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!explosionStarted)
            {
                Debug.Log("explosion started");
                Invoke("Explode",_explosionDelay);
            }
        }
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageGameObjects.Add(damageable);
        }
        
    }


    

    private void OnTriggerExit(Collider other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            if (damageGameObjects.Contains(damageable))
                damageGameObjects.Remove(damageable);
        }
    }

    public void Explode()
    {
        EventQueueManager.instance.AddEvent(new CmdApplyDamage(_lifeController, _lifeController.CurrentLife));
    }

    private void OnDestroy()
    {
        foreach (IDamageable damageable in damageGameObjects)
        {
            if (!damageable.Equals(null))
            {
                EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, damage));
            }
        }
    }
}
