using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponboxBehavior : MonoBehaviour
{
    public int weapon;
    public int ammocount;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<FirstPersonWeaponControl>().giveWeapon(weapon, ammocount);
            gameObject.SetActive(false);
        }
    }
}