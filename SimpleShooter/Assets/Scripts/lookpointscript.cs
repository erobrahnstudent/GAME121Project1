using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookpointscript : MonoBehaviour {
    public GameObject player;
    void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
	}
}
