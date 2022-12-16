using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPillPathDraw : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _playerAgent;
    [SerializeField] private PickUpController _pillPickUpcontroller;
    private LineRenderer _pathLine;

    private void Awake()
    {
        _pathLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (_pillPickUpcontroller.IsColliding())
        {
            _pathLine.enabled = false;
        }
        else
        {
            _pathLine.enabled = true;
        }
        StartCoroutine(DrawPath());
    }

    IEnumerator DrawPath()
    {
        _pathLine.SetPosition(0, transform.position);
        yield return new WaitForEndOfFrame();
        NavMeshPath path = _playerAgent.path;



        Vector3 previousCorner = path.corners[0];
        _pathLine.positionCount = path.corners.Length;

        int i = 1;
        while (i < path.corners.Length)
        {
            Vector3 currentCorner = path.corners[i];
            _pathLine.SetPosition(i, currentCorner);
            previousCorner = currentCorner;
            i++;
        }

    }

}
