using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationCupsTaker : MonoBehaviour
{
    private float initRotationalYR = 70;
    private float initRotationalYL = 50;
    private Vector3 actuatorOpen;
    private Vector3 actuatorClose;
    volatile private bool isCup = false;

    volatile public GameObject shellActuator;
    public char sideActuator;
    volatile private GameObject cup;
    private GameObject cups;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        shellActuator = this.transform.parent.gameObject;
        sideActuator = shellActuator.name[shellActuator.name.Length-1];
        //animator = shellActuator.GetComponent<Animator>();
        //Debug.Log(sideActuator);
        if (sideActuator=='R')
        {
            actuatorOpen = new Vector3(0, initRotationalYR, 0);
            actuatorClose = new Vector3(0, initRotationalYR + 180, 0);
        }
        else
        {
            actuatorOpen = new Vector3(0, initRotationalYL, 0);
            actuatorClose = new Vector3(0, initRotationalYL + 180, 0);
        }
        
        shellActuator.transform.localEulerAngles = actuatorOpen;
        cups = GameObject.Find("Cups");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P)&&(sideActuator=='R'))
        {            
            Gripper();
        }
        if (Input.GetKey(KeyCode.Y) && (sideActuator == 'L'))
        {
            Gripper();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cup take");
        if ((other.gameObject.tag == "GreenCups") || (other.gameObject.tag == "RedCups") && (!isCup))
        {
            cup = other.gameObject;
            cup.transform.SetParent(shellActuator.transform);
            isCup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("cup put");
        if ((other.gameObject.tag == "GreenCups") || (other.gameObject.tag == "RedCups") && (isCup))
        {            
            cup.transform.SetParent(cups.transform);
            cup = null;
            isCup = false;
        }
    }    

    public void Gripper()
    {
        Debug.Log("Gripper");

        if (isCup)
        {   
            if (cup.GetComponent<Rigidbody>().isKinematic == false)
            {
                cup.GetComponent<Rigidbody>().isKinematic = true;
                cup.transform.localPosition = new Vector3(0, cup.transform.localPosition.y, 0);
                shellActuator.transform.localEulerAngles = actuatorClose;
                //animator.Play("CupsTakerRClose");
            }
            else
            {
                cup.GetComponent<Rigidbody>().isKinematic = false;
                shellActuator.transform.localEulerAngles = actuatorOpen;
                //animator.Play("CupsTakerROpen");
            }
            
        }

    }
}
