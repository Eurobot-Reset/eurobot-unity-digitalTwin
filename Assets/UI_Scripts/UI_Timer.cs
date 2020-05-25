using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Timer : MonoBehaviour
{
    public GameObject GameOverPanel;
    public static float t = 100f;
    public Text Text_Timer;
    public Text ScoreText;
    public Text TotalScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("Text_Score").GetComponent<Text>();
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (t <= 100f) Text_Timer.text = "Time:" + t.ToString("F0");
        else Text_Timer.text = "Time: inf.";
        t -= Time.deltaTime;

        if (t <= 0.0f)
        {
            t = 0;
            GameOverPanel.SetActive(true);
            Text TotalScoreText = GameObject.Find("Text_Total_Sore").GetComponent<Text>();
            TotalScoreText.text = "Total "+ ScoreText.text;
        };


        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Game restart
            GameOverPanel.SetActive(false);
        };
    }
}




