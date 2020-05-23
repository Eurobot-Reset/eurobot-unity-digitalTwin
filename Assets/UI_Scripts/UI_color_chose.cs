using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_color_chose : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Fatboy_color_button;
    public Button Racer_color_button;
//    private static string Robot;
    private static string Fatboy_color;
    private static string Racer_color;
    private Color my_blue = new Color(97 / 255f, 185 / 255f, 217 / 255f);
    private Color my_yellow = new Color(236 / 255f, 248 / 255f, 65 / 255f);



    // по умолчанию желтая сторона 
    void Start()
    {
//        Robot = "Both";
        Fatboy_color = "Yellow";
        Racer_color = "Yellow";
        PlayerPrefs.SetString("Fatboy_color", Fatboy_color);
        PlayerPrefs.SetString("Racer_color", Racer_color);
        Fatboy_color_button.GetComponent<Graphic>().color = my_yellow;
        Racer_color_button.GetComponent<Graphic>().color = my_yellow;
        Fatboy_color_button.GetComponentInChildren<Text>().text = Fatboy_color;
        Racer_color_button.GetComponentInChildren<Text>().text = Racer_color;
    }
    //Fatboy   
    public void Fatboy_color_G2()
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
     public void Racer_color_G2()
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
}
