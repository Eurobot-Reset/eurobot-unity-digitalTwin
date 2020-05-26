using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static bool restart = true;
    //Side variable: array of 2 (0 - racer, 1 - big) | 0 - blue; 1 - yellow;
    public static bool[] isYellowSide = new bool[2] {false, false};
    //Choosed Robots variable: array of 2 (0 - racer, 1 - big) | 1 - robot is set, 0 - robot is not setted
    public static bool[] robot = new bool[2] {false, false};
    //Strategy game mode
    public static bool strategyMode = false;

    private GameObject racer;
    private GameObject fat;

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
        Time.timeScale = 1;
        
        if(!strategyMode) {
            //Setting default gamemode
            if (robot[0]) racer.SetActive(true);
            else racer.SetActive(false);
            if (robot[1]) fat.SetActive(true);
            else fat.SetActive(false);
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
        } else {
            racer.transform.position = new Vector3(287.6f,7.3f,66.9f);
            racer.transform.eulerAngles = new Vector3(0, 120f, 0);
        }

        if(isYellowSide[1]) {
            fat.transform.position = new Vector3(29.3f,18.5f,92.3f);
            fat.transform.eulerAngles = new Vector3(0, -150f, 0);
        } else {
            fat.transform.position = new Vector3(270.1f,18.5f,93.1f);
            fat.transform.eulerAngles = new Vector3(0, 150f, 0);
        }

        restart = false;
    }
}
