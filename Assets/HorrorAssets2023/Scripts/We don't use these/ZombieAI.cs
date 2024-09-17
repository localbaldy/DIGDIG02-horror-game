using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    //public AudioSource hurtSound1;
    //public AudioSource hurtSound2;
    //public AudioSource hurtSound3;
    //public int hurtGen;
    //public GameObject theFlash;

    void Update()
    {
        transform.LookAt(thePlayer.transform);
        if (attackTrigger == false)
        {
            //enemySpeed = 0.01f;
            theEnemy.GetComponent<Animation>().Play("Walking");
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
        }
        if (attackTrigger == true && isAttacking == false)
        {
            //enemySpeed = 0;
            theEnemy.GetComponent<Animation>().Play("Attack");
            //StartCoroutine(InflictDamage());
        }
    }
    /*void OnTriggerEnter()
    {
        Debug.Log("Is this happening?");
        attackTrigger = true;
    }
    void OnTriggerExit()
    {
        attackTrigger = false;
    }

    IEnumerator InflictDamage()
    {
        Debug.Log("inflictingdamage");
        isAttacking = true;
        yield return new WaitForSeconds(1.1f);
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
        {
            hurtSound1.Play();
        }
        if (hurtGen == 1)
        {
            hurtSound2.Play();
        }
        if (hurtGen == 1)
        {
            hurtSound3.Play();
        }
        theFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        theFlash.SetActive(false);
        GlobalHealth.currentHealth -= 5; //skadan som Zombie gör på player
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }*/

}
