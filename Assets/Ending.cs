using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject fadeScreen;
    public GameObject textBox;
    //public AudioSource line01;
    //public AudioSource line02;

    void Start()
    {
        thePlayer.GetComponent<PlayerMove>().enabled = false;

    }

    public void End()
    {
        textBox.GetComponent<Text>().text = "I made it..";
        thePlayer.GetComponent<PlayerMove>().enabled = true;
    }


}
