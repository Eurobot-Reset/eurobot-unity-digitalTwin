using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseScript : MonoBehaviour
{
    private GameObject lift_1;
    private GameObject lift_2;
    private GameObject cat_rot;

    private GameObject button_right;
    private GameObject button_left;
    private GameObject button_front;

    //down and up position of [0] - LIFT1 | [1] - LIFT2
    private float lightgouseSpeed_1 = 5f;
    private float lightgouseSpeed_2 = 8f;
    private float Speed_rotating_Cat = 180f;

    private float[] Y_up = new float[] {28, 50f};

    public static bool activate_light_house = false;
    public bool lightHouseIsActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        lift_1 = GameObject.Find("LIFT1");
        lift_2 = GameObject.Find("LIFT2");
        cat_rot = GameObject.Find("Cat");

        button_right = GameObject.Find("ColButRight");
        button_left = GameObject.Find("ColButLeft");
        button_front = GameObject.Find("ColButFront");

        activate_light_house = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate_light_house)
        {
            lightHouseIsActivated = true;
            cat_rot.transform.Rotate(Vector3.back * Time.deltaTime * Speed_rotating_Cat);
            rase_lighthouse();
        }
    }
    void rase_lighthouse ()
    {
        if (lift_1.transform.position.y < Y_up[0])
        {
            lift_1.transform.position += transform.up * Time.deltaTime * lightgouseSpeed_1;
        }

        if (lift_2.transform.position.y < Y_up[1])
        {
            lift_2.transform.position += transform.up * Time.deltaTime * lightgouseSpeed_2;
        }
    }
}
