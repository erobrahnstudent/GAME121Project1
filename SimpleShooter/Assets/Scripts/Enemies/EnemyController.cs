using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Edward "Screaming loudly into the yawning abyss" Robrahn
[RequireComponent (typeof(EnemyPatrolScript))]
public class EnemyController : MonoBehaviour {
    [SerializeField]
    float noticeRadius = 10.0f;
    [SerializeField]
    float attackRadius = 5.0f;
    [SerializeField]
    float stopRadius = 3.0f;

    [SerializeField]
    float health;
    [SerializeField]
    float speed;
    [SerializeField]
    float SecondsBetweenFiring = 2.0f;
    float currentFireTimer = 0.0f;
    bool fireTimerStarted = false;

    [SerializeField]
    float Damage;

    [SerializeField]
    float Velocity;

    [SerializeField]
    float rotateSpeed = 30f;

    public GameObject enemyProjectile;
    public Transform firePoint;
    RaycastHit noticeRay;

    [SerializeField]
    int state = 0; // 0 = idle/patrolling, 1 = searching, 2 = attacking
    float noticeTimer = 5.0f; // Controls when the enemy will go back to patrolling
    float currentTimer = 0.0f;
    bool timerStarted = false;

    bool moving = true;
    EnemyPatrolScript pat;

    bool playerInSight;
    Vector3 LastKnownPos;
    Vector3 destination;
    Vector3 savedest;
    GameObject player;
    Animator ani;

	void Start () {
        player = FindObjectOfType<FirstPersonControls>().gameObject;
        pat = gameObject.GetComponent<EnemyPatrolScript>();
        ani = gameObject.GetComponent<Animator>();
        destination = pat.getFirst();
	}
	
	void Update () {
        if (fireTimerStarted) currentFireTimer += Time.deltaTime;
        if (timerStarted) currentTimer += Time.deltaTime;
        if (state == 0)
        {
            if (pat.withinBounds(transform.position))
            {
                savedest = pat.NextWaypoint();
                destination = savedest;
                moving = true;
            }
            if (Physics.Raycast(this.transform.position, player.transform.position, out noticeRay, noticeRadius))
            {
                if (noticeRay.collider.gameObject.tag == "Player")
                {
                    state = 1;
                    playerInSight = true;
                    LastKnownPos = player.transform.position;
                    destination = LastKnownPos;
                }
            }

            Vector3 direction = destination - transform.position;
            direction = direction.normalized;
            direction.y = 0;
            transform.position += direction * speed * Time.deltaTime;
            Vector3 rotateVector = Vector3.RotateTowards(transform.forward, destination, rotateSpeed * Time.deltaTime, 0.0f);
            rotateVector.y = 0;
            transform.rotation = Quaternion.LookRotation(rotateVector);
        }
        else if (state == 1)
        {
            if (Physics.Raycast(this.transform.position, player.transform.position, out noticeRay, noticeRadius))
            {
                if (noticeRay.collider.gameObject.tag == "Player")
                {
                    playerInSight = true;
                    LastKnownPos = player.transform.position;
                    destination = player.transform.position;
                    if (Vector3.Distance(this.transform.position, player.transform.position) <= attackRadius)
                    {
                        state = 2;
                        fireTimerStarted = true;
                    }
                }
                else playerInSight = false;

                if (!playerInSight)
                {
                    destination = LastKnownPos;
                    timerStarted = true;
                }
                else
                {
                    destination = player.transform.position;
                    timerStarted = false;
                }
            }
            else
            {
                currentTimer += Time.deltaTime;
                if (currentTimer >= noticeTimer)
                {
                    state = 0;
                    destination = savedest;
                }
            }
            if (moving)
            {
                Vector3 direction = destination - transform.position;
                direction = direction.normalized;
                direction.y = 0;
                transform.position += direction * speed * Time.deltaTime;
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, direction, rotateSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(rotateVector);
            }
            else if (noticeRay.collider.gameObject.tag == "Player")
            {
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, player.transform.position, rotateSpeed * Time.deltaTime, 0.0f);
                rotateVector.y = 0;
                transform.rotation = Quaternion.LookRotation(rotateVector);
            }
            
        }
        else if (state == 2)
        {
            if (Physics.Raycast(this.transform.position, player.transform.position, out noticeRay, noticeRadius))
            {
                if (noticeRay.collider.gameObject.tag == "Player")
                {
                    playerInSight = true;
                    currentFireTimer += Time.deltaTime;
                    if (currentFireTimer >= SecondsBetweenFiring)
                    {
                        GameObject proj = Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
                        proj.GetComponent<EnemyProjectileController>().init(Damage);
                        proj.GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * Velocity);
                        ani.SetTrigger("isAttacking");
                        currentFireTimer = 0;
                    }
                }
                else playerInSight = false;
            }
            if (Vector3.Distance(this.transform.position, player.transform.position) >= attackRadius)
            {
                state = 1;
                moving = true;
            }
            if (Vector3.Distance(this.transform.position, player.transform.position) <= stopRadius)
            {
                moving = false;
            }
            if (moving)
            {
                Vector3 direction = destination - transform.position;
                direction = direction.normalized;
                direction.y = 0;
                transform.position += direction * speed * Time.deltaTime;
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, destination, rotateSpeed * Time.deltaTime, 0.0f);
                rotateVector.y = 0;
                transform.rotation = Quaternion.LookRotation(rotateVector);
            }
            else if (playerInSight)
            {
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, player.transform.position, rotateSpeed * Time.deltaTime, 0.0f);
                rotateVector.y = 0;
                transform.rotation = Quaternion.LookRotation(rotateVector);
            }
        }
        if (moving) ani.SetBool("isMoving", true);
        else ani.SetBool("isMoving", false);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("isDead");
            this.enabled = false;
        }
    }
}
