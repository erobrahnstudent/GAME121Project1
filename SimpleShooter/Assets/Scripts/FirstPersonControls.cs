using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class FirstPersonControls : MonoBehaviour {
    public float speed = 10.0f;
    public float airspeed = 5.0f;
    public float sensitivityX = 10.0f;
    public float gravity = 5f;
    public float groundedgrav = 0.75f;
    
    public CharacterController playerController;

    public float jumpSpeed = 10;
    float verticalVelocity;
    public float velocityDecay = 5f;
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	void Update () {
        if (playerController.isGrounded)
        {
            if (verticalVelocity < 0) verticalVelocity = 0;
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
            moveDirection.Normalize();
            if (Input.GetKey(KeyCode.Space) && verticalVelocity == 0)
            {
                verticalVelocity = jumpSpeed;
                moveDirection.y += verticalVelocity;
            }
            playerController.Move(moveDirection * speed * Time.deltaTime);
        }
        else
        {
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
            moveDirection.Normalize();
            verticalVelocity -= velocityDecay * Time.deltaTime;
            moveDirection.y += verticalVelocity;
            playerController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        // depreciated transform:
        // transform.position += moveDirection.normalized * speed * Time.deltaTime;

        if (Input.GetAxis("Mouse X") > 0.002f || Input.GetAxis("Mouse X") < 0.002f)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
    }
}
