using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{
    public int MaxLife => _maxLife;
    [SerializeField] private int _maxLife = 100;
    
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife = 0;

    
    public void TakeDamage(int damage)
    {
        if ((_currentLife - damage) < 0)
            _currentLife = 0;
        else
            _currentLife -= damage;
        
        if (this.CompareTag("Player"))
        {
            EventManager.instance.ActionCharacterLifeChange(_currentLife,_maxLife);
        }
        
        
        if (!isAlive())
            Die();
    }

    public void RecoverLife(int recoverAmount)
    {
        if ((_currentLife + recoverAmount) > _maxLife)
            _currentLife = _maxLife;
        else
            _currentLife += recoverAmount;
        
        if (this.CompareTag("Player"))
        {
            EventManager.instance.ActionCharacterLifeChange(_currentLife,_maxLife);
        }
    }

    public bool isAlive() => _currentLife > 0;

    public void Die()
    {
        if (this.CompareTag("Player"))
        {
            EventManager.instance.ActionGameOver(false);
            //do someting
        }
        else
        {
            Destroy(this.gameObject); 
        }
        
    } 
    
    
    
    
    
}
