using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDamage : MonoBehaviour, IContinuousDamage
{
    public Collider triggerCollider => _triggerCollider;
    private Collider _triggerCollider;

    public float timeBetweenDamage => _timeBetweenDamage;
    [SerializeField] private float _timeBetweenDamage;
    
    public int damage => _damage;
    [SerializeField] private int _damage;

    private List<IDamageable> damageGameObjects = new List<IDamageable>();
    private float timer=0f;
    
    private void Start()
    {
        _triggerCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timer = timeBetweenDamage;
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
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenDamage)
        {
            timer = 0;
            foreach (IDamageable damageable in damageGameObjects)
            {
                if (!damageable.Equals(null))
                {
                    EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, damage));
                }
            }
        }
    }
    
    
    
}
