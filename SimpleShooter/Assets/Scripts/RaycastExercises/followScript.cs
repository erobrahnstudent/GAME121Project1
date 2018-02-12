using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour {
    public GameObject followThis;
    public float chaseSpeed = 2.0f;
    public float rayLengthLimit = 5.0f;
    public float followDistance = 2.0f;
    public LayerMask mask;

	void Update () {
        RaycastHit playerLOS;
        if (Physics.Raycast(transform.position, followThis.transform.position, out playerLOS, rayLengthLimit, mask.value))
        {
            //Debug.Log(playerLOS.distance);
            if (playerLOS.distance > followDistance)
            {
                Vector3 direction = followThis.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                transform.position += direction * chaseSpeed * Time.deltaTime;
                // transform.Translate(move.normalized * chaseSpeed * Time.deltaTime, Space.World);
            }
        }
	}
}
