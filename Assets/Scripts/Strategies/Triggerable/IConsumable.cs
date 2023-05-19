using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumable : ITriggerable
{
    void Consume(GameObject player);
}
