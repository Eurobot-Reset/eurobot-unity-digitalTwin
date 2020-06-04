using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu_controls : MonoBehaviour
{

    public void Play1Pressed()
    {
        GameMode.robot[0] = false;
        GameMode.robot[1] = false;
        Score_calc.racer = false;
        Score_calc.fatboy = false;
        Score_calc.racer_color_is_yellow = false;
        Score_calc.fatboy_color_is_yellow = false;

        GameMode.Game_2_active = false; // режим кате надо
        SceneManager.LoadScene("Main");

        string robot = UI_robot_chose.getRobot();
        if (robot.Equals("Racer")) {
            Score_calc.racer = true;
            GameMode.robot[0] = true;
            GameMode.robot[1] = false;
            if (UI_robot_chose.getColor(robot).Equals("Yellow"))
            {
                GameMode.isYellowSide[0] = true;
                Score_calc.racer_color_is_yellow = true;
            } else {
                GameMode.isYellowSide[0] = false;
                Score_calc.racer_color_is_yellow = false;
            }
        } else {
            Score_calc.fatboy = true;
            GameMode.robot[0] = false;
            GameMode.robot[1] = true;
            if (UI_robot_chose.getColor(robot).Equals("Yellow"))
            {
                GameMode.isYellowSide[1] = true;
                Score_calc.fatboy_color_is_yellow = true;
            } else {
                GameMode.isYellowSide[1] = false;
                Score_calc.fatboy_color_is_yellow = false;
            }
        }

        UI_Timer.t = 100f;
        GameMode.restart = true;
    }

    public void Play2Pressed()
    {
        GameMode.robot[0] = false;
        GameMode.robot[1] = false;
        Score_calc.racer = false;
        Score_calc.fatboy = false;
        Score_calc.racer_color_is_yellow = false;
        Score_calc.fatboy_color_is_yellow = false;

        SceneManager.LoadScene("Main");

        GameMode.Game_2_active = true; // режим кате надо
        GameMode.robot[0] = true;
        GameMode.robot[1] = true;
        Score_calc.racer = true;
        Score_calc.fatboy = true;

        if (UI_color_chose.getColor("Racer").Equals("Yellow")) { Score_calc.racer_color_is_yellow = true; GameMode.isYellowSide[0] = true; }
        else GameMode.isYellowSide[0] = false;
        if (UI_color_chose.getColor("Fatboy").Equals("Yellow")) { Score_calc.fatboy_color_is_yellow = true; GameMode.isYellowSide[1] = true; }
        else GameMode.isYellowSide[1] = false;

        UI_Timer.t = 100f;
        GameMode.restart = true;
    }

    public void ExitPressed()
    {
        GameMode.Game_2_active = false; // режим кате надо
        SceneManager.LoadScene("Menu");
    }

    public void StrategyPressed()
    {
        GameMode.Game_2_active = false; // режим кате надо
        GameMode.strategyMode = true;
        GameMode.restart = true;
        UI_Timer.t = 99999f;
        SceneManager.LoadScene("Main");
    }

    public void doExitGame() {
        Application.Quit();
    }
}
