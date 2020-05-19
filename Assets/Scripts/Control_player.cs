using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Control_player : MonoBehaviour
{

    public GameObject playerBody;

    //Key controller
    public CharacterController controller;
    public float speed = 40f;
    public float rotation_speed = 1f;
    public float gravity = -98.1f;

    Vector3 velocity;

    void Start()
    {
        playerBody = GameObject.Find("RobotRacer");
    }

    // Update is called once per frame
    void Update()
    {
        Keycontrol();
    }


    void Keycontrol()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Submit");

        playerBody.transform.Rotate(Vector3.up * y * rotation_speed);

        Vector3 move = transform.right * x - transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
