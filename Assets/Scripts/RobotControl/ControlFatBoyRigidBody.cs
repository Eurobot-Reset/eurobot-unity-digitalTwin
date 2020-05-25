using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControlFatBoyRigidBody : MonoBehaviour
{


    Rigidbody rb;
    
    public float speed = 500f;
    public float torque;
    public float rotation_speed = 5f;
    public float gravity = -9.81f;

    Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.U) ||  Input.GetKey(KeyCode.I) ||  Input.GetKey(KeyCode.O) ||  Input.GetKey(KeyCode.K) ||  Input.GetKey(KeyCode.L))
            {Keycontrol();}
    }


    void Keycontrol()
    {
        float x = Input.GetAxis("FatBoyFront");
        float y = Input.GetAxis("FatBoySide");
        float z = Input.GetAxis("FatBoyRotation");

        Vector3 move = transform.right * y + transform.forward * x;
 
        rb.AddForce (move * speed);
        rb.AddTorque(-transform.up * torque * z);
    }
}

