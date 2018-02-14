using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * @author Edward Robrahn
 * Makes an object 'patrol' using a set of predefined waypoint game objects.
 */
public class ObjectPatrol : MonoBehaviour {
    public Transform[] patrolroute;
    public float speed = 5.0f;
    public float satisfactoryBounds = 5.0f;
    int patrolPointTarget = 0;
	
	void Update () {
        Vector3 direction = patrolroute[patrolPointTarget].position - transform.position;
        direction = direction.normalized;
        direction.y = 0;
        transform.position += direction * speed * Time.deltaTime;
        if (withinBounds(patrolPointTarget))
        {
            if (patrolPointTarget == patrolroute.Length - 1)
            {
                patrolPointTarget = 0;
            }
            else patrolPointTarget++;
        }
	}

    bool withinBounds(int target)
    {
        if (transform.position.x < patrolroute[target].position.x + satisfactoryBounds &&
            transform.position.x > patrolroute[target].position.x - satisfactoryBounds &&
            transform.position.z > patrolroute[target].position.z - satisfactoryBounds &&
            transform.position.z < patrolroute[target].position.z + satisfactoryBounds)
        {
            return true;
        }
        else return false;
    }
}
