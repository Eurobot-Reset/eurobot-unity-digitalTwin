using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableStateHandler : MonoBehaviour
{
    public static string weathervaneStatus;
    public static bool[] windsocksStatus;
    
    void Start()
    {
        windsocksStatus = new bool[4];
    }

    void Update()
    {
        //logValues();
    }

    void logValues()
    {
        string message = "Area: ";
        message += weathervaneStatus + "\n";
        message += "Windsocks B1 B2 Y1 Y2: ";
        foreach (var item in windsocksStatus)
        {
            if(item)
                message += "True ";
            else
                message += "False ";
        }
        Debug.Log(message);
    }
}
