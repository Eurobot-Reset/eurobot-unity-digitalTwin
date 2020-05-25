using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_G2 : MonoBehaviour
{
    // Start is called before the first frame update
    public string Racer_color;
    public string Fatboy_color;


    void Start()
    {
       Racer_color = PlayerPrefs.GetString("Racer_color");
       Fatboy_color = PlayerPrefs.GetString("Fatboy_color");
    }
}

