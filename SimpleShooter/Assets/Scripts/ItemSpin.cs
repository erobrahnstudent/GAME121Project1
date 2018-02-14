using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpin : MonoBehaviour {
    public float spinSpeed;

    public float hoverSpeed;
    public float hoverBounds;

    bool updown;
    bool leftright;
    float initial;

	void Start () {
		if (Random.Range(0 , 10) >= 5) updown = true;
        else updown = false;
        if (Random.Range(0 , 10) >= 5) leftright = true;
        else leftright = false;
        initial = transform.position.y;
        // print(initial + hoverBounds);
        // print(initial - hoverBounds);
    }
	
	// Update is called once per frame
	void Update () {
        if (updown) transform.position += new Vector3(0, hoverSpeed * Time.deltaTime, 0);
        else transform.position += new Vector3(0, -hoverSpeed * Time.deltaTime, 0);
        if (transform.position.y >= initial + hoverBounds)
        {
            updown = false;
            // print("going Down");
        }
        if (transform.position.y <= initial - hoverBounds)
        {
            updown = true;
            // print("going Up");
        }
            

        if (leftright) transform.Rotate(transform.up, -spinSpeed * Time.deltaTime);
        else transform.Rotate(transform.up, spinSpeed * Time.deltaTime);

    }

    public static float ClampAngle(float angle)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, 0, 360);
    }
}
