using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour {
    public float sensitivityY = 10.0f;

    public float minYRotation = -90f;
    public float maxYRotation = 90f;
    public float currentRotation = 0.0f;
    public float euler;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentRotation = -Input.GetAxis("Mouse Y") * sensitivityY;
        euler = transform.rotation.eulerAngles.x;
        if (euler > 180)
        {
            euler -= 360;
        }

        if (currentRotation + euler >= maxYRotation && currentRotation > 0)
        {
            currentRotation = 0.0f;
        }
        if (currentRotation + euler <= minYRotation && currentRotation < 0)
        {
            currentRotation = 0.0f;
        }
        transform.Rotate(Vector3.right, currentRotation);
        //TODO: Change this so that we check a rotation delta first before rotation is applied and make sure it's within our bounds
    }
}
