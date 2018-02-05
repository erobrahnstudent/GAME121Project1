using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class FirstPersonControls : MonoBehaviour {
    public float speed = 10.0f;
    public float sensitivityX = 10.0f;

	void Start () {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
	}
	
	void Update () {
        Vector3 moveDirection = Vector3.zero;
		if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
    }
}
