using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class FirstPersonWeaponControl : MonoBehaviour {
    int weapon = 0; // 0: Pistol, 1: Shotgun, 2: Rifle
    public int[] ammo = { 25, 0, 0 };
    public int[] damage = { 10, 7, 50 };
    public float[] cooldowns = { 0.75f, 1f, 1.5f, 0.25f };
    public float[] speeds = { 500f, 400f, 600f };
    public Material[] weaponmats;
    public Renderer standin;
    float currentCooldown;
    public bool[] hasWeapon = { true, false, false };
    public GameObject barrel;
    public GameObject shot;
	void Start () {
		
	}
	
	void Update () {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < 0) currentCooldown = 0;
        }
		if (Input.GetMouseButton(0))
        {
            if (weapon == 0 && ammo[0] > 0 && currentCooldown <= 0)
            {
                GameObject bullet = Instantiate(shot, barrel.transform.position, barrel.transform.rotation);
                bullet.GetComponent<ProjectileBehavior>().transferDamage = damage[0];
                bullet.GetComponent<ProjectileBehavior>().speed = speeds[0];
                currentCooldown = cooldowns[0];
                --ammo[0];
            }
            if (weapon == 1 && ammo[1] > 0 && currentCooldown <= 0)
            {
                // TODO: Multiple bullets + cone spread
                GameObject bullet = Instantiate(shot, barrel.transform.position, barrel.transform.rotation);
                bullet.GetComponent<ProjectileBehavior>().transferDamage = damage[1];
                bullet.GetComponent<ProjectileBehavior>().speed = speeds[1];
                currentCooldown = cooldowns[1];
                --ammo[1];
            }
            if (weapon == 2 && ammo[2] > 0 && currentCooldown <= 0)
            {
                GameObject bullet = Instantiate(shot, barrel.transform.position, barrel.transform.rotation);
                bullet.GetComponent<ProjectileBehavior>().transferDamage = damage[2];
                bullet.GetComponent<ProjectileBehavior>().speed = speeds[2];
                currentCooldown = cooldowns[2];
                --ammo[2];
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weapon != 0 && hasWeapon[0])
            {
                weapon = 0;
                currentCooldown = cooldowns[3];
                standin.material = weaponmats[0];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weapon != 1 && hasWeapon[1])
            {
                weapon = 1;
                currentCooldown = cooldowns[3];
                standin.material = weaponmats[1];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weapon != 2 && hasWeapon[2])
            {
                weapon = 2;
                currentCooldown = cooldowns[3];
                standin.material = weaponmats[2];
            }
        }
    }
}
