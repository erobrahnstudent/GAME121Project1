using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2D : MonoBehaviour {

    public float movementSpeed;

	void Update () {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        moveDirection = moveDirection.normalized;
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
    }
}
