using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class TargetBehavior : MonoBehaviour {
    public int Health = 100;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        print("Target " + gameObject.name + " has taken " + damage + " damage. Remaining health: " + Health);
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
