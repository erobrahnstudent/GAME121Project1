using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCam : MonoBehaviour {
    public float distance = 5.0f;
    public float pitch = 30.0f;

    public float sensitivityY = 10.0f;
    
    float rotationYAxis;

    public Transform lookpoint;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
    }

    void LateUpdate()
    {
        rotationYAxis += 1 * sensitivityY * distance * 0.02f;
        /* Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                                   transform.rotation.eulerAngles.y,
                                                   0); */
        Quaternion toRotation = Quaternion.Euler(pitch, rotationYAxis, 0);
        Quaternion rotation = toRotation;
        distance = Mathf.Clamp(distance, 3.0f, 5.0f);
        RaycastHit hit;
        if (Physics.Linecast(lookpoint.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }
        Vector3 negativeDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negativeDistance + lookpoint.position;
        transform.rotation = rotation;
        transform.position = position;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
