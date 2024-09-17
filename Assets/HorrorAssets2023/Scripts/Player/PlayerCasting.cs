using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float toTarget; //Hur långt vi är ifrån något med en collider
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            toTarget = Hit.distance;
            DistanceFromTarget = toTarget; //En raycast som räcknar hur nära vi är
        }
    }
}
