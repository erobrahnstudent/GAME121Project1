using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveTimer : MonoBehaviour {
    public float timer = 5.0f;
    float current;
    bool active;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
        {
            current += Time.deltaTime;
            if (current >= timer)
            {
                Destroy(this.gameObject);
            }
        }
	}

    public void startTimer()
    {
        active = true;
        current = 0.0f;
    }
}
