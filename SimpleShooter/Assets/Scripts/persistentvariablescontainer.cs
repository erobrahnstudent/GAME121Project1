using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class persistentvariablescontainer : MonoBehaviour {
    public AudioMixer AM;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
