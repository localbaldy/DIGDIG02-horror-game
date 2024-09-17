using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    public int lightMode; //Så vi kan bestämma vilken anim som ska spelas slumpmässigt
    public GameObject flameLight; //Ref till vår lampa i facklan

    void Update()
    {
        if (lightMode == 0) //Om det inte finns ett mode, starta coroutinen
        {
            StartCoroutine(AnimateLight());
        }
    }

    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4); //Scriptet väljer slumpmässigt ljust och vilken anim som ska spelas
        if (lightMode == 1)
        {
            flameLight.GetComponent<Animation>().Play("Torch_Light"); //Namnet på din anim
        }
        if (lightMode == 2)
        {
            flameLight.GetComponent<Animation>().Play("Torch_Light2"); //Namnet på din anim
        }
        if (lightMode == 3)
        {
            flameLight.GetComponent<Animation>().Play("Torch_Light3"); //Namnet på din anim
        }
        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }
}

