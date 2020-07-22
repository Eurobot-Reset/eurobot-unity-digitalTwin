using System.Collections;
using System.Collections.Generic;
//using UnityEditor.XR;
using UnityEngine;

public class Camera_game_chose : MonoBehaviour
{
    public GameObject camera_G2_racer;
    public GameObject camera_G2_fatboy;
    public GameObject camera_G2_racer_gripper;
    public GameObject camera_G2_fatboy_gripper;

    //public int a = 0;
    //public int b = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMode.Game_2_active)
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                camera_G2_fatboy.SetActive(true);
                camera_G2_fatboy_gripper.SetActive(false);
            }
            if (Input.GetKey(KeyCode.RightControl))
            {
                    camera_G2_fatboy.SetActive(false);
                    camera_G2_fatboy_gripper.SetActive(true);
            }
 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                camera_G2_racer.SetActive(true);
                camera_G2_racer_gripper.SetActive(false);                   
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                camera_G2_racer.SetActive(false);
                camera_G2_racer_gripper.SetActive(true);
            }
          
        }
    }
  
}

