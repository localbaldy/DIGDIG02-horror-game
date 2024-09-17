using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool IsFiring = false;
    //public float TargetDistance;
    //public int DamageAmount = 5;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //&& GlobalAmmo.ammoCount >= 1)
        {
            if (IsFiring == false)
            {
                //GlobalAmmo.ammoCount -= 1;
                StartCoroutine(FiringPistol());
            }
        }
    }
    IEnumerator FiringPistol()
    {
        RaycastHit shot;
        IsFiring = true;
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            TargetDistance = shot.distance;
            shot.transform.SendMessage("DamageEnemy", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }*/
        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        MuzzleFlash.SetActive(false);
        IsFiring = false;
    }
}
