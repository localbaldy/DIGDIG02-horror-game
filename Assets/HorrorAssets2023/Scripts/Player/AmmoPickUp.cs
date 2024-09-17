using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public GameObject theAmmo;
    //public GameObject ammoDisplayBox;
    private void OnTriggerEnter(Collider other)
    {
      //ammoDisplayBox.SetActive(true);
      //GlobalAmmo.ammoCount += 12;
      theAmmo.SetActive(false);
    }
}
