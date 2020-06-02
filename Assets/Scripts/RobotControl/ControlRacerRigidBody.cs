using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Networking;

public class ControlRacerRigidBody : NetworkBehaviour
{

    Rigidbody rb;
    
    public float speed = 50f;
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) ||  Input.GetKey(KeyCode.A) ||  Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.Q) ||  Input.GetKey(KeyCode.E))
            {Keycontrol();}
    }


    void Keycontrol()
    {
        float x = Input.GetAxis("RacerFront");
        float y = Input.GetAxis("RacerSide");
        float z = Input.GetAxis("RacerRotation");

        Vector3 move = transform.right * x + transform.forward * y;
 
        rb.AddForce (move * speed);
        rb.AddTorque(-transform.up * torque * z);
    }
}
