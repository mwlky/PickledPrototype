using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsCanvas : MonoBehaviour
{
    [SerializeField] private GameObject hearthImagePrefab;
    [SerializeField] private Transform parent;

    private List<GameObject> hearts = new();

    private int hearthAmount;
    
    // private void OnEnable()
    // {
    //     PowerupController.OnPowerUpsAmountUpdate += UpdateHearthUI;
    // }
    //
    // private void OnDisable()
    // {
    //     PowerupController.OnPowerUpsAmountUpdate -= UpdateHearthUI;
    // }

    private void Start()
    {
        hearthAmount = 3;
    }

    void UpdateHearthUI(int amount)
    {
        hearthAmount = amount;
        
        GenerateHearthUI();
    }

    void GenerateHearthUI()
    {
        for (int i = 0; i < hearthAmount; i++)
        {
            GameObject hearthIcon = Instantiate(hearthImagePrefab, parent);
            hearts.Add(hearthIcon);
        }
    }
}
