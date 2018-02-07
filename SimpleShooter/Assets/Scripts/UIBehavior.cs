using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    public FirstPersonWeaponControl control;
    public FirstPersonLook look;
    public FirstPersonControls walk;
    public Camera maincam;
    public FlareLayer camf;
    public AudioListener caml;
    public MeshRenderer player;
    public Text cooldownText;
    public GameObject rotatingcam;
    bool playing = true;

    private void LateUpdate()
    {
        if (playing)
        {
            cooldownText.text = control.currentCooldown.ToString();
        }
    }

    public void StopPlaying()
    {
        look.enabled = false;
        walk.enabled = false;
        control.enabled = false;
        cooldownText.enabled = false;
        player.enabled = true;
        maincam.enabled = false;
        camf.enabled = false;
        caml.enabled = false;
        rotatingcam.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
