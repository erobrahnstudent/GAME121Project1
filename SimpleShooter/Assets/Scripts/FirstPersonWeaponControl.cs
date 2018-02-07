using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class FirstPersonWeaponControl : MonoBehaviour {
    int weapon = 0; // 0: Pistol, 1: Shotgun, 2: Rifle
    public bool[] hasWeapon = { true, false, false };
    public int[] ammo = { 25, 0, 0 };
    public int[] damage = { 10, 7, 50 };
    public float[] cooldowns = { 0.75f, 1f, 1.5f, 0.25f };
    public float[] speeds = { 500f, 400f, 600f };
    public float[] spreadsize = { 0f, 1.0f, 0f };
    public int[] projectiles = { 1, 6, 1 };
    // probably break all that out into an entire weapon class?
    public Material[] weaponmats;
    public Renderer standin;
    public float currentCooldown;
    public GameObject barrel;
    public GameObject shot;
    Quaternion rotation;

    float width; float height;
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
            if (ammo[weapon] > 0 && currentCooldown <= 0)
            {
                for (int fired = 0; fired < projectiles[weapon]; fired++)
                {
                    if (spreadsize[weapon] > 0)
                    {
                        float xSpread = Random.Range(-1f, 1f);
                        float ySpread = Random.Range(-1f, 1f);
                        Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * spreadsize[weapon];
                        rotation = Quaternion.Euler(spread) * barrel.transform.rotation;
                    }
                    else rotation = barrel.transform.rotation;
                    GameObject bullet = Instantiate(shot, barrel.transform.position, rotation);
                    bullet.GetComponent<ProjectileBehavior>().initializeProjectile(damage[weapon]);
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speeds[weapon]);
                }
                currentCooldown = cooldowns[weapon];
                --ammo[weapon];
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

    public void giveAmmo(int weapon, int amount)
    {
        ammo[weapon] += amount;
    }
    public void giveWeapon(int weapon, int ammo)
    {
        if (!hasWeapon[weapon]) hasWeapon[weapon] = true;
        giveAmmo(weapon, ammo);
    }
}
