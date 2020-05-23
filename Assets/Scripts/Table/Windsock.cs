using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windsock : MonoBehaviour
{
    Rigidbody windsockRB;

    // Start is called before the first frame update
    void Start()
    {
        windsockRB = GetComponent<Rigidbody>();
        windsockRB.centerOfMass = new Vector3(0.0f, 0.0f, 0.0f);
        windsockRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        windsockRB.constraints |= RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        windsockRB.constraints |= RigidbodyConstraints.FreezePositionX;
        //Debug.Log((string)gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch ((string)gameObject.name)
        {
            case "b1":
                tableStateHandler.windsocksStatus[0] = checkAngle();
                //Kostil': huli oni vse krutyatsa?)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, 0);
                break;
            case "b2":
                tableStateHandler.windsocksStatus[1] = checkAngle();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, 0);
                break;
            case "y1":
                tableStateHandler.windsocksStatus[2] = checkAngle();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, 0);
                break;
            case "y2":
                tableStateHandler.windsocksStatus[3] = checkAngle();
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, 0);
                break;
            default:
                break;
        }
        
    }

    bool checkAngle(){
        if (transform.eulerAngles.x > -10.0f && transform.eulerAngles.x < 10.0f) return true;
        else return false;
    }
}
