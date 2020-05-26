using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_mode_2 : MonoBehaviour
{
    public GameObject camera_G1_racer;
    public GameObject camera_G1_fatboy;
    public GameObject camera_G2_racer;
    public GameObject camera_G2_fatboy;
    public GameObject camera_G2_up;
    public GameObject game1_ui;
    public GameObject game2_ui;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMode.Game_2_active)
        {
            Game1_CAMERAS(false);
            Game2_CAMERAS(true);
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
        camera_G2_fatboy.SetActive(active);
        camera_G2_racer.SetActive(active);
        camera_G2_up.SetActive(active);
    }
    void Game1_CAMERAS(bool active)
    {
        camera_G1_fatboy.SetActive(active);
        camera_G1_racer.SetActive(active);
    }
}
