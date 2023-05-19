using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Heal : Consumable
{
    [SerializeField] private int amount = 25;


    public override void Consume(GameObject player)
    {
        player.GetComponent<LifeController>().RecoverLife(amount);
        Destroy(this.gameObject);
    }
}
