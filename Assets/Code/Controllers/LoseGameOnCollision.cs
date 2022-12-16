using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameOnCollision : MonoBehaviour
{
    public static event Action OnGameLose;
    
    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player")) return;
        
        OnGameLose?.Invoke();
    }
}
