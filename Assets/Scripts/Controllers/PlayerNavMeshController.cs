using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshController : MonoBehaviour
{
    [SerializeField] private Transform _movePositionWaypoint;

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.destination = _movePositionWaypoint.position;
    }
}
