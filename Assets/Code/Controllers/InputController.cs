using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action onSpawnDestiny; 

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            onSpawnDestiny?.Invoke();
    }
}
