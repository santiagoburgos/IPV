using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable
{
    
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 1.0f;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * MovementSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
