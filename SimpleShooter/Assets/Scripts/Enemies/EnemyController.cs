using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(EnemyPatrolScript))]
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
    float rotateSpeed = 30f;

    public GameObject enemyProjectile;
    RaycastHit noticeRay;

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
    CharacterController cont;
    Animator ani;
	void Start () {
        player = FindObjectOfType<FirstPersonControls>().gameObject;
        pat = gameObject.GetComponent<EnemyPatrolScript>();
        cont = gameObject.GetComponent<CharacterController>();
	}
	
	void Update () {
        if (moving) ani.SetBool("isMoving", true);
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

            cont.Move(destination * speed * Time.deltaTime);
            Vector3 rotateVector = Vector3.RotateTowards(transform.forward, destination, rotateSpeed * Time.deltaTime, 0.0f);
            cont.transform.rotation = Quaternion.LookRotation(rotateVector);
        }
        else if (state == 1)
        {
            if (Physics.Raycast(this.transform.position, player.transform.position, out noticeRay, noticeRadius))
            {
                if (noticeRay.collider.gameObject.tag == "Player")
                {
                    playerInSight = true;
                    LastKnownPos = player.transform.position;
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
                }
                else
                {
                    destination = player.transform.position;

                }
            }
            else
            {
                currentTimer += Time.deltaTime;
                if (currentTimer >= noticeTimer)
                {
                    state = 0;
                }
            }
            if (moving)
            {
                cont.Move(destination * speed * Time.deltaTime);
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, destination, rotateSpeed * Time.deltaTime, 0.0f);
                cont.transform.rotation = Quaternion.LookRotation(rotateVector);
            }
            else if (noticeRay.collider.gameObject.tag == "Player")
            {
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, player.transform.position, rotateSpeed * Time.deltaTime, 0.0f);
                cont.transform.rotation = Quaternion.LookRotation(rotateVector);
            }
            
        }
        else if (state == 2)
        {
            if (Physics.Raycast(this.transform.position, player.transform.position, out noticeRay, noticeRadius))
            {
                if (noticeRay.collider.gameObject.tag == "Player")
                {
                    playerInSight = true;
                    if (currentFireTimer >= SecondsBetweenFiring)
                    {
                        // put firing code here
                    }
                }
            }
            if (Vector3.Distance(this.transform.position, player.transform.position) >= attackRadius)
            {
                state = 0;
                moving = true;
            }
            if (Vector3.Distance(this.transform.position, player.transform.position) <= stopRadius)
            {
                moving = false;
            }
            else
            {
                moving = true;
            }
            if (moving)
            {
                cont.Move(destination * speed * Time.deltaTime);
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, destination, rotateSpeed * Time.deltaTime, 0.0f);
                cont.transform.rotation = Quaternion.LookRotation(rotateVector);
            }
            else if (noticeRay.collider.gameObject.tag == "Player")
            {
                Vector3 rotateVector = Vector3.RotateTowards(transform.forward, player.transform.position, rotateSpeed * Time.deltaTime, 0.0f);
                cont.transform.rotation = Quaternion.LookRotation(rotateVector);
            }
        }
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
