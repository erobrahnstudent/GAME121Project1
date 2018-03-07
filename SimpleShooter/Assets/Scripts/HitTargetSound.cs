using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTargetSound : MonoBehaviour {
    AudioSource aud;
    public AudioClip audc;
    
	// Use this for initialization
	void Start () {
        aud = gameObject.GetComponent<AudioSource>();
        aud.clip = audc;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            aud.Play();
        }
    }

}
