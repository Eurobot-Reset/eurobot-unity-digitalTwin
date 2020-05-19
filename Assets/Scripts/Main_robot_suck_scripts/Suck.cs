using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    public GameObject Gripper;
    private GameObject CupsFree;
    private GameObject Cup = null;

    public float velocity = 4.0f;
    public float y_gripper_down = 6.4f;
    public float y_gripper_up = 9.0f;

    private bool go_down = false;
    private bool go_up = false;
    private bool Cup_taken = false;
    public bool Suck_Is_Active = false;

    private Vector3 _followOffsetPosition;
    private Quaternion _followOffsetRotation;
    private string gripper_action = "release";

    // Start is called before the first frame update
    void Start()
    {
        Gripper = GameObject.Find("VacuumGrippers");
        CupsFree = GameObject.Find("Cups");
    }

    // Update is called once per frame
    void Update()
    {
       if ((Input.GetKey(KeyCode.X)) && Suck_Is_Active)
       {
           go_down = true;
           gripper_action = "collect";

       }

       if ((Input.GetKey(KeyCode.C)) && Suck_Is_Active)
       {
           go_down = true;
           gripper_action = "release";

       }

       if (go_down)
       {
           if (Gripper.transform.position.y > y_gripper_down)
           {
               Gripper.transform.position -= transform.up * Time.deltaTime * velocity;
           }
           else
           {
               go_down = false;
               go_up = true;
               if ((gripper_action == "release") && (Cup != null))
               {
                   Cup.transform.parent = CupsFree.transform;
                   Cup = null;
                   Cup_taken = false;

               }
           }
       }

       if (go_up)
       {
           if (Gripper.transform.position.y < y_gripper_up)
           {
               Gripper.transform.position += transform.up * Time.deltaTime * velocity;
           }
           else
           {
               go_up = false;
           } 
       }

       if (Cup != null)
       {
           Cup.transform.localPosition = _followOffsetPosition;
           Cup.transform.rotation = transform.rotation * _followOffsetRotation;
       }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " );
        if ((other.gameObject.tag == "GreenCups") || (other.gameObject.tag == "RedCups"))
        {
            if (gripper_action == "collect")
            {
                Cup = other.gameObject;
                if (!Cup_taken)
                {
                    Cup.transform.parent = transform;
                    _followOffsetPosition = Cup.transform.localPosition;
                    _followOffsetRotation = Cup.transform.rotation * Quaternion.Inverse(transform.rotation);
                    Cup_taken = true;
                }
            }

        }

    }

}
