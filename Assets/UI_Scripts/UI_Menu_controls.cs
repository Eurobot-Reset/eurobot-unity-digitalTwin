using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu_controls : MonoBehaviour
{

    /*    private static string Robot;

        public void FatboyPressed()
        {
            SceneManager.LoadScene("Game1");
            Robot = "Fatboy";
            PlayerPrefs.SetString("Robot", Robot);

        }
        public void RacerPressed()
        {
            SceneManager.LoadScene("Game1");
            Robot = "Racer";
            PlayerPrefs.SetString("Robot", Robot);
        }
        */

    public void Play1Pressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void Play2Pressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StrategyPressed()
    {
        SceneManager.LoadScene("Main");
    }
}
