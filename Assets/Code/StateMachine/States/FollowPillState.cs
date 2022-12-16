using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPillState : IState
{
    private NavMeshAgent _navMeshAgent;
    private float _agentSpeed;
    private Transform _movePositionWaypoint;
    private PlayerNavMeshController _playerNavMeshController;

    public FollowPillState(NavMeshAgent navMeshAgent, float agentSpeed,
                            PlayerNavMeshController playerNavMeshController)
    {
        this._navMeshAgent = navMeshAgent;
        this._agentSpeed = agentSpeed;
        //this._movePositionWaypoint = movePositionWaypoint;
        this._playerNavMeshController = playerNavMeshController;
    }

    public void Enter()
    {
        _navMeshAgent.speed = +_agentSpeed;
    }

    public void Exit()
    {
        
    }

    public void PhysicsUpdate()
    {
        
    }

    public void Update()
    {
        SetDestination();
    }

    void SetDestination()
    {
        if (_playerNavMeshController._isPlayerHoldingPill)
        {
            _navMeshAgent.destination = _playerNavMeshController._movePositionWaypoint.position;
            _navMeshAgent.speed = 0f;
            return;
        }

        _navMeshAgent.destination = _playerNavMeshController._movePositionWaypoint.position;
        _navMeshAgent.speed = _agentSpeed;
    }
}
