using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationControl : MonoBehaviour {
    public bool isDead = false;
    public bool isMoving = false;

    Animator ani;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
        {
            ani.SetBool("isDead", true);
            this.enabled = false;
        }
        if (isMoving)
        {
            ani.SetBool("isMoving", true);
        }
        else
        {
            ani.SetBool("isMoving", false);
        }
	}
    // TODO: just get it to ragdoll?
}
