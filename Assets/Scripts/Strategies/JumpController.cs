using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour, IMovable
{
    public float MovementSpeed => _jumpForce;
    [SerializeField] private float _jumpForce = 8.0f;

    public float reductionRate = 0.1f;
    
    private bool _jump = false;
    private float _currentForce;
    private Vector3 _direction;
    

    private Character _character;
    private GravityController _gravityController;
    private void Start()
    {
        _character = GetComponent<Character>();
        _gravityController = GetComponent<GravityController>();
    }

    public void Move(Vector3 direction)
    {
        _currentForce = _jumpForce;
        _direction = direction;
        _jump = true;
    }

    private void Update()
    {
        if (_jump)
        {
            _currentForce -= reductionRate * Time.deltaTime;
            //if we are going down and already touch the floor, the jump ends
            if(_currentForce <= _gravityController.MovementSpeed && _character.isGrounded)
            {
                _currentForce = _jumpForce;
                _jump = false;
            }
            else if(_character.topHit)
            {
                _currentForce = _gravityController.MovementSpeed;
            }
            else if(_currentForce >= 0)
            {   
                transform.Translate(_direction * _currentForce * Time.deltaTime);
            }
            else
            {
                _currentForce = _jumpForce;
                _jump = false;
            }
        }
    }
    
    
    
}
