using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float angleSpeed = 20f;
    public float velocity = 10f;

    private float highBoard = 10f;
    private float lowBoard = 0f;
    private float horizontalBoard = 355f;
    private float verticalBoard = 275f;
    private int numberFingers = 5;
    private bool[] isCup;
    private int numberInt;
    private GameObject[] cups;
    private float[] anglesCapture;

    private GameObject axis;
    private GameObject gripper;
    volatile private GameObject cup;
    volatile private GameObject jawSwivelGripper;
    // Start is called before the first frame update
    void Start()
    {
        axis = GameObject.Find("Axis");
        gripper = GameObject.Find("RotatingJaws");
        gripper.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed );
        isCup = new bool[numberFingers];
        cups = new GameObject[numberFingers];
        anglesCapture = new float[numberFingers];
        for (int i=0;i< numberFingers; i++)
        {
            isCup[i] = false;
        }
        
        //gripper.transform.SetParent(null);
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
        }
        //Comma - ,
        if (Input.GetKey(KeyCode.Comma) && (gripper.transform.eulerAngles.x < horizontalBoard))
        {
            gripper.transform.RotateAround(axis.transform.position, axis.transform.right, -angleSpeed * Time.deltaTime);
            CupPut();
        }
        //Period - dot .
        if (Input.GetKey(KeyCode.Period) && (gripper.transform.eulerAngles.x > verticalBoard))
        {           
            gripper.transform.RotateAround(axis.transform.position, axis.transform.right, angleSpeed * Time.deltaTime);            
        }
    }

    public void GripperTake(Collider gripperCollider, string nameObject)
    {
        Debug.Log("GripperTake");
        nameObject = nameObject[nameObject.Length - 1].ToString();
        numberInt = int.Parse(nameObject) - 1;
        if ((!isCup[numberInt])&&(gripper.transform.eulerAngles.x < horizontalBoard-10))
        {
            Debug.Log(isCup[numberInt]);
            jawSwivelGripper = GameObject.Find("Jaw Swivel Gripper " + nameObject);
            cup = gripperCollider.gameObject;
            cup.transform.SetParent(jawSwivelGripper.transform);
            cup.GetComponent<Rigidbody>().isKinematic = true;
            isCup[numberInt] = true;
            Debug.Log(isCup[numberInt]);
            cups[numberInt] = cup;
            anglesCapture[numberInt] = gripper.transform.eulerAngles.x;
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
}
