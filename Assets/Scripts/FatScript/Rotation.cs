using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using System;

public class Rotation : MonoBehaviour
{

    public float angleSpeed = 80f;
    public float velocity = 10f;

    private float highBoard = 10f;
    private float lowBoard = 0f;
    private float horizontalBoard = 355f; //355
    private float verticalBoard = 275f; //275
    private int numberFingers = 5;
    private bool[] isCup;
    private int numberInt;
    private GameObject[] cups;
    private float[] anglesCapture;

    private GameObject axis;
    private GameObject gripper;
    private GameObject Maw;
    private GameObject Jaw;
    private GameObject Jaw1;
    private GameObject Jaw2;
    private GameObject Jaw3;
    private GameObject Jaw4;
    private GameObject Jaw5;
    volatile private GameObject cup;
    volatile private GameObject jawSwivelGripper;
    
    // New
    public CustomMsgSubscriber RacerMsgSubscriber;
    public string[] data;
    public string data_str;
    public string[] data_arr;
    public int data_arr_len = 0;
    int i; 
    int i2; 
    public GameObject LiftingMechanism;

    // For rotate side taker
    public bool SideTakerOpen_1 = false;
    public bool SideTakerOpen_2 = false;
    public bool SideTakerClose_1 = false;
    public bool SideTakerClose_2 = false;
    //private float left_board = 100;
    //private float right_board = 200;
    private GameObject AxisFatRotation1;
    private GameObject RotateTaker1;
    private GameObject AxisFatRotation2;
    private GameObject RotateTaker2;
 
    // Start is called before the first frame update
    void Start()
    {

        AxisFatRotation1 = GameObject.Find("AxisFatRotation1");
        AxisFatRotation2 = GameObject.Find("AxisFatRotation2");
        RotateTaker1 = GameObject.Find("CupTakerFat2");
        RotateTaker2 = GameObject.Find("CupTakerFat1");       
        Jaw1 = GameObject.Find("Rotating Jaw 1");
        Jaw2 = GameObject.Find("Rotating Jaw 2");
        Jaw3 = GameObject.Find("Rotating Jaw 3");
        Jaw4 = GameObject.Find("Rotating Jaw 4");
        Jaw5 = GameObject.Find("Rotating Jaw 5");
        LiftingMechanism = GameObject.Find("Lifting Mechanism - Nema 17 v2");
        axis = GameObject.Find("Axis");
        gripper = GameObject.Find("RotatingJaws");

        isCup = new bool[numberFingers];
        cups = new GameObject[numberFingers];
        anglesCapture = new float[numberFingers];
        for (int i=0;i< numberFingers; i++)
        {
            isCup[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.N) && (transform.position.y < highBoard))
        {            
            transform.position += transform.up * Time.deltaTime * velocity;
        }
        if (Input.GetKey(KeyCode.M) && (transform.position.y > lowBoard))
        {
            transform.position += transform.up * Time.deltaTime * -velocity;
            CupPut();
        }
        //Comma - ","
        if (Input.GetKey(KeyCode.Comma) && (gripper.transform.eulerAngles.x < horizontalBoard))
        {
            gripper.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed * Time.deltaTime);
            CupPut();
        }
        //Period - dot "."
        if (Input.GetKey(KeyCode.Period) && (gripper.transform.eulerAngles.x > verticalBoard))
        {           
            gripper.transform.RotateAround(axis.transform.position, axis.transform.right, angleSpeed * Time.deltaTime);            

        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            FatboyFlag.fatboy_flag = true;
        }

