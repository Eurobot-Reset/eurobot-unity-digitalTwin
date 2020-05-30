using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLightHouse : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " );
        if (other.gameObject.tag == "Untagged")
        {
            LightHouseScript.activate_light_house = true;
        }

    }
}
