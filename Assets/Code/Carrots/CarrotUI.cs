using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotUI : MonoBehaviour
{
    private Image image;

    private bool isMarkedAsCollected;

    private void Awake() =>
        image = GetComponentInChildren<Image>();
    
    public void SetAsMarked()
    {
        if (isMarkedAsCollected) return;
        isMarkedAsCollected = true;

        ChangeColor();
    }

    void ChangeColor() =>
        image.color = Color.green;
}