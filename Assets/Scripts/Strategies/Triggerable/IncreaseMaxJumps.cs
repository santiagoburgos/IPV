using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class IncreaseMaxJumps : Consumable
{
    public override void Consume(GameObject player)
    {
        player.GetComponent<Character>().jumps +=1;
        Destroy(this.gameObject);
    }
}
