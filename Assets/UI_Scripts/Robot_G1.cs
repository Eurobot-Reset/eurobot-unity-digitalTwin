using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_G1 : MonoBehaviour
{
    // Start is called before the first frame update
    public string Robot_name;
    public string Racer_color;
    public string Fatboy_color;


    void Start()
    {
        Robot_name = PlayerPrefs.GetString("Robot");
        if (Robot_name == "Racer")
        {
            Racer_color = PlayerPrefs.GetString("Racer_color");
            Fatboy_color = "None";
        }
        else
        {
            Fatboy_color = PlayerPrefs.GetString("Fatboy_color");
            Racer_color = "None";
        }
            
    }
       
            

}
        


