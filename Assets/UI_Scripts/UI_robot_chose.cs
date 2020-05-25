using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_robot_chose : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Fatboy_button;
    public Button Racer_button;
    public Button Fatboy_color_button;
    public Button Racer_color_button;
    private static string Robot;
    private static string Fatboy_color;
    private static string Racer_color;
    private Color my_green= new Color(96/255f, 217/255f, 145/255f);
    private Color my_blue = new Color(97/255f, 185/255f, 217/255f);
    private Color my_yellow = new Color(236/255f, 248/255f, 65/255f);



    // по умолчанию желтая сторона и робот Fatboy
    void Start()
    {
        Robot = "Fatboy";
        Fatboy_color = "Yellow";
        PlayerPrefs.SetString("Robot", Robot);
        PlayerPrefs.SetString("Fatboy_color", Fatboy_color);
        Fatboy_button.GetComponent<Graphic>().color = my_green;
        Fatboy_color_button.GetComponent<Graphic>().color = my_yellow;
    }
    //Fatboy   
    public void FatboyPressed()
    {
        Robot = "Fatboy";
        PlayerPrefs.SetString("Robot", Robot);
        Fatboy_button.GetComponent<Graphic>().color = my_green;
        
        Racer_button.GetComponent<Graphic>().color = Color.white;
        Racer_color_button.GetComponent<Graphic>().color = Color.white;        
        Racer_color_button.GetComponentInChildren<Text>().text = "Click";

    }

    public void Fatboy_color_Pressed()
    {
        if (Fatboy_color == "Blue")
        {
            Fatboy_color = "Yellow";
            Fatboy_color_button.GetComponent<Graphic>().color = my_yellow;
        }
        else
        {
            Fatboy_color = "Blue";
            Fatboy_color_button.GetComponent<Graphic>().color = my_blue;
        }
        PlayerPrefs.SetString("Fatboy_color", Fatboy_color);
        Fatboy_color_button.GetComponentInChildren<Text>().text = Fatboy_color;
    }


    // Racer
    public void RacerPressed()
    {
        Robot = "Racer";
        PlayerPrefs.SetString("Robot", Robot);
        Racer_color = "Yellow";
        PlayerPrefs.SetString("Racer_color", Racer_color);
        Racer_color_button.GetComponent<Graphic>().color = my_yellow;
        Racer_color_button.GetComponentInChildren<Text>().text = Racer_color;
        Racer_button.GetComponent<Graphic>().color = my_green;
        
        Fatboy_button.GetComponent<Graphic>().color = Color.white;
        Fatboy_color_button.GetComponent<Graphic>().color = Color.white;
        Fatboy_color_button.GetComponentInChildren<Text>().text = "Click";

    }

    public void Racer_color_Pressed()
    {
        if (Racer_color == "Blue")
        {
            Racer_color = "Yellow";
            Racer_color_button.GetComponent<Graphic>().color = my_yellow;
        }
        else
        {
            Racer_color = "Blue";
            Racer_color_button.GetComponent<Graphic>().color = my_blue;
        }
        PlayerPrefs.SetString("Racer_color", Racer_color);
        Racer_color_button.GetComponentInChildren<Text>().text = Racer_color;
        
    }

    public static string getRobot() 
    {
        return Robot;
    }

    public static string getColor(string robot) 
    {
        if (robot.Equals("Racer")) return Racer_color;
        else if (robot.Equals("Fatboy")) return Fatboy_color;
        return Fatboy_color;
    }
}
