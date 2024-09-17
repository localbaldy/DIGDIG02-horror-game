using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinBreak : MonoBehaviour
{
    public GameObject fakePumpkin;
    public GameObject brokenPumpkin;
    public GameObject sphereObject;
    //public AudioSource pumpkinBreak;
    //public GameObject keyObject;
    //public GameObject keyTrigger;
    void DamageEnemy(int DamageAmount)
    {
        StartCoroutine(BreakPumpkin());
    }
    IEnumerator BreakPumpkin()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //pumpkinBreak.Play();
        //keyObject.SetActive(true);
        //keyTrigger.SetActive(true);
        fakePumpkin.SetActive(false);
        brokenPumpkin.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        sphereObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        sphereObject.SetActive(false);
    }
}
