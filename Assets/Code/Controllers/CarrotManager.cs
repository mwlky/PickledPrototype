using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotManager : MonoBehaviour
{
    public static event Action OnAllCarrotsCollected;
    public static event Action<int> OnCarrotsCounted;

    public static List<GameObject> carrotsCount = new();
    private int amountOfCarrots;

    private void Awake() =>
        CountAllCarrots();

    private void OnEnable() =>
        CollectCarrot.OnCarrotCollected += CarrotCollected;

    private void OnDisable()=>
        CollectCarrot.OnCarrotCollected -= CarrotCollected;

    void CountAllCarrots()
    {
        Carrot[] carrotsOnMap = FindObjectsOfType<Carrot>();

        amountOfCarrots = carrotsOnMap.Length;
        OnCarrotsCounted?.Invoke(amountOfCarrots);
    }

    void CarrotCollected()
    {
        amountOfCarrots -= 1;

        if(amountOfCarrots <= 0)
            OnAllCarrotsCollected?.Invoke();
    }
}