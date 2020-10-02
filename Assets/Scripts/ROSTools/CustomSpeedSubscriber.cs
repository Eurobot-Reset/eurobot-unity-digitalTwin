using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using System;

public class CustomSpeedSubscriber : MonoBehaviour
{
    public CustomMsgSubscriber MsgSubscriber;
    public string data_str;
    public string[] data_arr;
    public string data_item;
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
            data_item = MsgSubscriber.data;

            if (data_item != "")
            {
                
                data_arr = data_item.Split(null);

                if (data_arr[1] == "8")
                {
                    isMessageReceived = false;
                    ProcessSpeedCommand(data_arr[2], data_arr[3], data_arr[4]);
                }
            }
        }
    }

    private void ProcessSpeedCommand(string x, string y, string w)
    {
        Debug.Log("x: " + x);
        Debug.Log("y: " + y);
        Debug.Log("w: " + w);

        //float.TryParse(x, out float _x);
        //float.TryParse(y, out float _y);
        //float.TryParse(w, out float _w);

        float _x;
        float _y;
        float _w;

        _x = (float) Convert.ToDouble(x, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        _y = (float) Convert.ToDouble(y, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        _w = (float) Convert.ToDouble(w, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));

        _w = - _w;
        
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
