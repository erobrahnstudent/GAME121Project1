using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCore : MonoBehaviour {
    
    CharacterController control;

    public bool SeekTargetSet;
    bool ArriveExtention;
    bool FleeTargetSet;

    Vector3 target;
    public float satisfactionRadius = 1.0f;
    public float approachRadius = 3.0f;
    public float panicRadius = 5.0f;
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        control = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (SeekTargetSet)
        {
            Vector3 moveDirection = target - transform.position;
            Vector3 rotateVector = Vector3.RotateTowards(transform.forward, moveDirection, rotateSpeed * Time.deltaTime, 0.0f);
            control.transform.rotation = Quaternion.LookRotation(rotateVector);

            if (Vector3.Distance(target, control.transform.position) < approachRadius && ArriveExtention == true)
            {
                float arriveModifier = Vector3.Distance(target, control.transform.position) / approachRadius;
                Mathf.Clamp(arriveModifier, 0.01f, 1.0f);
                control.Move(moveDirection.normalized * (moveSpeed * arriveModifier) * Time.deltaTime);
                if (Vector3.Distance(target, control.transform.position) < satisfactionRadius)
                {
                    SeekTargetSet = false;
                }
            }
            else
            {
                control.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
                if (Vector3.Distance(target, control.transform.position) < satisfactionRadius)
                {
                    SeekTargetSet = false;
                }
            }
        }
        else if (FleeTargetSet)
        {
            Vector3 moveDirection = transform.position - target;
            control.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
            Vector3 rotateVector = Vector3.RotateTowards(transform.forward, moveDirection, rotateSpeed * Time.deltaTime, 0.0f);
            control.transform.rotation = Quaternion.LookRotation(rotateVector);
            if(Vector3.Distance(target, control.transform.position) > panicRadius)
            {
                FleeTargetSet = false;
            }
        }
	}

    public void Seek(Vector3 position, bool arrive)
    {
        target = position;
        target.y = transform.position.y;
        SeekTargetSet = true;
        FleeTargetSet = false;
    }

    public void Flee(Vector3 position)
    {
        target = position;
        target.y = transform.position.y;
        SeekTargetSet = false;
        FleeTargetSet = true;
    }
}
