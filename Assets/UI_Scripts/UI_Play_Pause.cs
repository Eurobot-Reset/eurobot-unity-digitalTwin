using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Play_Pause : MonoBehaviour
{
    public bool pause;
    public GameObject PausePannel;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        PausePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onPause()
    {
        pause = !pause;
        if (!pause)
        {
            Time.timeScale = 1;
            PausePannel.SetActive(false);
        }
        else if (pause)
        {
            Time.timeScale = 0;
            PausePannel.SetActive(true);
        }
    }
}


   