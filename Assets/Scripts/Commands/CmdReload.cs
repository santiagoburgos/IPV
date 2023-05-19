using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReload : Icommand
{
    private IWeapon _weapon;

    public CmdReload(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Execute() => _weapon.Reload();
}
