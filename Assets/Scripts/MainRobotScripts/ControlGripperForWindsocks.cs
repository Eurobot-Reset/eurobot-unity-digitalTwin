using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGripperForWindsocks : MonoBehaviour
{
    public GameObject Gripper;
    public float velocity = 4.0f;
    public float y_gripper_down = 2.0f;
    public float y_gripper_up = 9.0f;

    private bool go_down = false;
    private bool go_up = false;
    private bool gripper_is_down = false;
    private bool gripper_is_up = true;
    // Start is called before the first frame update
    void Start()
    {
        Gripper = GameObject.Find("VacuumGrippers");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (gripper_is_up)
            {
                go_down = true;
            }
            if (gripper_is_down)
            {
                go_up = true;
            }
        }

        if (go_down)
        {
            if (Gripper.transform.position.y > y_gripper_down)
            {
                Gripper.transform.position -= transform.up * Time.deltaTime * velocity;
            }
            else
            {
                go_down = false;
                gripper_is_down = true;
                gripper_is_up = false;
            }
        }

        if (go_up)
        {
            if (Gripper.transform.position.y < y_gripper_up)
            {
                Gripper.transform.position += transform.up * Time.deltaTime * velocity;
            }
            else
            {
                go_up = false;
                gripper_is_down = false;
                gripper_is_up = true;
            }
        }

    }
}
