using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int EnemyHealth = 20; //Eftersom v�r skada �r 5 m�ste vi d� skjuta Zombien 4 ggr innan den d�r
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
            TheEnemy.GetComponent<Animation>().Stop("Walk"); //Namnet p� din animation
            TheEnemy.GetComponent<Animation>().Play("Die"); //namnet p� din animation
            //JumpscareMusic.Stop();
        }
    }
}
