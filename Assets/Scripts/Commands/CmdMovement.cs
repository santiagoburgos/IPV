using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMovement : Icommand
{
    // Start is called before the first frame update
    private IMovable _movable;
    private Vector3 _direction;

    public CmdMovement(IMovable movable, Vector3 direction)
    {
        _movable = movable;
        _direction = direction;
    }
    public void Execute()
    {
        _movable.Move(_direction);
    }
}
