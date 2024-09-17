using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float toTarget; //Hur l�ngt vi �r ifr�n n�got med en collider
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            toTarget = Hit.distance;
            DistanceFromTarget = toTarget; //En raycast som r�cknar hur n�ra vi �r
        }
    }
}
