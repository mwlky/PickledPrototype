using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    private NavMeshAgent _navMeshAgent;
    private Transform _playerTransform;

    public ChaseState(NavMeshAgent navMeshAgent, Transform playerTransform)
    {
        this._navMeshAgent = navMeshAgent;
        this._playerTransform = playerTransform;
    }

    public void Enter()
    {
        _navMeshAgent.SetDestination(_playerTransform.position);
    }

    public void Exit()
    {
        
    }

    public void PhysicsUpdate()
    {
        
    }

    public void Update()
    {
        
    }
}
