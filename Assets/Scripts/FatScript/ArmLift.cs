
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmLift : MonoBehaviour
{
    public bool go_arm_down = false;
    public bool go_arm_up = false;
    public bool go_arm_middle = false;
    public float arm_velocity;
    public float y_arm_down = 4.4f;
    public float y_arm_up = 9.0f;

    private GameObject axis;
    private GameObject gripper;
    private bool[] isCup;
    private int numberInt;
    private GameObject[] cups;
    private float[] anglesCapture;
    private int numberFingers = 5;
    // Start is called before the first frame update
    void Start()
    {
        arm_velocity = 4f;
        go_arm_up = true;
        axis = GameObject.Find("Axis");
        gripper = GameObject.Find("RotatingJaws");
        //gripper.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed );
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
        if (go_arm_down)
       {
           if (transform.position.y > 5)
            {
               transform.position -= transform.up * Time.deltaTime * arm_velocity;
               Debug.Log ("Go down: " + gripper.transform.eulerAngles.x); 
               PutACup();
            }
           else
            {
               go_arm_down = false;
	        }
       }

       if ((go_arm_up) && (!(go_arm_down)))
       {
           if (transform.position.y < 10)
           {
               transform.position += transform.up * Time.deltaTime * arm_velocity;
           }
           else
           {
               go_arm_up = false;
           } 
       }

        if (go_arm_middle)
       {
           if (transform.position.y > 6)
            {
               transform.position -= transform.up * Time.deltaTime * arm_velocity;
            }
           else
            {
               go_arm_middle = false;
	        }
       }
    }

    public void PutACup()
    {
        for (int i = 0; i < numberFingers; i++)
        {                 
            if ((anglesCapture[i] < gripper.transform.eulerAngles.x)&&(anglesCapture[i] > 280 + 5))
            {
                cups[i].GetComponent<Rigidbody>().isKinematic = false;
                cups[i].transform.SetParent(null);
                cups[i] = null;
                isCup[i] = false;
                anglesCapture[i] = 0;
            }
        }
    }
}
