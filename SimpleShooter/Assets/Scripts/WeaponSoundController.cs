using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(FirstPersonWeaponControl))]
public class WeaponSoundController : MonoBehaviour {
    public List<AudioClip> WACL = new List<AudioClip>();
    AudioSource aud;
    FirstPersonWeaponControl wc;
    MasterSoundControl master;

    bool cooldown = false;
    float cdt;
	// Use this for initialization
	void Start () {
        wc = gameObject.GetComponent<FirstPersonWeaponControl>();
        aud = gameObject.GetComponent<AudioSource>();
        master = FindObjectOfType<MasterSoundControl>();
        aud.clip = WACL[wc.weapon];
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldown)
        {
            cdt -= Time.deltaTime;
            if (cdt <= 0)
            {
                cooldown = false;
            }
        }
        aud.clip = WACL[wc.weapon];
        if (Input.GetMouseButton(0) && wc.ammo[wc.weapon] > 0 && cooldown == false)
        {
            aud.Play();
            cdt = wc.cooldowns[wc.weapon];
            cooldown = true;
        }
	}
}
