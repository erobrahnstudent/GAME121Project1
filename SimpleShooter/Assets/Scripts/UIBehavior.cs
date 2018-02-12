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
    public GameObject ammocounters;

    public GameObject[] counters;
    public Text[] countertext;
    bool playing = true;

    private void LateUpdate()
    {
        if (playing)
        {
            foreach (GameObject counter in counters)
            {
                int index1 = System.Array.IndexOf(counters, counter);
                if (control.hasWeapon[index1] && control.ammo[index1] > 0 && !counter.activeInHierarchy)
                {
                    counter.SetActive(true);
                    countertext[index1].text = control.ammo[index1].ToString();
                }
                else if (control.hasWeapon[index1] && counter.activeInHierarchy)
                {
                    if (control.ammo[index1] <= 0)
                    {
                        counter.SetActive(false);
                    }
                    else countertext[index1].text = control.ammo[index1].ToString();
                }
            }
            cooldownText.text = control.currentCooldown.ToString();
        }
    }

    public void StopPlaying()
    {
        playing = false;
        ammocounters.SetActive(false);
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
