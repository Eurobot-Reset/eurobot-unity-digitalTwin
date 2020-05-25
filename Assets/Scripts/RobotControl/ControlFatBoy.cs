using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControlFatBoy : MonoBehaviour
{

    public GameObject playerBody;

    //Key controller
    public Rigidbody rb;
    public float speed = 50f;
    public float rotation_speed = 5f;

    Vector3 velocity;

    void Start()
    {
        playerBody = GameObject.Find("FatBoy");
        rb = this.GetComponent<Rigidbody>();
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

        playerBody.transform.Rotate(-Vector3.up * z * rotation_speed);

        Vector3 move = transform.right * y + transform.forward * x;
        rb.MovePosition(playerBody.transform.position + (move * speed * Time.deltaTime));
    }
}
