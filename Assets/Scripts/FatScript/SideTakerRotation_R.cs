using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTakerRotation_R : MonoBehaviour
{
    public bool SideTakerOpen_2 = false;
    public bool SideTakerClose_2 = false;
    public bool BasePosition_2 = false; 
    public bool From_180_to_360_R = false;
    public bool Direction_R = false;
    public float angle_R;
    public bool From_0_to_180_R = false;
    public bool Direction_2_R = false;
    public float angle_2_R;
    public float angleSpeed;
    //private float left_board = 100;
    //private float right_board = 200;
    private GameObject AxisFatRotation2;
    private GameObject RotateTaker2;




    private GameObject CupsFree;
    private GameObject Cup = null;
    private Vector3 _followOffsetPosition;
    private Quaternion _followOffsetRotation;
    volatile private GameObject cup;
    private GameObject cups;

    public bool Action_take = false;
    public bool release = false;
    public bool Cup_taken = false;


        void Start()
    {

        angleSpeed = 80f;
        CupsFree = GameObject.Find("Cups");
        
        BasePosition_2 = true; 
        AxisFatRotation2 = GameObject.Find("AxisFatRotation2");
        RotateTaker2 = GameObject.Find("cups_taker_R");
    }

    void Update()
    {

        if ((BasePosition_2) && (RotateTaker2.transform.eulerAngles.y > 230f) || (RotateTaker2.transform.eulerAngles.y < 225f))
        {
                
                RotateTaker2.transform.RotateAround(AxisFatRotation2.transform.position, AxisFatRotation2.transform.up, -angleSpeed * Time.deltaTime);

                if ((RotateTaker2.transform.eulerAngles.y < 230f) && (RotateTaker2.transform.eulerAngles.y > 225f))
                {
                    BasePosition_2 = false;
                }
        }

    if ((SideTakerOpen_2) && (!(SideTakerClose_2)))
       {
            if ((RotateTaker2.transform.eulerAngles.y > 180f) && (RotateTaker2.transform.eulerAngles.y <= 360) && (!Direction_R) && (!Direction_2_R) && (SideTakerOpen_2))
            {
               From_180_to_360_R = true;
               Direction_R = true;
               angle_R = RotateTaker2.transform.eulerAngles.y - 180f;
               
            }

            else if ((RotateTaker2.transform.eulerAngles.y > angle_R) && (From_180_to_360_R))
            {

                RotateTaker2.transform.RotateAround(AxisFatRotation2.transform.position, AxisFatRotation2.transform.up, -angleSpeed * Time.deltaTime);
                release = true;
            }
            else if ((From_180_to_360_R) && (Direction_R))
            {

                From_180_to_360_R = false;
                Direction_R = false;  
                SideTakerOpen_2 = false;

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
            else if((RotateTaker2.transform.eulerAngles.y >= 0) && (RotateTaker2.transform.eulerAngles.y < 179) && (!Direction_R) && (!Direction_2_R) && (SideTakerOpen_2)) 
            {
               From_0_to_180_R = true;
               Direction_2_R = true;
               angle_2_R = RotateTaker2.transform.eulerAngles.y + 180;
            }

            else if ((RotateTaker2.transform.eulerAngles.y < (angle_2_R)) && (From_0_to_180_R))
            {
                RotateTaker2.transform.RotateAround(AxisFatRotation2.transform.position, AxisFatRotation2.transform.up, angleSpeed * Time.deltaTime);
                release = true;
            }
            else if ((From_0_to_180_R) && (Direction_2_R))
            {
                From_0_to_180_R = false;
                Direction_2_R = false;
                SideTakerOpen_2 = false;  

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

       else if ((SideTakerClose_2) && (!SideTakerOpen_2))
       {
            if ((RotateTaker2.transform.eulerAngles.y > 180f) && (RotateTaker2.transform.eulerAngles.y <= 360) && (!Direction_R) && (!Direction_2_R) && (SideTakerClose_2))
            {
               From_180_to_360_R = true;
               Direction_R = true;
               angle_R = RotateTaker2.transform.eulerAngles.y - 180f;
            }

            else if ((RotateTaker2.transform.eulerAngles.y > angle_R) && (From_180_to_360_R))
            {
          
                RotateTaker2.transform.RotateAround(AxisFatRotation2.transform.position, AxisFatRotation2.transform.up, -angleSpeed * Time.deltaTime);
                
                if (RotateTaker2.transform.eulerAngles.y < angle_R)
                {
                    Action_take = true;
                    From_180_to_360_R = false;
                    Direction_R = false;  
                    SideTakerClose_2 = false;
                }
            }


            // Close door if angle [0:180]
            else if((RotateTaker2.transform.eulerAngles.y >= 0) && (RotateTaker2.transform.eulerAngles.y < 179) && (!Direction_R) && (!Direction_2_R) && (SideTakerClose_2)) 
            {
               From_0_to_180_R = true;
               Direction_2_R = true;
               angle_2_R = RotateTaker2.transform.eulerAngles.y + 180;
            }

            else if ((RotateTaker2.transform.eulerAngles.y < (angle_2_R)) && (From_0_to_180_R))
            {
                RotateTaker2.transform.RotateAround(AxisFatRotation2.transform.position, AxisFatRotation2.transform.up, angleSpeed * Time.deltaTime);
            }
            else if ((From_0_to_180_R) && (Direction_2_R))
            {
                Action_take = true;
                From_0_to_180_R = false;
                Direction_2_R = false;
                SideTakerClose_2 = false; 
                Debug.Log("false_close_R");
                Debug.Log("6666");
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
