using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISticky : ITriggerable
{
    void ResetJumps(Character character);
}
