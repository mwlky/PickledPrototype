using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public static event Action<bool> onPlayerHoldingTheObject;

    [Header("Controllers")] [SerializeField]
    private MousePosition mouseController;

    [Header("Collision With Wall Prevent")]
    [SerializeField] private Transform collisionCheck;
    [SerializeField] private float collisionCheckRadius;
    [SerializeField] private LayerMask collisionCheckLayer;

    private bool isHolding;
    private Vector3 pickUpPosition;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            PickUp();

        else if (Input.GetMouseButtonUp(0))
            PutAway();
    }

    private void Update()
    {
        MoveObject();
        FreezeYPosition();
    }

    void MoveObject()
    {
        if (!isHolding) return;
        transform.position = mouseController.GetMousePosition();
    }

    void FreezeYPosition()
    {
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x, -0.5f, currentPosition.z);
    }

    void PickUp()
    {
        isHolding = true;
        pickUpPosition = transform.position;

        onPlayerHoldingTheObject?.Invoke(isHolding);
    }

    void PutAway()
    {
        isHolding = false;
        onPlayerHoldingTheObject?.Invoke(isHolding);

        if (IsColliding())
            transform.position = pickUpPosition;
    }

    bool IsColliding()
    {
        bool isColliding = Physics.CheckSphere(collisionCheck.position, collisionCheckRadius, collisionCheckLayer);
        return isColliding;
    }
}