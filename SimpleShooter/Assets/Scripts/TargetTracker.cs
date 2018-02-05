using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class TargetTracker : MonoBehaviour {
    List<GameObject> targets;
    public float checkDelay = 5f;
    float timeSinceLastCheck = 0f;
	void Start () {
        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Target"));
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastCheck += Time.deltaTime;
        if (timeSinceLastCheck > checkDelay && targets.Count > 0)
        {
            foreach (GameObject iter in targets)
            {
                if (!iter.activeInHierarchy)
                {
                    targets.Remove(iter);
                }
            }
        }
	}
}
