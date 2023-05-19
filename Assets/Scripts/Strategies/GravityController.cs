using System;
using UnityEngine;

public class GravityController : MonoBehaviour, IMovable
{
    public float MovementSpeed => _gravityForce;
    [SerializeField] private float _gravityForce = 9.0f;

    public bool disableGravity = false;

    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
    }

    public void Move(Vector3 direction)
    { 
        if (!_character.isGrounded && !disableGravity)
        {
            transform.Translate(direction * _gravityForce * Time.deltaTime);
        }
        
    }

}
