using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplosive : ITriggerable
{
    Collider triggerCollider { get; }
    LifeController lifeController { get; }
    float explosionDelay { get; }
    int damage { get; }
    
    void Explode();
}
