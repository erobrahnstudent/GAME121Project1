using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward Robrahn
public class ProjectileBehavior : MonoBehaviour {
    public float timeout;
    public int transferDamage;
    float currentTime;

    private void Start()
    {
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
        if (GetComponentInParent<EnemyController>() != null)
        {
            GetComponentInParent<EnemyController>().TakeDamage((float)transferDamage);
        }
        Destroy(gameObject);
    }

    public void initializeProjectile(int indamage)
    {
        transferDamage = indamage;
    }
}
