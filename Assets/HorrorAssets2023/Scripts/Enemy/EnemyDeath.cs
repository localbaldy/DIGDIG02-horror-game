using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int EnemyHealth = 20; //Eftersom vår skada är 5 måste vi då skjuta Zombien 4 ggr innan den dör
    public GameObject TheEnemy;
    public int StatusCheck;
    //public AudioSource JumpscareMusic;

    void DamageEnemy(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }
    void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            //this.GetComponent<EnemyAI>().enabled = false;
            //this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            TheEnemy.GetComponent<Animation>().Stop("Walk"); //Namnet på din animation
            TheEnemy.GetComponent<Animation>().Play("Die"); //namnet på din animation
            //JumpscareMusic.Stop();
        }
    }
}
