using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class ProjectileBehavior : MonoBehaviour {
    public float speed;
    public float timeout;
    public int transferDamage;
    float currentTime;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
    void Update () {
        currentTime += Time.deltaTime;
        if (currentTime > timeout)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TargetBehavior>() != null)
        {
            collision.gameObject.GetComponent<TargetBehavior>().TakeDamage(transferDamage);
        }
        Destroy(gameObject);
    }
}
