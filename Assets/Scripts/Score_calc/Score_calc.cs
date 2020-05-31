using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_calc : MonoBehaviour
{
    private int Score;

    public Text ScoreText;
    public Text RedCupsText;
    public Text GreenCupsText;
    public Text WindsocksText;
    public Text LighthouseText;

    public Text ScoreText_racer;
    public Text RedCupsText_racer;
    public Text GreenCupsText_racer;
    public Text WindsocksText_racer;
    public Text LighthouseText_racer;

    public Text ScoreText_fatboy;
    public Text RedCupsText_fatboy;
    public Text GreenCupsText_fatboy;
    public Text WindsocksText_fatboy;
    public Text LighthouseText_fatboy;
    
    public string side_color;

    public static bool racer;
    public static bool fatboy;
    public static bool racer_color_is_yellow;
    public static bool fatboy_color_is_yellow;

    private GameObject lighthouse_yellow;
    private GameObject lighthouse_blue;

    private GameObject SmallPort;
    private GameObject SmallPortGreen;
    private GameObject SmallPortRed;
    private int SmallPortCups;
    private int SmallPortGreenCups;
    private int SmallPortRedCups;
    private int SmallPortPairCups;

    private GameObject BigPort;
    private GameObject BigPortGreen;
    private GameObject BigPortRed;
    private int BigPortCups;
    private int BigPortGreenCups;
    private int BigPortRedCups;
    private int BigPortPairCups;

    private bool[] windsocksStatus;
    private int windsocks_score;

    private GameObject NorthZone;
    private GameObject SouthZone;
    public int mooring_score = 0;
    public int insideNorth;
    public int insideSouth;
    private string weathervaneStatus;

    public int lighthouse_score = 0;

    private bool OneSideOnly = true;
    
    // Start is called before the first frame update
    void Start()
    {
        lighthouse_yellow = GameObject.Find("Light_House");
        lighthouse_blue = GameObject.Find("Light_House1");

        if ((racer) && (fatboy))
        {
            if (((racer_color_is_yellow) && (fatboy_color_is_yellow)) || ((!(racer_color_is_yellow)) && (!(fatboy_color_is_yellow))))
                OneSideOnly = true;
            else
                OneSideOnly = false;
        }
        else OneSideOnly = true;

        if (OneSideOnly)
            OneSideSetup();
        //else
        //    TwoSidesSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (OneSideOnly)
            OneSideUpdate();
    }

    void OneSideSetup()
    {
        if (racer)
        {
            if (racer_color_is_yellow)
            {
                side_color = "Yellow";
            }
            else
            {
                side_color = "Blue";
            }
        }
        else
        {
            if (fatboy_color_is_yellow)
            {
                side_color = "Yellow";
            }
            else
            {
                side_color = "Blue";
            }
        }

        if (side_color == "Yellow")
        {
            SmallPort = GameObject.Find("YellowSmallPort");
            SmallPortGreen = GameObject.Find("YellowSmallPortGreen");
            SmallPortRed = GameObject.Find("YellowSmallPortRed");

            BigPort = GameObject.Find("YellowBigPort");
            BigPortGreen = GameObject.Find("YellowBigPortGreen");
            BigPortRed = GameObject.Find("YellowBigPortRed");

            NorthZone = GameObject.Find("YellowNorthZone");
            SouthZone = GameObject.Find("YellowSouthZone");
        }
        else
        {
            SmallPort = GameObject.Find("BlueSmallPort");
            SmallPortGreen = GameObject.Find("BlueSmallPortGreen");
            SmallPortRed = GameObject.Find("BlueSmallPortRed");

            BigPort = GameObject.Find("BlueBigPort");
            BigPortGreen = GameObject.Find("BlueBigPortGreen");
            BigPortRed = GameObject.Find("BlueBigPortRed");

            NorthZone = GameObject.Find("BlueNorthZone");
            SouthZone = GameObject.Find("BlueSouthZone");
        }
    }

    //void TwoSidesSetup()
    //{
    //
    //}

    void OneSideUpdate()
    {
        // Cups:
        SmallPortCups = SmallPort.GetComponent<All_cup_detection>().CupsInsideCount;
        SmallPortGreenCups = SmallPortGreen.GetComponent<Green_cup_detection>().CupsInsideCount;
        SmallPortRedCups = SmallPortRed.GetComponent<Red_cup_detection>().CupsInsideCount;

        if (SmallPortGreenCups < SmallPortRedCups)
        {
            SmallPortPairCups = SmallPortGreenCups;
        }
        else
        {
            SmallPortPairCups = SmallPortRedCups;
        }

        BigPortCups = BigPort.GetComponent<All_cup_detection>().CupsInsideCount;
        BigPortGreenCups = BigPortGreen.GetComponent<Green_cup_detection>().CupsInsideCount;
        BigPortRedCups = BigPortRed.GetComponent<Red_cup_detection>().CupsInsideCount;

        if (BigPortGreenCups < BigPortRedCups)
        {
            BigPortPairCups = BigPortGreenCups;
        }
        else
        {
            BigPortPairCups = BigPortRedCups;
        }

        // Windsocks:
        windsocksStatus = tableStateHandler.windsocksStatus;

        if (side_color == "Blue")
        {
            if ((windsocksStatus[0]) && (windsocksStatus[1]))
                windsocks_score = 15;
            else if ((windsocksStatus[0]) || (windsocksStatus[1]))
                windsocks_score = 5;
            else
                windsocks_score = 0;
        }
        else if (side_color == "Yellow")
        {
            if ((windsocksStatus[2]) && (windsocksStatus[3]))
                windsocks_score = 15;

            else if ((windsocksStatus[2]) || (windsocksStatus[3]))
                windsocks_score = 5;
            else
                windsocks_score = 0;
        }

        // Mooring zone:
        insideNorth = NorthZone.GetComponent<Mooring_zone_detector>().RobotInside;
        insideSouth = SouthZone.GetComponent<Mooring_zone_detector>().RobotInside;
        weathervaneStatus = tableStateHandler.weathervaneStatus;

        if ((racer) && (fatboy))
        {
            if ((insideNorth != 0) && (insideSouth != 0))
            {
                mooring_score = 0;
            }
            else
            {
                if (weathervaneStatus == "N")
                {
                    if (insideNorth != 0)
                    {
                        mooring_score = insideNorth * 5;
                    }
                    else if (insideSouth == 2)
                    {
                        mooring_score = 5;
                    }
                    else
                    {
                        mooring_score = 0;
                    }

                }
                else
                {
                    if (insideSouth != 0)
                    {
                        mooring_score = insideSouth * 5;
                    }
                    else if (insideNorth == 2)
                    {
                        mooring_score = 5;
                    }
                    else
                    {
                        mooring_score = 0;
                    }
                }
            }
        }
        else
        {
            if (weathervaneStatus == "N")
            {
                mooring_score = insideNorth * 10 + insideSouth * 5;
            }
            else
            {
                mooring_score = insideSouth * 10 + insideNorth * 5;
            }

        }

        //Lighthouse:
        if (lighthouse_yellow != null)
        {
            if (lighthouse_yellow.GetComponent<LightHouseScript>().lightHouseIsActivated)
                lighthouse_score = 15;
        }
        if (lighthouse_blue != null)
        {
            if (lighthouse_blue.GetComponent<LightHouseScript1>().lightHouseIsActivated)
                lighthouse_score = 15;
        }

        // Sum score calculation
        Score = (SmallPortGreenCups + SmallPortRedCups) * 2 + SmallPortPairCups * 2 + (SmallPortCups - SmallPortGreenCups - SmallPortRedCups) * 1 + (BigPortGreenCups + BigPortRedCups) * 2 + BigPortPairCups * 2 + (BigPortCups - BigPortGreenCups - BigPortRedCups) * 1 + windsocks_score + mooring_score + lighthouse_score;
        
        // Text representation
        if ((racer) && (fatboy))
        {
            if (windsocks_score == 15)
            { WindsocksText_racer.text = "2"; WindsocksText_fatboy.text = "2"; }
            else if (windsocks_score == 5)
            { WindsocksText_racer.text = "1"; WindsocksText_fatboy.text = "1"; }
            else if (windsocks_score == 0)
            { WindsocksText_racer.text = "0"; WindsocksText_fatboy.text = "0"; }
            if (lighthouse_score == 15)
            { LighthouseText_racer.text = "1"; LighthouseText_fatboy.text = "1"; }
            else
            { LighthouseText_racer.text = "0"; LighthouseText_fatboy.text = "0"; }
            RedCupsText_racer.text = (SmallPortRedCups + BigPortRedCups).ToString();
            RedCupsText_fatboy.text = (SmallPortRedCups + BigPortRedCups).ToString();
            GreenCupsText_racer.text = (SmallPortGreenCups + BigPortGreenCups).ToString();
            GreenCupsText_fatboy.text = (SmallPortGreenCups + BigPortGreenCups).ToString();
            ScoreText_racer.text = "Score: " + Score.ToString();
            ScoreText_fatboy.text = "Score: " + Score.ToString();
        }
        else
        {
            if (windsocks_score == 15)
                WindsocksText.text = "2";
            else if (windsocks_score == 5)
                WindsocksText.text = "1";
            else if (windsocks_score == 0)
                WindsocksText.text = "0";
            if (lighthouse_score == 15)
                LighthouseText.text = "1";
            else
                LighthouseText.text = "0";
            RedCupsText.text = (SmallPortRedCups + BigPortRedCups).ToString();
            GreenCupsText.text = (SmallPortGreenCups + BigPortGreenCups).ToString();
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
}
