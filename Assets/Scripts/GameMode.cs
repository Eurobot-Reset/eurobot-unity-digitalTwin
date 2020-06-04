using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static bool Game_2_active; // режим кате надо
    public static bool restart = true;
    //Side variable: array of 2 (0 - racer, 1 - big) | 0 - blue; 1 - yellow;
    public static bool[] isYellowSide = new bool[2] {false, false};
    //Choosed Robots variable: array of 2 (0 - racer, 1 - big) | 1 - robot is set, 0 - robot is not setted
    public static bool[] robot = new bool[2] {false, false};
    //Strategy game mode
    public static bool strategyMode = false;


    //lighthouse.transform.position = new Vector3(22.09f, 9.28f, -10f);
    //lighthouse.transform.position = new Vector3(277.54f, 9.28f, -10f);

    //проверка удалить потом
    public bool yell_r;
    public bool yell_f;

    private GameObject racer;
    private GameObject fat;
    private GameObject lighthouse_yellow;
    private GameObject lighthouse_blue;

    // Load scene event
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if (restart && scene.name.Equals("Main")) initGame();
    }

    void initGame()
    {
        fat = GameObject.Find("FatBoy");
        racer = GameObject.Find("RobotRacer");

        //----lighthouse----
        lighthouse_yellow = GameObject.Find("Light_House");
        lighthouse_blue = GameObject.Find("Light_House1");
        lighthouse_yellow.transform.eulerAngles = new Vector3(0, 90f, 0);
        lighthouse_blue.transform.eulerAngles = new Vector3(0, 90f, 0);

        //Yellow position
        lighthouse_yellow.transform.position = new Vector3(22.09f, 9.28f, -10f);

        //Blue position
        lighthouse_blue.transform.position = new Vector3(277.54f, 9.28f, -10f);
        //------------------

        Time.timeScale = 1;
        
        if(!strategyMode) {
            //Setting default gamemode
            if (robot[0]) racer.SetActive(true);
            else racer.SetActive(false);
            if (robot[1]) fat.SetActive(true);
            else fat.SetActive(false);
            if ((robot[0]) && (robot[1]))
            {
                if ((isYellowSide[0]) && (isYellowSide[1]))
                {
                    lighthouse_yellow.SetActive(true);
                    lighthouse_blue.SetActive(false);
                }
                else if ((!(isYellowSide[0])) && (!(isYellowSide[1])))
                {
                    lighthouse_yellow.SetActive(false);
                    lighthouse_blue.SetActive(true);
                }
                else
                {
                    lighthouse_yellow.SetActive(true);
                    lighthouse_blue.SetActive(true);
                }
            }
            else if (robot[0])
            {
                if (isYellowSide[0])
                {
                    lighthouse_yellow.SetActive(true);
                    lighthouse_blue.SetActive(false);
                }
                else
                {
                    lighthouse_yellow.SetActive(false);
                    lighthouse_blue.SetActive(true);
                }
            }
            else if (robot[1])
            {
                if (isYellowSide[1])
                {
                    lighthouse_yellow.SetActive(true);
                    lighthouse_blue.SetActive(false);
                }
                else
                {
                    lighthouse_yellow.SetActive(false);
                    lighthouse_blue.SetActive(true);
                }
            }
        } else {
            //Init strategy game mode
            robot[0] = true;
            robot[1] = true;
            racer.SetActive(true);
            fat.SetActive(true);
        }

        if(isYellowSide[0]) {
            // Position
            racer.transform.position = new Vector3(11.5f,7.3f,67.8f);
            // Rotation
            racer.transform.eulerAngles = new Vector3(0, 60f, 0);
            yell_r = true; // delete
        } else {
            racer.transform.position = new Vector3(287.6f,7.3f,66.9f);
            racer.transform.eulerAngles = new Vector3(0, 120f, 0);
            yell_r = false;
        }

        if(isYellowSide[1]) {
            fat.transform.position = new Vector3(29.3f,18.5f,92.3f);
            fat.transform.eulerAngles = new Vector3(0, -150f, 0);
            yell_f = true;
        } else {
            fat.transform.position = new Vector3(270.1f,18.5f,93.1f);
            fat.transform.eulerAngles = new Vector3(0, 150f, 0);
            yell_f = false;
        }

        restart = false;
    }
}
