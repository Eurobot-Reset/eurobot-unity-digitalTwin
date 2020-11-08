
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGripperRotation : MonoBehaviour
{

    public float Uppear_board = 320;
    public float Lower_board = 285;
    public bool Jaw1_open;
    public bool Jaw2_open;
    public bool Jaw3_open;
    public bool Jaw4_open;
    public bool Jaw5_open;
    public bool Jaw1_close;
    public bool Jaw2_close;
    public bool Jaw3_close;
    public bool Jaw4_close;
    public bool Jaw5_close;
    public float angleSpeed;
    private GameObject axis;
    private GameObject Jaw1;
    private GameObject Jaw2;
    private GameObject Jaw3;
    private GameObject Jaw4;
    private GameObject Jaw5;

    


    // Start is called before the first frame update
    void Start()
    {
        Jaw1_open = true;
        angleSpeed = 40f;
        Jaw1 = GameObject.Find("Rotating Jaw 1");
        Jaw2 = GameObject.Find("Rotating Jaw 2");
        Jaw3 = GameObject.Find("Rotating Jaw 3");
        Jaw4 = GameObject.Find("Rotating Jaw 4");
        Jaw5 = GameObject.Find("Rotating Jaw 5");
        axis = GameObject.Find("Axis");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log ("Jaw1: " + Jaw1.transform.eulerAngles.x); 
        if (Jaw1_open)
        {    
           if (Jaw1.transform.eulerAngles.x < Uppear_board)
            {
                Debug.Log ("GGG: " + Jaw1.transform.eulerAngles.x); 
                Jaw1.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed * Time.deltaTime);

            }
           else
            {
               Jaw1_open = false;
	        }
       }

       if ((Jaw1_close) && (!Jaw1_open))
       {
           //Debug.Log ("CLOSE JAW");
           if (Jaw1.transform.eulerAngles.x > Lower_board)
           {
               Debug.Log ("DEBUGG: " + Jaw1.transform.eulerAngles.x); 
               Jaw1.transform.RotateAround(axis.transform.position, axis.transform.right, angleSpeed * Time.deltaTime);
               //Debug.Log ("Angle_close: " + Jaw1.transform.eulerAngles.x); 
               // Debug.Log ("Lower_board: " + lower_board);
           }
           else
           {
               Jaw1_close = false;
           } 
       }




               if (Jaw2_open)
       {
           if (Jaw2.transform.eulerAngles.x < Uppear_board)
            {
                Jaw2.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed * Time.deltaTime);
            }
           else
            {
               Jaw2_open = false;
	        }
       }

       if ((Jaw2_close) && (!Jaw2_open))
       {
           if (Jaw2.transform.eulerAngles.x > Lower_board)
           {
               Jaw2.transform.RotateAround(axis.transform.position, axis.transform.right, angleSpeed * Time.deltaTime);
               // Debug.Log ("Angle_close: " + gripper.transform.eulerAngles.x); 
               // Debug.Log ("Lower_board: " + lower_board);
           }
           else
           {
               Jaw2_close = false;
           } 
       }




        if (Jaw3_open)
       {
           if (Jaw3.transform.eulerAngles.x < Uppear_board)
            {
                Jaw3.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed * Time.deltaTime);
            }
           else
            {
               Jaw3_open = false;
	        }
       }

       if ((Jaw3_close) && (!Jaw3_open))
       {
           if (Jaw3.transform.eulerAngles.x > Lower_board)
           {
               Jaw3.transform.RotateAround(axis.transform.position, axis.transform.right, angleSpeed * Time.deltaTime);
               // Debug.Log ("Angle_close: " + gripper.transform.eulerAngles.x); 
               // Debug.Log ("Lower_board: " + lower_board);
           }
           else
           {
               Jaw3_close = false;
           } 
       }



               if (Jaw4_open)
       {
           if (Jaw4.transform.eulerAngles.x < Uppear_board)
            {
                Jaw4.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed * Time.deltaTime);
            }
           else
            {
               Jaw4_open = false;
	        }
       }

       if ((Jaw4_close) && (!Jaw4_open))
       {
           if (Jaw4.transform.eulerAngles.x > Lower_board)
           {
               Jaw4.transform.RotateAround(axis.transform.position, axis.transform.right, angleSpeed * Time.deltaTime);
               // Debug.Log ("Angle_close: " + gripper.transform.eulerAngles.x); 
               // Debug.Log ("Lower_board: " + lower_board);
           }
           else
           {
               Jaw4_close = false;
           } 
       }



               if (Jaw5_open)
       {
           if (Jaw5.transform.eulerAngles.x < Uppear_board)
            {
                Jaw5.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed * Time.deltaTime);
            }
           else
            {
               Jaw5_open = false;
	        }
       }

       if ((Jaw5_close) && (!Jaw5_open))
       {
           if (Jaw5.transform.eulerAngles.x > Lower_board)
           {
               Jaw5.transform.RotateAround(axis.transform.position, axis.transform.right, angleSpeed * Time.deltaTime);
               // Debug.Log ("Angle_close: " + gripper.transform.eulerAngles.x); 
               // Debug.Log ("Lower_board: " + lower_board);
           }
           else
           {
               Jaw5_close = false;
           } 
       }




    
    }
}