using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour, ISticky
{
    public Collider triggerCollider => _triggerCollider;

    private Collider _triggerCollider;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ResetJumps(other.gameObject.GetComponent<Character>());
        }
    }
    
    public void ResetJumps(Character character)
    {
        character._currentJumps = 0;
    }
}
