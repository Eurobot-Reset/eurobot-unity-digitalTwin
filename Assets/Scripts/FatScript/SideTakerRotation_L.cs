using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTakerRotation_L : MonoBehaviour
{

    public bool SideTakerOpen_1 = false;
    public bool SideTakerClose_1 = false;
    public bool BasePosition = false;
    public bool From_180_to_360 = false;
    public bool Direction = false;
    public float angle = 0;
    public bool From_0_to_180 = false;
    public bool Direction_2 = false;
    public float angle_2 = 0;
    public float angleSpeed;
    //private float left_board = 250;
    //private float right_board = 40;
    private GameObject AxisFatRotation1;
    private GameObject RotateTaker1;

    // colission
    private GameObject CupsFree;
    private GameObject Cup = null;
    private Vector3 _followOffsetPosition;
    private Quaternion _followOffsetRotation;
    //volatile public GameObject shellActuator;
    //public char sideActuator;
    volatile private GameObject cup;
    private GameObject cups;

    public bool Action_take = false;
    public bool release = false;
    public bool Cup_taken = false;

        void Start()
    {
        angleSpeed = 80f;

        CupsFree = GameObject.Find("Cups");

        BasePosition = true;       
        AxisFatRotation1 = GameObject.Find("AxisFatRotation1");
        RotateTaker1 = GameObject.Find("cups_taker_L");
    }

    void Update()
    {

       if ((BasePosition) && (RotateTaker1.transform.eulerAngles.y < 320))
        {


                RotateTaker1.transform.RotateAround(AxisFatRotation1.transform.position, AxisFatRotation1.transform.up, -angleSpeed * Time.deltaTime);
                

                if ((RotateTaker1.transform.eulerAngles.y > 135f) && (RotateTaker1.transform.eulerAngles.y < 139f))
                {
                    BasePosition = false;
                }
        }


        


        if ((SideTakerOpen_1) && (!(SideTakerClose_1)))
       {
            if ((RotateTaker1.transform.eulerAngles.y > 180f) && (RotateTaker1.transform.eulerAngles.y <= 360) && (!Direction) && (!Direction_2) && (SideTakerOpen_1))
            {
               From_180_to_360 = true;
               Direction = true;
               angle = RotateTaker1.transform.eulerAngles.y - 180f;
               //Debug.Log("True");
            }

            else if ((RotateTaker1.transform.eulerAngles.y > angle) && (From_180_to_360))
            {
                RotateTaker1.transform.RotateAround(AxisFatRotation1.transform.position, AxisFatRotation1.transform.up, -angleSpeed * Time.deltaTime);
                release = true;
            }
            else if ((From_180_to_360) && (Direction))
            {
                From_180_to_360 = false;
                Direction = false;  
                SideTakerOpen_1 = false;
                
                    if ((release) && (Cup != null))
                    {
                        Cup.transform.parent = CupsFree.transform;
                        Cup.GetComponent<Rigidbody>().useGravity = true;
                        Cup = null;
                        Cup_taken = false;
                        release = false;
                    }    
            }

            // Open door if angle [0:180]
            else if((RotateTaker1.transform.eulerAngles.y >= 0) && (RotateTaker1.transform.eulerAngles.y < 179) && (!Direction) && (!Direction_2) && (SideTakerOpen_1)) 
            {
               From_0_to_180 = true;
               Direction_2 = true;
               angle_2 = RotateTaker1.transform.eulerAngles.y + 180;
            }

            else if ((RotateTaker1.transform.eulerAngles.y < (angle_2)) && (From_0_to_180))
            {
                RotateTaker1.transform.RotateAround(AxisFatRotation1.transform.position, AxisFatRotation1.transform.up, angleSpeed * Time.deltaTime);
                release = true;
            }
            else if ((From_0_to_180) && (Direction_2))
            {
                From_0_to_180 = false;
                Direction_2 = false;
                SideTakerOpen_1 = false;  

                if ((release) && (Cup != null))
                    {
                        Cup.transform.parent = CupsFree.transform;
                        Cup.GetComponent<Rigidbody>().useGravity = true;
                        Cup = null;
                        Cup_taken = false;
                        release = false;
                    }
            }
       }







       if ((SideTakerClose_1) && (!SideTakerOpen_1))
        {
            if ((RotateTaker1.transform.eulerAngles.y > 180f) && (RotateTaker1.transform.eulerAngles.y <= 360) && (!Direction) && (!Direction_2) && (SideTakerClose_1))
            {
               From_180_to_360 = true;
               Direction = true;
               angle = RotateTaker1.transform.eulerAngles.y - 180f;
            }

            else if ((RotateTaker1.transform.eulerAngles.y > angle) && (From_180_to_360))
            {
                RotateTaker1.transform.RotateAround(AxisFatRotation1.transform.position, AxisFatRotation1.transform.up, -angleSpeed * Time.deltaTime);
            }
            else if ((From_180_to_360) && (Direction))
            {
                Action_take = true;
                From_180_to_360 = false;
                Direction = false;  
                SideTakerClose_1 = false;
            }




            // Close door if angle [0:180]
            else if((RotateTaker1.transform.eulerAngles.y >= 0) && (RotateTaker1.transform.eulerAngles.y < 179) && (!Direction) && (!Direction_2) && (SideTakerClose_1)) 
            {
               From_0_to_180 = true;
               Direction_2 = true;
               angle_2 = RotateTaker1.transform.eulerAngles.y + 180;
            }

            else if ((RotateTaker1.transform.eulerAngles.y < (angle_2)) && (From_0_to_180))
            {
                RotateTaker1.transform.RotateAround(AxisFatRotation1.transform.position, AxisFatRotation1.transform.up, angleSpeed * Time.deltaTime);
            }
            else if ((From_0_to_180) && (Direction_2))
            {
                Action_take = true;
                From_0_to_180 = false;
                Direction_2 = false;
                SideTakerClose_1 = false; 
            }
       }


       if (Cup != null)
       {
           Cup.transform.localPosition = _followOffsetPosition;
           Cup.transform.rotation = transform.rotation * _followOffsetRotation;
       }
    }

    

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "GreenCups") || (other.gameObject.tag == "RedCups"))
        {
            if (Action_take == true)
            {
                Cup = other.gameObject;
                if (!Cup_taken)
                {
                    Cup.transform.parent = transform;
                    _followOffsetPosition = Cup.transform.localPosition;
                    _followOffsetRotation = Cup.transform.rotation * Quaternion.Inverse(transform.rotation);
                    Cup.GetComponent<Rigidbody>().useGravity = false;
                    Cup_taken = true;
                }
                Action_take = false;
            }
        }
    }

}


