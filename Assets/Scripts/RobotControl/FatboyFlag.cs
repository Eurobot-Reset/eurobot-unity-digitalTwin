using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatboyFlag : MonoBehaviour
{
    public GameObject flag_fatboy;

    //Activating bool variables
    public static bool fatboy_flag = false;

    private float Speed_rotating_flag = 75f;
    // Start is called before the first frame update
    void Start()
    {
        flag_fatboy = GameObject.Find("Flag v1");
        fatboy_flag = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (fatboy_flag == true)
        {
            if (flag_fatboy.transform.localRotation.x < 0.5f)
            {
                flag_fatboy.transform.Rotate(Vector3.right * Time.deltaTime * Speed_rotating_flag);
            }
        }
    }
}
