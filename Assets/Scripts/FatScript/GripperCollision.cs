using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripperCollision : MonoBehaviour
{
    //private int numberFingers = 5;
    //public string finger;
    //public int finger;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cup");
        if ((other.gameObject.tag == "GreenCups") || (other.gameObject.tag == "RedCups"))
        {           
            this.transform.parent.transform.parent.transform.parent.GetComponent<Rotation>().GripperTake(other, this.name);
        }
    }

}
