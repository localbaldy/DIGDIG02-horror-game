using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject stalkerDes; // Player object
    NavMeshAgent stalkerAgent;
    public GameObject theEnemy;
    public float normalSpeed = 0.01f;
    public float chaseSpeed = 0.05f;
    private float enemySpeed;
    public float detectionRange = 10f;
    public LayerMask playerLayer; // Set this to the layer the player is on

    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
        enemySpeed = normalSpeed;
    }

    void Update()
    {
        stalkerAgent.SetDestination(stalkerDes.transform.position);

        if (IsPlayerInSight())
        {
            enemySpeed = chaseSpeed;
        }
        else
        {
            enemySpeed = normalSpeed;
        }

        theEnemy.GetComponent<Animation>().Play("Walk"); // Name of your walk animation
        transform.position = Vector3.MoveTowards(transform.position, stalkerDes.transform.position, enemySpeed);
    }

    bool IsPlayerInSight()
    {
        Vector3 directionToPlayer = stalkerDes.transform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= detectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, detectionRange, playerLayer))
            {
                if (hit.transform == stalkerDes.transform)
                {
                    return true; // Player is within sight
                }
            }
        }
        return false; // Player is not within sight
    }
}
