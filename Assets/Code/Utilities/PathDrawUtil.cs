using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PathDrawUtil : MonoBehaviour
{
    private LineRenderer _pathLine;
    private NavMeshAgent _agent;
    private Color c = Color.white;
    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _pathLine = GetComponent<LineRenderer>();

        
    }

    public void Update()
    {
        StartCoroutine(DrawPath());
    }

    IEnumerator DrawPath()
    {
        _pathLine.SetPosition(0, transform.position);
        yield return new WaitForEndOfFrame();
        NavMeshPath path = _agent.path;



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
