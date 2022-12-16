using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshController : MonoBehaviour
{
    [SerializeField] public Transform _movePositionWaypoint;
    [SerializeField] private Transform _pillStartingPosition;

    [SerializeField] private float _agentSpeed;

    public static event Action OnGameLose;
    public static event Action OnPillTaken;

    private StateMachine _stateMachine;
    private NavMeshAgent _navMeshAgent;
    public bool _isPlayerHoldingPill;

    [SerializeField] private GameObject pillPrefab;
    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _stateMachine = new StateMachine();
        _stateMachine.AddState("followPill",
            new FollowPillState(_navMeshAgent, _agentSpeed, this));
        _stateMachine.AddState("powerPill", new PowerPillState(_navMeshAgent, transform));

        _stateMachine.ChangeState("followPill");
    }

    private void OnEnable() =>
        PickUpController.onPlayerHoldingTheObject += PlayerPickedUpPill;

    private void OnDisable() =>
        PickUpController.onPlayerHoldingTheObject -= PlayerPickedUpPill;

    private void Update()
    {
        _stateMachine.Update();
    }

    void PlayerPickedUpPill(bool holding) =>
        _isPlayerHoldingPill = holding;


    public IEnumerator PowerPill()
    {
        _stateMachine.ChangeState("powerPill");

        yield return new WaitForSeconds(5f);
        _movePositionWaypoint = Instantiate(pillPrefab, _pillStartingPosition).transform;

        _stateMachine.ChangeState("followPill");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (_stateMachine.GetCurrentState() == _stateMachine._states["followPill"])
        {
            if (collision.gameObject.CompareTag("Enemy")) OnGameLose?.Invoke();
        }


        if (_stateMachine.GetCurrentState() == _stateMachine._states["powerPill"])
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameManager.Instance.enemies.Remove(collision.gameObject);
                Transform spawnPoint = collision.gameObject.GetComponent<EnemyRandomPatrolController>().StartingPoint;

                StartCoroutine(SpawnEnemy(spawnPoint));
                Destroy(collision.gameObject);

            }
        }

        if (_isPlayerHoldingPill)
        {
            if (collision.gameObject.tag == "Pill")
            {
                OnPillTaken?.Invoke();
                Destroy(collision.gameObject);
                _isPlayerHoldingPill = false;
                StartCoroutine("PowerPill");
            }
        }else if (collision.gameObject.tag == "Pill")

        {
            OnGameLose?.Invoke();
        }
    }

    public IEnumerator SpawnEnemy(Transform startPoint)
    {
        yield return new WaitForSeconds(10);
        GameManager.Instance.enemies.Add(Instantiate(enemyPrefab, startPoint));
    }
}