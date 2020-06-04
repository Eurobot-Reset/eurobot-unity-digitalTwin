using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;

public class ControlSuck : MonoBehaviour
{
    public GameObject Suck_1_Left;
    public GameObject Suck_1_Right;
    public GameObject Suck_2_Left;
    public GameObject Suck_2_Right;
    public GameObject Suck_3_Left;
    public GameObject Suck_3_Right;
    private GameObject Current_Suck;
    private GameObject Previous_Suck;
    public Material yellow;
    public Material white;
    public CustomMsgSubscriber customMsgSubscriber;
    // Start is called before the first frame update
    void Start()
    {
        Previous_Suck = Suck_1_Right;
        Current_Suck = Suck_1_Left;
        Current_Suck.GetComponent<Renderer>().material = yellow;
        Current_Suck.GetComponent<Suck>().Suck_Is_Active = true;
        Current_Suck.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(customMsgSubscriber.data);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Previous_Suck = Current_Suck;
            if (Current_Suck == Suck_1_Left)
            {
                Current_Suck = Suck_2_Right;
                Current_Suck.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (2)");
            }
            else if (Current_Suck == Suck_2_Right)
            {
                Current_Suck = Suck_2_Left;
                Current_Suck.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (2)");
            }
            else if (Current_Suck == Suck_2_Left)
            {
                Current_Suck = Suck_3_Right;
                Current_Suck.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (1)");
            }
            else if (Current_Suck == Suck_3_Right)
            {
                Current_Suck = Suck_3_Left;
                Current_Suck.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (1)");
            }
            else if (Current_Suck == Suck_3_Left)
            {
                Current_Suck = Suck_1_Right;
                Current_Suck.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers");
            }
            else if (Current_Suck == Suck_1_Right)
            {
                Current_Suck = Suck_1_Left;
                Current_Suck.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers");
            }
            Previous_Suck.GetComponent<Suck>().Suck_Is_Active = false;
            Previous_Suck.GetComponent<Renderer>().material = white;
            Current_Suck.GetComponent<Suck>().Suck_Is_Active = true;
            Current_Suck.GetComponent<Renderer>().material = yellow;
           
        }
    }
}
