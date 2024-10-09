using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorScript : MonoBehaviour
{
    public float theDistance; 
    public GameObject actionKey; 
    public GameObject actionText; 
    public GameObject theDoor;
    public AudioSource doorSound;

    void Update()
    {
        theDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (theDistance <= 3) 
        {
           
            actionKey.SetActive(true);
            actionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action")) 
        {
            if (theDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                actionText.SetActive(false);
                theDoor.GetComponent<Animation>().Play("Door anim"); 
                doorSound.Play();
            }
        }
    }


    private void OnMouseExit() 
    {
       
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }
}
