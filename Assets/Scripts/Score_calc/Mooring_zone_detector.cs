using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mooring_zone_detector : MonoBehaviour
{
    public int RobotInside = 0;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        RobotInside += 1;
    }

    void OnTriggerExit(Collider other)
    {
        RobotInside -= 1;
    }
}
