using System.Collections;
using System.Collections.Generic;
//using UnityEditor.XR;
using UnityEngine;

public class UI_mode_2 : MonoBehaviour
{
    public GameObject camera_G1_racer;
    public GameObject camera_G1_fatboy;
    public GameObject camera_G2_racer;
    public GameObject camera_G2_fatboy;
    public GameObject camera_G2_racer_gripper_1;
    public GameObject camera_G2_racer_gripper_2;
    public GameObject camera_G2_racer_gripper_3;
    
    public GameObject camera_G2_fatboy_gripper_1;
    public GameObject camera_G2_fatboy_gripper_2;
    public GameObject camera_G2_fatboy_gripper_3;
    
    public GameObject camera_G2_up;
    public GameObject game1_ui;
    public GameObject game2_ui;

    public int a = 1;
    public int b = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMode.Game_2_active)
        {
            Game2_CAMERAS_switch(true);
            Game1_CAMERAS(false);
            game1_ui.SetActive(false);
            game2_ui.SetActive(true);
        }
        else
        {
            Game1_CAMERAS(true);
            Game2_CAMERAS(false);
            game1_ui.SetActive(true);
            game2_ui.SetActive(false);
        }
    }

    void Game2_CAMERAS(bool active)
    {
        camera_G2_fatboy_gripper_1.SetActive(active);
        camera_G2_fatboy_gripper_2.SetActive(active);
        camera_G2_fatboy_gripper_3.SetActive(active);
        camera_G2_fatboy.SetActive(active);

        camera_G2_racer_gripper_1.SetActive(active);
        camera_G2_racer_gripper_2.SetActive(active);
        camera_G2_racer_gripper_3.SetActive(active);
        camera_G2_racer.SetActive(active);
        camera_G2_up.SetActive(active);             
    }

    void Game1_CAMERAS(bool active)
    {
        camera_G1_fatboy.SetActive(active);
        camera_G1_racer.SetActive(active);
    }

    void Game2_CAMERAS_switch(bool active)
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.RightShift)) a +=1;
            if (Input.GetKeyDown(KeyCode.RightControl)) a -=1;

            if (a > 4) a = 1;
            if (a < 1) a = 4;

            if (Input.GetKeyDown(KeyCode.LeftShift))  b +=1;
            if (Input.GetKeyDown(KeyCode.LeftControl)) b -=1;

            if (b > 4) b = 1;
            if (b < 1) b = 4;
            
            Camera_fatboy_change(a);
            Camera_racer_change(b);
        }
    }

    void Camera_fatboy_change(int a)
    {
        switch (a)
        {
            case 1:
            camera_G2_fatboy.SetActive(true);
            camera_G2_fatboy_gripper_1.SetActive(false);
            camera_G2_fatboy_gripper_2.SetActive(false);
            camera_G2_fatboy_gripper_3.SetActive(false); 
            break;

            case 2:
                camera_G2_fatboy.SetActive(false);
                camera_G2_fatboy_gripper_1.SetActive(true);
                camera_G2_fatboy_gripper_2.SetActive(false);
                camera_G2_fatboy_gripper_3.SetActive(false);
                break;

            case 3:
                camera_G2_fatboy.SetActive(false);
                camera_G2_fatboy_gripper_1.SetActive(false);
                camera_G2_fatboy_gripper_2.SetActive(true);
                camera_G2_fatboy_gripper_3.SetActive(false);
                break;

            case 4:
                camera_G2_fatboy.SetActive(false);
                camera_G2_fatboy_gripper_1.SetActive(false);
                camera_G2_fatboy_gripper_2.SetActive(false);
                camera_G2_fatboy_gripper_3.SetActive(true);
                break;
        }
    }
        
    void Camera_racer_change(int b)
    {
        switch (b)
        {
            case 1:
                camera_G2_racer.SetActive(true);
                camera_G2_racer_gripper_1.SetActive(false);
                camera_G2_racer_gripper_2.SetActive(false);
                camera_G2_racer_gripper_3.SetActive(false);
                break;

            case 2:
                camera_G2_racer.SetActive(false);
                camera_G2_racer_gripper_1.SetActive(true);
                camera_G2_racer_gripper_2.SetActive(false);
                camera_G2_racer_gripper_3.SetActive(false);
                break;

            case 3:
                camera_G2_racer.SetActive(false);
                camera_G2_racer_gripper_1.SetActive(false);
                camera_G2_racer_gripper_2.SetActive(true);
                camera_G2_racer_gripper_3.SetActive(false);
                break;

            case 4:
                camera_G2_racer.SetActive(false);
                camera_G2_racer_gripper_1.SetActive(false);
                camera_G2_racer_gripper_2.SetActive(false);
                camera_G2_racer_gripper_3.SetActive(true);
                break;
        }
    }   

}
