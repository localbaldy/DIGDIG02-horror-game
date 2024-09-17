using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave01 : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("AutoSave", 2);
    }
}
