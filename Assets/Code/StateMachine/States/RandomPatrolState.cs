using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrolState : IState
{
    private NavMeshAgent _navMeshAgent;
    private RandomNavMeshPath _randomNavMeshPath;

    public RandomPatrolState(NavMeshAgent navMeshAgent, RandomNavMeshPath randomNavMeshPath) 
    {
        this._navMeshAgent = navMeshAgent;
        this._randomNavMeshPath = randomNavMeshPath;
        
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
        RandomWalk();
    }

    private void RandomWalk()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if (_randomNavMeshPath.RandomPoint(out point))
            {
                _navMeshAgent.SetDestination(point);
            }
        }

    }
}
