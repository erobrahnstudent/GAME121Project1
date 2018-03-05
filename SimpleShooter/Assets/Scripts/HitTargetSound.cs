using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTargetSount : MonoBehaviour {
    AudioSource aud;
    public AudioClip audc;
    
	// Use this for initialization
	void Start () {
        aud = gameObject.GetComponent<AudioSource>();
        aud.clip = audc;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            aud.Play();
        }
    }
}
