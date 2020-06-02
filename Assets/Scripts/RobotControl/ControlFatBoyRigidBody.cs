using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Networking;

public class ControlFatBoyRigidBody : NetworkBehaviour
{


    Rigidbody rb;
    
    public float speed = 500f;
    public float torque;
    public float rotationSpeed = 5f;
    public float gravity = -9.81f;

    Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.U) ||  Input.GetKey(KeyCode.I) ||  Input.GetKey(KeyCode.O) ||  Input.GetKey(KeyCode.K) ||  Input.GetKey(KeyCode.L))
            {Keycontrol();}
    }


    void Keycontrol()
    {
        float x = -Input.GetAxis("FatBoyFront");
        float y = -Input.GetAxis("FatBoySide");
        float z = Input.GetAxis("FatBoyRotation");

        Vector3 move = transform.right * y + transform.forward * x;
 
        rb.AddForce (move * speed);
        rb.AddTorque(-transform.up * torque * z);
    }
}

