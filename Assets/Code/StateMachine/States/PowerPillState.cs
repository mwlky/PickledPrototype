using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PowerPillState : IState
{
    private NavMeshAgent _navMeshAgent;
    private Transform _playerTransform;

    public PowerPillState(NavMeshAgent navMeshAgent, Transform playerTransform)
    {
        this._navMeshAgent = navMeshAgent;
        this._playerTransform = playerTransform;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void PhysicsUpdate()
    {
        
    }

    public void Update()
    {
        _navMeshAgent.speed = 3f;
        _navMeshAgent.SetDestination(FindClosestEnemy());
    }

    private Vector3 FindClosestEnemy()
    {
        float closestDistance = 100f;
        Vector3 closestEnemy = Vector3.zero;

        foreach (var enemy in GameManager.Instance.enemies)
        {
            if (enemy != null)
            {
                float currentDistance = Vector3.Distance(_playerTransform.position, enemy.transform.position);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    closestEnemy = enemy.transform.position;
                }
            }
                   
        }

        return closestEnemy;
        
    }
}