        //  Commands for simulation
        data_arr = RacerMsgSubscriber.data_arr;
        for (i = data_arr_len; i < data_arr.Length; i++)
            {
                data_str = data_arr[i];
                data = data_str.Split(null);

                if (data.Length > 1)
                {
                    if (data[1] == protocol.ARM_DOWN.ToString())
                    {
                        LiftingMechanism.GetComponent<ArmLift>().go_arm_down = true;
                        CupPutSingle();
                    }

                    if (data[1] == protocol.ARM_MEDIUM.ToString())
                    {                                               
                        LiftingMechanism.GetComponent<ArmLift>().go_arm_middle = true;   
                    }

                    if (data[1] == protocol.ARM_UP.ToString())
                    {
                        LiftingMechanism.GetComponent<ArmLift>().go_arm_up = true;
                    }

                    if (data[1] == protocol.PAWS_OPEN.ToString())
                    {                          
                        Jaw1.GetComponent<SingleGripperRotation>().Jaw1_open = true;
                        Jaw2.GetComponent<SingleGripperRotation>().Jaw2_open = true;
                        Jaw3.GetComponent<SingleGripperRotation>().Jaw3_open = true;
                        Jaw4.GetComponent<SingleGripperRotation>().Jaw4_open = true;
                        Jaw5.GetComponent<SingleGripperRotation>().Jaw5_open = true;
                    }

                    if (data[1] == protocol.PAWS_CLOSE.ToString())
                    {                                                 
                        Jaw1.GetComponent<SingleGripperRotation>().Jaw1_close = true;
                        Jaw2.GetComponent<SingleGripperRotation>().Jaw2_close = true;
                        Jaw3.GetComponent<SingleGripperRotation>().Jaw3_close = true;
                        Jaw4.GetComponent<SingleGripperRotation>().Jaw4_close = true;
                        Jaw5.GetComponent<SingleGripperRotation>().Jaw5_close = true;      
                    }

                    if (data[1] == protocol.PAW1_CLOSE.ToString())
                    {                          
                        Jaw1.GetComponent<SingleGripperRotation>().Jaw1_close = true;
                    }

                    if (data[1] == protocol.PAW1_OPEN.ToString())
                    {                          
                        Jaw1.GetComponent<SingleGripperRotation>().Jaw1_open = true;
                    }

                    if (data[1] == protocol.PAW2_CLOSE.ToString())
                    {                          
                        Jaw2.GetComponent<SingleGripperRotation>().Jaw2_close = true;
                    }

                    if (data[1] == protocol.PAW2_OPEN.ToString())
                    {                          
                        Jaw2.GetComponent<SingleGripperRotation>().Jaw2_open = true;
                    }
                    if (data[1] == protocol.PAW3_CLOSE.ToString())
                    {                          
                        Jaw3.GetComponent<SingleGripperRotation>().Jaw3_close = true;
                    }

                    if (data[1] == protocol.PAW3_OPEN.ToString())
                    {                          
                        Jaw3.GetComponent<SingleGripperRotation>().Jaw3_open = true;
                    }

                    if (data[1] == protocol.PAW4_CLOSE.ToString())
                    {                          
                        Jaw4.GetComponent<SingleGripperRotation>().Jaw4_close = true;
                    }

                    if (data[1] == protocol.PAW4_OPEN.ToString())
                    {                          
                        Jaw4.GetComponent<SingleGripperRotation>().Jaw4_open = true;
                    }

                    if (data[1] == protocol.PAW5_CLOSE.ToString())
                    {                          
                        Jaw5.GetComponent<SingleGripperRotation>().Jaw5_close = true;
                    }

                    if (data[1] == protocol.PAW5_OPEN.ToString())
                    {                          
                        Jaw5.GetComponent<SingleGripperRotation>().Jaw5_open = true;
                    }

                    if (data[1] == protocol.DOOR1_OPEN_X.ToString())
                    {
                        RotateTaker1.GetComponent<SideTakerRotation_L>().SideTakerOpen_1 = true;
                        Debug.Log("True");
                    }

                    if (data[1] == protocol.DOOR2_OPEN_X.ToString())
                    {
                        RotateTaker2.GetComponent<SideTakerRotation_R>().SideTakerOpen_2 = true;
                    }

                    if (data[1] == protocol.DOOR1_CLOSE.ToString())
                    {                          
                        RotateTaker1.GetComponent<SideTakerRotation_L>().SideTakerClose_1 = true;
                    }

                    if (data[1] == protocol.DOOR2_CLOSE.ToString())
                    {                                                
                        RotateTaker2.GetComponent<SideTakerRotation_R>().SideTakerClose_2 = true;        
                    }
                }
                
            }
            data_arr_len = data_arr.Length;

    }



// Triggers for game
    public void GripperTake(Collider gripperCollider, string nameObject)
    {

        nameObject = nameObject[nameObject.Length - 1].ToString();
        numberInt = int.Parse(nameObject) - 1;
        //I condiion - gripper doesn't have cup, II condition - gripper looks like close
        if ((!isCup[numberInt])&&(Jaw1.transform.eulerAngles.x < 350 - 10))
        {
            jawSwivelGripper = GameObject.Find("Jaw Swivel Gripper " + nameObject);
            cup = gripperCollider.gameObject;
            cup.transform.SetParent(jawSwivelGripper.transform);
            cup.GetComponent<Rigidbody>().isKinematic = true;
            isCup[numberInt] = true;
            cups[numberInt] = cup;
            anglesCapture[numberInt] = Jaw1.transform.eulerAngles.x;
        }
        
    }

    public void CupPut()
    {
        for (int i = 0; i < numberFingers; i++)
        {                 
            if ((anglesCapture[i] < gripper.transform.eulerAngles.x)&&(anglesCapture[i] > verticalBoard + 5))
            {
                cups[i].GetComponent<Rigidbody>().isKinematic = false;
                cups[i].transform.SetParent(null);
                cups[i] = null;
                isCup[i] = false;
                anglesCapture[i] = 0;
            }
        }
    }


// Triggers for simulation
        public void CupPutSingle()
    {
        for (int i = 0; i < numberFingers; i++)
        {   
            Jaw = GameObject.Find("Rotating Jaw " + (i+1));
            
            if ((anglesCapture[i] < Jaw.transform.eulerAngles.x)&&(anglesCapture[i] > 280))
            {
                Debug.Log("Fall");
                cups[i].GetComponent<Rigidbody>().isKinematic = false;
                cups[i].transform.SetParent(null);
                cups[i] = null;
                isCup[i] = false;
                anglesCapture[i] = 0;
            }
        }
    }

        public void GripperTakeSingle(Collider gripperCollider, string nameObject)
    {
        nameObject = nameObject[nameObject.Length - 1].ToString();
        numberInt = int.Parse(nameObject) - 1;
       
        for (int i2 = 0; i2 < numberFingers; i2++)
        {   
            Maw = GameObject.Find("Rotating Jaw " + (i2+1));
            
                if ((!isCup[numberInt])&&(Maw.transform.eulerAngles.x < 350 - 10))
                {

                    jawSwivelGripper = GameObject.Find("Jaw Swivel Gripper " + nameObject);
                    cup = gripperCollider.gameObject;
                    cup.transform.SetParent(jawSwivelGripper.transform);
                    cup.GetComponent<Rigidbody>().isKinematic = true;
                    isCup[numberInt] = true;
                    cups[numberInt] = cup;
                    anglesCapture[numberInt] = Maw.transform.eulerAngles.x;
                    i2 = 5;
                }
        }
    }
}
