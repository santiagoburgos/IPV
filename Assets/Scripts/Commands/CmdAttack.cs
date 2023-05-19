using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdAttack : Icommand
{
    private IWeapon _weapon;

    public CmdAttack(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Execute() => _weapon.Attack();
}
