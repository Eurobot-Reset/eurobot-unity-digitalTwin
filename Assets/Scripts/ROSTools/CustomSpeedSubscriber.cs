using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using System;

public class CustomSpeedSubscriber : MonoBehaviour
{
    public CustomMsgSubscriber RacerMsgSubscriber;
    public string[] data;
    public string data_str;
    public string[] data_arr;
    public int data_arr_len = 0;
    int i;
    
    private float previousRealTime;
    private float flipper;
    public Vector3 linearVelocity;
    public Vector3 angularVelocity;
    private bool isMessageReceived = true;
    Rigidbody rb;
    public float speedScaleFactor;
    public float torqueScaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMessageReceived)
        {
            data_arr = RacerMsgSubscriber.data_arr;
            isMessageReceived = false;
            for (i = data_arr_len; i < data_arr.Length; i++)
            {
                data_str = data_arr[i];
                data = data_str.Split(null);

                if (data.Length > 1)
                {
                    if (data[1] == "8")
                    {
                        ProcessSpeedCommand(data[2], data[3], data[4]);
                    }
                }
            }
        }
        
    }

    private void ProcessSpeedCommand(string x, string y, string w)
    {
        float _x = float.Parse(x);
        float _y = float.Parse(y);
        float _w = -float.Parse(w);
        
        float[] speedMsgData = new float[] {_x, _y, _w};
        
        Debug.Log(speedMsgData);
        
        linearVelocity = new Vector3(_x, _y, _w);
        // linearVelocity *= 10;
        
        Vector3 moveVector = transform.right * linearVelocity.x + transform.forward * linearVelocity.y;

        rb.AddForce(moveVector * speedScaleFactor);
        rb.AddTorque(transform.up * linearVelocity.z * torqueScaleFactor);
        
        isMessageReceived = true;
    }
    
}