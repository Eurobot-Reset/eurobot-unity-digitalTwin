using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_cup_detection : MonoBehaviour
{
    public List<GameObject> CupsInside;
    public int CupsInsideCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "GreenCups")||(other.gameObject.tag == "RedCups"))
        {
            CupsInsideCount += 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "GreenCups") || (other.gameObject.tag == "RedCups"))
        {
            CupsInsideCount -= 1;
        }
    }
}
