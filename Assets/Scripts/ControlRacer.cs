using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControlRacer : MonoBehaviour
{

    public GameObject playerBody;

    //Key controller
    public CharacterController controller;
    public float speed = 50f;
    public float rotation_speed = 5f;
    public float gravity = -9.81f;

    Vector3 velocity;

    void Start()
    {
        playerBody = GameObject.Find("RobotRacer");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) ||  Input.GetKey(KeyCode.A) ||  Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.Q) ||  Input.GetKey(KeyCode.E))
            {Keycontrol();}
    }


    void Keycontrol()
    {
        float x = Input.GetAxis("RacerFront");
        float y = Input.GetAxis("RacerSide");
        float z = Input.GetAxis("RacerRotation");

        playerBody.transform.Rotate(-Vector3.up * z * rotation_speed);

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
