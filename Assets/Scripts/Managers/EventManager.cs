using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if(instance!=null)Destroy(this);
        instance = this;
    }
    
    public event Action<bool> OnGameOver;
    public void ActionGameOver(bool isVictory)
    {
        OnGameOver(isVictory);
    }


    public event Action<float, float> OnCharacterLifeChange;
    public void ActionCharacterLifeChange(float currentLife, float maxLife) => OnCharacterLifeChange(currentLife, maxLife);

    public event Action<Hand, bool> OnReloading;
    public void ActionReloading(Hand hand, bool isReloading) => OnReloading(hand, isReloading);
}
