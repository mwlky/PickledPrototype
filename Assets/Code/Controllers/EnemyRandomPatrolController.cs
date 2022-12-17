using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRandomPatrolController : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _chaseDistance;

    private StateMachine _stateMachine;
    private NavMeshAgent _navMeshAgent;
    private Transform _playerTransform;

    public Transform StartingPoint { get; private set; }

    public RandomNavMeshPath _randomNavMeshPath;

    private void Awake()
    {
        StartingPoint = this.transform;

        GameManager.Instance.enemies.Add(gameObject);

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        _randomNavMeshPath = new RandomNavMeshPath(transform.position, _range);

        _stateMachine = new StateMachine();
        _stateMachine.AddState("randomPatrol", new RandomPatrolState(_navMeshAgent, _randomNavMeshPath));
        _stateMachine.AddState("chasePlayer", new ChaseState(_navMeshAgent, _playerTransform));
    }

    void Start()
    {
        _stateMachine.ChangeState("randomPatrol");
    }

    void Update()
    {
        if (CheckDistanceForChase())
        {
            _stateMachine.ChangeState("chasePlayer");
        }
        else
        {
            _stateMachine.ChangeState("randomPatrol");
        }

        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
       
    }

    private bool CheckDistanceForChase()
    {
        if (Vector3.Distance(transform.position, _playerTransform.position) > _chaseDistance) return false;

        return true;
    }
}
