using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour {
    public Transform[] patrolroute;
    int patrolPointTarget = 0;
    public float satisfactoryBounds = 1f;

    public Vector3 getFirst() { return patrolroute[0].position; }

    public Vector3 NextWaypoint()
    {
        if (patrolPointTarget >= patrolroute.Length - 1)
        {
            patrolPointTarget = 0;
            return patrolroute[patrolPointTarget].position;
        }
        else
        {
            patrolPointTarget += 1;
            return patrolroute[patrolPointTarget].position;
        }
    }

    public bool withinBounds(Vector3 position)
    {
        if (position.x < patrolroute[patrolPointTarget].position.x + satisfactoryBounds &&
            position.x > patrolroute[patrolPointTarget].position.x - satisfactoryBounds &&
            position.z > patrolroute[patrolPointTarget].position.z - satisfactoryBounds &&
            position.z < patrolroute[patrolPointTarget].position.z + satisfactoryBounds)
        {
            return true;
        }
        else return false;
    }
}
