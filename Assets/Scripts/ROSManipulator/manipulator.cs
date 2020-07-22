using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using System;

public class manipulator : MonoBehaviour
{
    public GameObject Suck11;
    public GameObject Suck12;
    public GameObject Suck21;
    public GameObject Suck22;
    public GameObject Suck31;
    public GameObject Suck32;
    public GameObject Gripper1;
    public GameObject Gripper2;
    public GameObject Gripper3;

    public float velocity = 4.0f;
    public float y_gripper_down = 6.4f;
    public float y_gripper_up = 9.0f;

    public CustomMsgSubscriber RacerMsgSubscriber;
    public string[] data;
    public string data_str;
    public string[] data_arr;
    public int data_arr_len = 0;
    int i;
    //public string hex_str;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Suck11.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers");
        Suck12.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers");
        Suck21.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (2)");
        Suck22.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (2)");
        Suck31.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (1)");
        Suck32.GetComponent<Suck>().Gripper = GameObject.Find("VacuumGrippers (1)");
	Gripper1 = GameObject.Find("VacuumGrippers");
	Gripper2 = GameObject.Find("VacuumGrippers (2)");
	Gripper3 = GameObject.Find("VacuumGrippers (1)");
    }

    // Update is called once per frame
    void Update()
    {
	data_arr = RacerMsgSubscriber.data_arr;
	for (i = data_arr_len; i < data_arr.Length; i++)
	{
	    data_str = data_arr[i];
	    data = data_str.Split(null);

	    if (data.Length > 1)
	    {
		if (data[1] == protocol.VALVE_1_LEFT_OPEN.ToString())
	        {
	            Suck11.GetComponent<Suck>().remote_collect = true;
	        }
	        if (data[1] == protocol.VALVE_1_RIGHT_OPEN.ToString())
	        {
	            Suck12.GetComponent<Suck>().remote_collect = true;
	        }
	        if (data[1] == protocol.VALVE_2_LEFT_OPEN.ToString())
	        {
	            Suck21.GetComponent<Suck>().remote_collect = true;
	        }
	        if (data[1] == protocol.VALVE_2_RIGHT_OPEN.ToString())
	        {
	            Suck22.GetComponent<Suck>().remote_collect = true;
	        }
	        if (data[1] == protocol.VALVE_3_LEFT_OPEN.ToString())
	        {
	            Suck31.GetComponent<Suck>().remote_collect = true;
	        }
	        if (data[1] == protocol.VALVE_3_RIGHT_OPEN.ToString())
	        {
	            Suck32.GetComponent<Suck>().remote_collect = true;
	        }
	        if (data[1] == protocol.VALVE_1_LEFT_CLOSE.ToString())
	        {
	            Suck11.GetComponent<Suck>().remote_release = true;
	        }
	        if (data[1] == protocol.VALVE_1_RIGHT_CLOSE.ToString())
	        {
	            Suck12.GetComponent<Suck>().remote_release = true;
	        }
	        if (data[1] == protocol.VALVE_2_LEFT_CLOSE.ToString())
	        {
	            Suck21.GetComponent<Suck>().remote_release = true;
	        }
	        if (data[1] == protocol.VALVE_2_RIGHT_CLOSE.ToString())
	        {
	            Suck22.GetComponent<Suck>().remote_release = true;
	        }
	        if (data[1] == protocol.VALVE_3_LEFT_CLOSE.ToString())
	        {
	            Suck31.GetComponent<Suck>().remote_release = true;
	        }
	        if (data[1] == protocol.VALVE_3_RIGHT_CLOSE.ToString())
	        {
	            Suck32.GetComponent<Suck>().remote_release = true;
	        }


	        if (data[1] == protocol.GRIPPER_DOWN.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_1.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_down = true;
			
		    }
	        }
	        if (data[1] == protocol.GRIPPER_DOWN.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_2.ToString())
		    {
			Gripper2.GetComponent<Gripper>().go_down = true;
			
		    }
	        }
	        if (data[1] == protocol.GRIPPER_DOWN.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_12.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_down = true;
			Gripper2.GetComponent<Gripper>().go_down = true;
		    }
	        }
	        if (data[1] == protocol.GRIPPER_DOWN.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_3.ToString())
		    {
			Gripper3.GetComponent<Gripper>().go_down = true;
			
		    }
	        }
	        if (data[1] == protocol.GRIPPER_DOWN.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_13.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_down = true;
			Gripper3.GetComponent<Gripper>().go_down = true;
		    }
	        }
	        if (data[1] == protocol.GRIPPER_DOWN.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_23.ToString())
		    {
			Gripper2.GetComponent<Gripper>().go_down = true;
			Gripper3.GetComponent<Gripper>().go_down = true;
		    }
	        }
	        if (data[1] == protocol.GRIPPER_DOWN.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_123.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_down = true;
			Gripper2.GetComponent<Gripper>().go_down = true;
			Gripper3.GetComponent<Gripper>().go_down = true;
		    }
	        }

	        if (data[1] == protocol.GRIPPER_HIGH_UP.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_1.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_up = true;
			
		    }
	        }
	        if (data[1] == protocol.GRIPPER_HIGH_UP.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_2.ToString())
		    {
			Gripper2.GetComponent<Gripper>().go_up = true;
			
		    }
	        }
	        if (data[1] == protocol.GRIPPER_HIGH_UP.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_12.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_up = true;
			Gripper2.GetComponent<Gripper>().go_up = true;
		    }
	        }
	        if (data[1] == protocol.GRIPPER_HIGH_UP.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_3.ToString())
		    {
			Gripper3.GetComponent<Gripper>().go_up = true;
			
		    }
	        }
	        if (data[1] == protocol.GRIPPER_HIGH_UP.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_13.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_up = true;
			Gripper3.GetComponent<Gripper>().go_up = true;
		    }
	        }
	        if (data[1] == protocol.GRIPPER_HIGH_UP.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_23.ToString())
		    {
			Gripper2.GetComponent<Gripper>().go_up = true;
			Gripper3.GetComponent<Gripper>().go_up = true;
		    }
	        }
	        if (data[1] == protocol.GRIPPER_HIGH_UP.ToString())
	        {
	            if (data[2] == protocol.GRIPPER_123.ToString())
		    {
			Gripper1.GetComponent<Gripper>().go_up = true;
			Gripper2.GetComponent<Gripper>().go_up = true;
			Gripper3.GetComponent<Gripper>().go_up = true;
		    }
	        }

	    }
	}
	data_arr_len = data_arr.Length;
    }
}
