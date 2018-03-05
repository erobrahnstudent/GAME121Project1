using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MasterSoundControl), typeof(AudioSource))]
public class MusicControl : MonoBehaviour {
    public AudioClip Action;
    public AudioClip Finish;

    AudioSource mas;
	// Use this for initialization
	void Start () {
        mas = gameObject.GetComponent<AudioSource>();
        mas.clip = Action;
        mas.Play();
	}
    public void stop()
    {
        mas.Stop();
    }

    public void victory()
    {
        mas.Stop();
        mas.clip = Finish;
        mas.Play();
    }
}
