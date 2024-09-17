using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    
    public JumpScare jumpscareManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("nuddar");
            jumpscareManager.TriggerJumpscare();
            //back to the menu
        }
    }
}
