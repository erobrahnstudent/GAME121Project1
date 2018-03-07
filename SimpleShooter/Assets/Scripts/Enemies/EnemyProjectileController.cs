using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    float Damage = 0.0f;
    public float timeout;
    float currentTime;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeout)
        {
            Destroy(gameObject);
        }
    }

    public void init(float damage)
    {
        Damage = damage;
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
