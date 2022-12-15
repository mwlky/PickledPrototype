using UnityEngine;
using UnityEngine.AI;

public class RandomNavMeshPath
{
    private float _range;
    private Vector3 _objectCenterPosition;

    public RandomNavMeshPath(Vector3 objectCenterPosition, float range)
    {
        this._range = range;
        this._objectCenterPosition = objectCenterPosition;
    }

    public bool RandomPoint(out Vector3 result)
    {

        Vector3 randomPoint = _objectCenterPosition + Random.insideUnitSphere * _range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
