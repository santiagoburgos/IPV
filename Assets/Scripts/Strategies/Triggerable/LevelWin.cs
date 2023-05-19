using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LevelWin : Consumable
{
    public override void Consume(GameObject player)
    {
        EventManager.instance.ActionGameOver(true);
    }
}
