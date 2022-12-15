using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject carrotUIPrefab;
    [SerializeField] private Transform parent;

    private int carrotsAmount;
    private int carrotsCollected = 0;

    private List<GameObject> generatedUICarrots = new();

    private void OnEnable()
    {
        CarrotManager.OnCarrotsCounted += SetCarrotsAmount;
        CollectCarrot.OnCarrotCollected += UpdateCarrotUI;
    }

    private void OnDisable()
    {
        CarrotManager.OnCarrotsCounted -= SetCarrotsAmount;
        CollectCarrot.OnCarrotCollected -= UpdateCarrotUI;
    }

    private void Start() =>
        GenerateCarrotsUI();
    
    void SetCarrotsAmount(int amount) =>
        carrotsAmount = amount;

    void UpdateCarrotUI()
    {
        carrotsCollected++;
        
        for (int i = 0; i < carrotsCollected; i++)
        {
            generatedUICarrots[i].GetComponent<CarrotUI>().SetAsMarked();
        }
    }

    void GenerateCarrotsUI()
    {
        for (int i = 0; i < carrotsAmount; i++)
        {
            GameObject generatedCarrot = Instantiate(carrotUIPrefab, parent);
            generatedUICarrots.Add(generatedCarrot);
        }
    }
}