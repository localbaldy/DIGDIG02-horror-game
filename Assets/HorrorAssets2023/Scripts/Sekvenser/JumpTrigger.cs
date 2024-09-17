using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource doorBang;
    public AudioSource doorJumpMusic;
    public GameObject theEnemy;
    public GameObject theDoor;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        theDoor.GetComponent<Animation>().Play("SecondDoorOpen");
        doorBang.Play();
        theEnemy.SetActive(true);
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        doorJumpMusic.Play();
    }
}
