using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookpointscript : MonoBehaviour {
    public GameObject player;
    public float yOffset = 1.25f;
    void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x,  
                                         player.transform.position.y + yOffset, 
                                         player.transform.position.z);
	}
}
