using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public JumpScare jumpscareManager;
    private EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>(); // Get the EnemyAI component
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Triggering jumpscare");
            jumpscareManager.TriggerJumpscare();
            if (enemyAI != null)
            {
                enemyAI.StartJumpscare(); // Start the jumpscare in EnemyAI
            }
            // Optionally, you can disable or reset other components here
        }
    }
}
