using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{
    public float theDistance; //R�knar utifr�n v�r raycast hur n�ra vi �r 
    public GameObject actionKey; //V�r UI [E] text
    public GameObject actionText; //V�r UI instruktion
    public GameObject theDoor;
    public AudioSource doorSound;
    //public GameObject extraCrossHair;
    void Update()
    {
        theDistance = PlayerCasting.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (theDistance <= 3) //N�r vi �r 3 eller minde bort med musen, visa actionkey och text (UI)
        {
            //extraCrossHair.SetActive(true);
            actionKey.SetActive(true);
            actionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action")) //Om spelaren trycker p� E st�nga av collider och UI, samt spela anim och ljudeffekt
        {
            if (theDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                actionText.SetActive(false);
                theDoor.GetComponent<Animation>().Play("Door anim"); //Namnet p� din animation
                doorSound.Play();
            }
        }
    }
    private void OnMouseExit() //N�r musen l�mnar omr�det, visa inte UI
    {
        //extraCrossHair.SetActive(false);
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }
}
