using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public static event Action<int> OnPowerUpsAmountUpdate;
    public static event Action OnOverdose;

    [SerializeField] private int _maxPowerUpsUses;

    private int _currentPowerUpUses;

    private void OnEnable()
    {
        PlayerNavMeshController.OnPillTaken += TakePowerUp;
    }

    private void OnDisable()
    {
        PlayerNavMeshController.OnPillTaken -= TakePowerUp;
    }

    private void Start()
    {
        _currentPowerUpUses = _maxPowerUpsUses;
        OnPowerUpsAmountUpdate?.Invoke(_currentPowerUpUses);
    }

    void TakePowerUp()
    {
        _currentPowerUpUses--;
        
        OnPowerUpsAmountUpdate?.Invoke(_currentPowerUpUses);
        
        if(_currentPowerUpUses <= 0)
            OnOverdose?.Invoke();
    }
}
