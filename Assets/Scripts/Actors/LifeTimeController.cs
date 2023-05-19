using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeController : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5;
    private float _currentLifeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentLifeTime = _lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        _currentLifeTime -= Time.deltaTime;
    }

    public bool IsLifeTimeOver() => _currentLifeTime <= 0;

    public void SetLifeTime(float value)
    {
        _lifeTime = value;
        _currentLifeTime = _lifeTime;
    }
}
