using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu_controls : MonoBehaviour
{



    public void PlayPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
