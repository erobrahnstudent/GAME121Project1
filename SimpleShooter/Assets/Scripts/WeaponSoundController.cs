using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(FirstPersonWeaponControl))]
public class WeaponSoundController : MonoBehaviour {
    public List<AudioClip> WACL = new List<AudioClip>();
    AudioSource aud;
    FirstPersonWeaponControl wc;
    MasterSoundControl master;
	// Use this for initialization
	void Start () {
        wc = gameObject.GetComponent<FirstPersonWeaponControl>();
        aud = gameObject.GetComponent<AudioSource>();
        master = FindObjectOfType<MasterSoundControl>();
        aud.clip = WACL[wc.weapon];
	}
	
	// Update is called once per frame
	void Update () {
        aud.clip = WACL[wc.weapon];
        if (Input.GetMouseButtonDown(0) && wc.currentCooldown <= 0.01 && wc.ammo[0] > 0)
        {
            aud.Play();
        }
	}
}
