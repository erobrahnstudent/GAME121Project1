using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonHealthControl : MonoBehaviour {
    public float MaxHealth;
    public float Health {get; set;}

    public bool healthCheck()
    {
        if (Health >= MaxHealth - 0.001) return false;
        else return true;
    }

    public void Damage(float x)
    {
        Health -= x;
        if (Health < 0)
        {
            die();
        }
    }
    public void Heal(float x)
    {
        Health += x;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    void die()
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        FindObjectOfType<UIBehavior>().StopPlaying(false);
        this.enabled = false;
    }
}
