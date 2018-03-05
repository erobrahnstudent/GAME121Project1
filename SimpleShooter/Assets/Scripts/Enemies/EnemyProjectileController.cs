using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour {
    float Damage = 0.0f;
    float Velocity = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(Vector3.forward * Velocity * Time.deltaTime);
	}

    public void init(float damage, float velocity, Quaternion rotation)
    {
        Damage = damage;
        Velocity = velocity;
        transform.rotation = rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<FirstPersonHealthControl>().Damage(Damage);
            Destroy(this.gameObject);
        }
    }
}
