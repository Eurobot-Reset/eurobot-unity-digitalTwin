using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_cup_detection : MonoBehaviour
{
    public List<GameObject> CupsInside;
    public int CupsInsideCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GreenCups")
        {
            CupsInsideCount += 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GreenCups")
        {
            CupsInsideCount -= 1;
        }
    }
}
