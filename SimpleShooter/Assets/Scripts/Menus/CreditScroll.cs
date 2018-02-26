using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class CreditScroll : MonoBehaviour {
    public float scrollSpeed = 4.0f;
	void Update () {
        transform.Translate(transform.position.x, 
                            transform.position.y + (scrollSpeed * Time.deltaTime), 
                            transform.position.z);
	}
}
