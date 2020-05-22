using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   // public float moveSpeed;
   // public Rigidbody theRB;

    public bool chasing;

    public float distanceToChase = 10f, distanceToLose = 15f, distanceToStop = 2;
    public float keepChasingTime = 5f;
    public float chaseCounter;

    private Vector3 targetPoint, startPoint;

    public NavMeshAgent agent;

    public GameObject bullet;
    public Transform firePoint;
    public float fireRate, waitBetweenShots = 2f, TimeToshot = 1f;
    private float fireCount, shotWaitCounter, shotTimeCounter;


    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;

        shotTimeCounter = TimeToshot;
        shotWaitCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = Player.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position,targetPoint) < distanceToChase)
            {
                chasing = true;

                shotTimeCounter = TimeToshot;
                shotWaitCounter = waitBetweenShots;

            }

            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;

                if (chaseCounter <= 0)
                {
                    agent.destination = startPoint;
                }

            }
        }
        else
        {
            // transform.LookAt(targetPoint);
            // theRB.velocity = transform.forward * moveSpeed;

            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {
                agent.destination = targetPoint;
            }
            else
            {
                agent.destination = transform.position;
            }

            if (Vector3.Distance(transform.position,targetPoint) > distanceToLose)
            {
                chasing = false;


                chaseCounter = keepChasingTime;
            }

            if (shotWaitCounter > 0)
            {
                shotWaitCounter -= Time.deltaTime;

                if(shotWaitCounter <= 0)
                {
                    shotTimeCounter = TimeToshot;
                }
            }
            else
            {

                shotTimeCounter -= Time.deltaTime;

                if (shotTimeCounter > 0)
                {

                    fireCount -= Time.deltaTime;

                    if (fireCount <= 0)
                    {
                        fireCount = fireRate;

                        Instantiate(bullet, firePoint.position, firePoint.rotation);
                    }
                }
                else
                {
                    shotWaitCounter = waitBetweenShots;
                }
            }
        }
    }
}
