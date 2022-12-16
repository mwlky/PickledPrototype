using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshController : MonoBehaviour
{
    [SerializeField] private Transform _movePositionWaypoint;

    [SerializeField] private float _agentSpeed;

    private NavMeshAgent _navMeshAgent;
    private bool isPlayerHoldingPill;

    private void Awake() =>
        _navMeshAgent = GetComponent<NavMeshAgent>();

    private void OnEnable() =>
        PickUpController.onPlayerHoldingTheObject += PlayerPickedUpPill;
    
    private void OnDisable() =>
        PickUpController.onPlayerHoldingTheObject -= PlayerPickedUpPill;
    
    private void Update() =>
        SetDestination();

    void PlayerPickedUpPill(bool holding) =>
        isPlayerHoldingPill = holding;
    
    void SetDestination()
    {
        if (isPlayerHoldingPill)
        {
            _navMeshAgent.destination = _movePositionWaypoint.position;
            _navMeshAgent.speed = 0f;
            return;
        }

        _navMeshAgent.destination = _movePositionWaypoint.position;
        _navMeshAgent.speed = _agentSpeed;
    }
}