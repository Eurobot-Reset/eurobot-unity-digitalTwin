using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Compass : MonoBehaviour
{
    public Text Text_Compass;


 
    // Update is called once per frame
    void Update()
    {
        Text_Compass.text = "Compass:" + tableStateHandler.weathervaneStatus;
    }
}
