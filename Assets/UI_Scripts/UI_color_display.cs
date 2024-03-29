﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_color_display : MonoBehaviour
{
    public Text Text_Side;
    public Text Text_Side_Racer;

    private bool racer;
    private bool fatboy;
    private bool racer_y;
    private bool fatboy_y;
    private string y_string;



    private Color my_blue = new Color(97 / 255f, 185 / 255f, 217 / 255f);
    private Color my_yellow = new Color(236 / 255f, 248 / 255f, 65 / 255f);
    // Start is called before the first frame update
 /*   void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
*/
 //   void OnSceneLoaded(Scene scene, LoadSceneMode mode)
 
    void Update ()
    {
       /* Debug.Log("OnSceneLoaded: " + scene.name);
        racer = GameMode.robot[0];
        fatboy = GameMode.robot[1];
        racer_y = GameMode.isYellowSide[0];
        fatboy_y = GameMode.isYellowSide[1];
*/
        if (PlayerPrefs.GetString("Robot") == "Racer") racer = true;
        else racer = false;
        if (PlayerPrefs.GetString("Robot") == "Fatboy") fatboy = true;
        else fatboy = false;
        if(PlayerPrefs.GetString("Racer_color") == "Yellow") racer_y = true;
        else racer_y = false;
        if (PlayerPrefs.GetString("Fatboy_color") == "Yellow") fatboy_y = true;
        else fatboy_y = false;
        
        if (GameMode.Game_2_active|fatboy) // если Fatboy выбран, то выводим его цвет
        {
            if (fatboy_y)
                Text_Side.text = "Fatboy side: <color=yellow>yellow</color>";
            else
                Text_Side.text = "Fatboy side: <color=blue>blue</color>";

            if (GameMode.Game_2_active) // если Racer тоже  выбран (например Strategy mode), то выводим и его цвет
            {
                if (racer_y)
                    y_string = "Racer side: <color=yellow>yellow</color>";
                else
                    y_string = "Racer side: <color=blue>blue</color>";

                if (GameMode.strategyMode) Text_Side.text += "\n" + y_string;
                else Text_Side_Racer.text = y_string;
            }
        }

        else // если только Racer выбран, то выводим его цвет
        {
            if (racer_y)
                Text_Side.text = "Racer side:<color=yellow>yellow</color>";
            else 
                Text_Side.text = "Racer side: <color=blue> blue </color>";

        }
    }
}
