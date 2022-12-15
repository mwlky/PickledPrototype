using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCarrot : MonoBehaviour
{
    public static event Action OnCarrotCollected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        OnCarrotCollected?.Invoke();
        
        Destroy(gameObject);
    }
}
