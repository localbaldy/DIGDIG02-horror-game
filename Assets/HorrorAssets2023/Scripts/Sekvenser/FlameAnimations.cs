using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    public int lightMode; //S� vi kan best�mma vilken anim som ska spelas slumpm�ssigt
    public GameObject flameLight; //Ref till v�r lampa i facklan

    void Update()
    {
        if (lightMode == 0) //Om det inte finns ett mode, starta coroutinen
        {
            StartCoroutine(AnimateLight());
        }
    }

    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4); //Scriptet v�ljer slumpm�ssigt ljust och vilken anim som ska spelas
        if (lightMode == 1)
        {
            flameLight.GetComponent<Animation>().Play("Torch_Light"); //Namnet p� din anim
        }
        if (lightMode == 2)
        {
            flameLight.GetComponent<Animation>().Play("Torch_Light2"); //Namnet p� din anim
        }
        if (lightMode == 3)
        {
            flameLight.GetComponent<Animation>().Play("Torch_Light3"); //Namnet p� din anim
        }
        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }
}

