using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class TargetTracker : MonoBehaviour {
    public List<GameObject> targets;
    public GameObject finalpickup;
    void Start () {
        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Target"));
	}
	
	// Update is called once per frame
	void Update () {
        if (targets.Count <= 0)
        {
            finalpickup.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public void RemoveMe(GameObject tr)
    {
        if (targets.Contains(tr))
        {
            targets.Remove(tr);
        }
    }
}
