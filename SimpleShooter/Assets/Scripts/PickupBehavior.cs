using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour {
    public int weapon;
    public int ammocount;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<FirstPersonWeaponControl>().giveAmmo(weapon, ammocount);
            gameObject.SetActive(false);
        }
    }
}
