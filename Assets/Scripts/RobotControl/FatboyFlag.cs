using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatboyFlag : MonoBehaviour
{
    public GameObject flag_fatboy;
    public static bool fatboy_flag = false;

    private float Speed_rotating_flag = 75f;
    // Start is called before the first frame update
    void Start()
    {
        flag_fatboy = GameObject.Find("Flag v1");
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(flag_fatboy.transform.rotation.x);

        if (Input.GetKey(KeyCode.V))
        {
            fatboy_flag = true;
        }

        if (fatboy_flag == true)
        {
            if (flag_fatboy.transform.rotation.x > -0.375f)
            {
                flag_fatboy.transform.Rotate(Vector3.right * Time.deltaTime * Speed_rotating_flag);
            }
        }
    }
}
