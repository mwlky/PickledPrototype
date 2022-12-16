using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public static event Action<int> OnPowerUpsAmountUpdate; 

    [SerializeField] private int _maxPowerUpsUses;

    private int _currentPowerUpUses;
    
    private void Start()
    {
        _maxPowerUpsUses = _currentPowerUpUses;
        OnPowerUpsAmountUpdate?.Invoke(_currentPowerUpUses);
    }

    void PowerUpUsed()
    {
        
    }
}
