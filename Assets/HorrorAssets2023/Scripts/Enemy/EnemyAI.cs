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
    public float animSpeed = 1.0f;
    public float footstepDistance = 5f; // Distance within which footsteps will be audible
    public float maxVolume = 1.0f; // Maximum volume of the footsteps
    Animation enemyAnimation; // Using legacy Animation
    AudioSource footstepAudio; // Footstep sound source
    public string walkAnim = "Walk";  // Name of the walk animation
    public string runAnim = "Run";    // Name of the run animation
    public Transform player;
    private bool isJumpscaring = false; // Flag to check if jumpscare is active

    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
        enemySpeed = normalSpeed;
        enemyAnimation = theEnemy.GetComponent<Animation>(); // Using Animation instead of Animator
        footstepAudio = theEnemy.GetComponent<AudioSource>(); // Make sure there's an AudioSource attached to theEnemy

    }

    void Update()
    {
        if (isJumpscaring) return; // Skip updates if jumpscare is active
                                   // Updatera players position konstant
        stalkerAgent.SetDestination(player.position);

        stalkerAgent.SetDestination(stalkerDes.transform.position);

        // Adjust footstep volume based on distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, stalkerDes.transform.position);
        if (distanceToPlayer <= footstepDistance)
        {
            footstepAudio.volume = Mathf.Lerp(0, maxVolume, (footstepDistance - distanceToPlayer) / footstepDistance);
            if (!footstepAudio.isPlaying)
            {
                footstepAudio.Play();
            }
        }
        else
        {
            footstepAudio.volume = 0;
            if (footstepAudio.isPlaying)
            {
                footstepAudio.Stop();
            }
        }

        // Check if player is within sight (close to enemy)
        if (IsPlayerInSight())
        {
            enemySpeed = chaseSpeed;
            enemyAnimation[runAnim].speed = animSpeed; // Set animation speed for running
            if (!enemyAnimation.IsPlaying(runAnim))
            {
                enemyAnimation.Play(runAnim); // Switch to run animation
            }
        }
        else
        {
            enemySpeed = normalSpeed;
            enemyAnimation[walkAnim].speed = animSpeed; // Set animation speed for walking
            if (!enemyAnimation.IsPlaying(walkAnim))
            {
                enemyAnimation.Play(walkAnim); // Switch to walk animation
            }
        }

        // Move enemy towards player
        transform.position = Vector3.MoveTowards(transform.position, stalkerDes.transform.position, enemySpeed);


        // Se till s� att enemy hela tiden r�r sig �ven om det inte finns en direkt v�g, aka player inte r�r sig
        if (stalkerAgent.remainingDistance > stalkerAgent.stoppingDistance)
        {
            stalkerAgent.isStopped = false;
        }
        else
        {
            // Enemy �r fast och kan inte n� player, r�r sig till den hittar en v�g
            stalkerAgent.isStopped = true;
            Wander();
        }
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
                    Debug.Log("den ser dig");
                }
            }
        }
        return false; // Player is not within sight
    }

    public void StartJumpscare()
    {
        isJumpscaring = true; // Set the flag to true to disable further updates
        footstepAudio.Stop(); // Stop footsteps audio if playing
        // Optionally, you can add other jumpscare-related code here
    }

    void Wander()
    {
        // Generera random punkter enemy kan r�ra sig i tills den hittar player igen
        Vector3 randomDirection = Random.insideUnitSphere * 5f;
        randomDirection += transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, 5f, 1))
        {
            stalkerAgent.SetDestination(hit.position);
        }
    }


}
