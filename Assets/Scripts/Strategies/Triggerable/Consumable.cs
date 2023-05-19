using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour, IConsumable
{
    public Collider triggerCollider => _triggerCollider;
    private Collider _triggerCollider;
    
    public virtual void Consume(GameObject player)
    {
        throw new System.NotImplementedException();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Consume(other.gameObject);
        }
    }
}
