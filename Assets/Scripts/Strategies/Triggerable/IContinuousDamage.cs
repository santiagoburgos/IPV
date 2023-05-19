using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContinuousDamage : ITriggerable
{
    Collider triggerCollider { get; }
    float timeBetweenDamage { get; }
    int damage { get; }
    
}
