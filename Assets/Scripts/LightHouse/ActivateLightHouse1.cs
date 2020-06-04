using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLightHouse1 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " );
        if (other.gameObject.tag == "Untagged")
        {
            LightHouseScript1.activate_light_house = true;
        }

    }
}
