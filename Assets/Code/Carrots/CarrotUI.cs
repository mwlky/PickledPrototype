using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotUI : MonoBehaviour
{
    [SerializeField] private Sprite usedImage;
    
    private Image image;

    private bool isMarkedAsCollected;

    private void Awake() =>
        image = GetComponentInChildren<Image>();
    
    public void SetAsMarked()
    {
        if (isMarkedAsCollected) return;
        isMarkedAsCollected = true;

        SetToActive();
    }

    void SetToActive() =>
        image.sprite = usedImage;
}