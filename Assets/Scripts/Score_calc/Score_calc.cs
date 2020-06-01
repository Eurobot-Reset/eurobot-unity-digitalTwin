using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_calc : MonoBehaviour
{
    //Text areas
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

    public static bool racer;
    public static bool fatboy;
    public static bool racer_color_is_yellow;
    public static bool fatboy_color_is_yellow;

    public Text total_score_racer; // gor game over score racer
    public Text total_score_fatboy; // gor game over score fatboy  

    private GameObject lighthouse_yellow;
    private GameObject lighthouse_blue;

    private bool[] windsocksStatus;
    private string weathervaneStatus;

    private bool OneSideOnly = true;

    // 1
    public string side_color;

    private GameObject SmallPort;
    private GameObject SmallPortGreen;
    private GameObject SmallPortRed;
    private GameObject BigPort;
    private GameObject BigPortGreen;
    private GameObject BigPortRed;
    private GameObject NorthZone;
    private GameObject SouthZone;

    private int SmallPortCups;
    private int SmallPortGreenCups;
    private int SmallPortRedCups;
    private int SmallPortPairCups;
    private int BigPortCups;
    private int BigPortGreenCups;
    private int BigPortRedCups;
    private int BigPortPairCups;

    private int windsocks_score;
    public int lighthouse_score = 0;
    public int insideNorth;
    public int insideSouth;
    public int mooring_score = 0;
    private int Score;

    private bool fatboy_flag_failed = false;
    private int fatboy_flag_score = 0;

    // 2
    public string side_color_2;

    private GameObject SmallPort_2;
    private GameObject SmallPortGreen_2;
    private GameObject SmallPortRed_2;
    private GameObject BigPort_2;
    private GameObject BigPortGreen_2;
    private GameObject BigPortRed_2;
    private GameObject NorthZone_2;
    private GameObject SouthZone_2;

    private int SmallPortCups_2;
    private int SmallPortGreenCups_2;
    private int SmallPortRedCups_2;
    private int SmallPortPairCups_2;
    private int BigPortCups_2;
    private int BigPortGreenCups_2;
    private int BigPortRedCups_2;
    private int BigPortPairCups_2;

    private int windsocks_score_2;
    public int lighthouse_score_2 = 0;
    public int insideNorth_2;
    public int insideSouth_2;
    public int mooring_score_2 = 0;
    private int Score_2;

    private bool fatboy_flag_failed_2 = false;
    private int fatboy_flag_score_2 = 0;

    //timer
    public float t;
    

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
        else
            TwoSidesSetup();
    }

    // Update is called once per frame
    void Update()
    {
        t = UI_Timer.t;

        OneSideUpdate();
        if (OneSideOnly) ShowTextOneSide();
        else { SecondSideUpdate(); ShowTextTwoSides(); }
    }

    void OneSideSetup()
    {
        if (racer)
            if (racer_color_is_yellow) side_color = "Yellow";
            else side_color = "Blue";
        else
            if (fatboy_color_is_yellow) side_color = "Yellow";
            else side_color = "Blue";

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

    void TwoSidesSetup()
    {
        if (racer_color_is_yellow) side_color = "Yellow";
        else side_color = "Blue";
        if (fatboy_color_is_yellow) side_color_2 = "Yellow";
        else side_color_2 = "Blue";

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

            SmallPort_2 = GameObject.Find("BlueSmallPort");
            SmallPortGreen_2 = GameObject.Find("BlueSmallPortGreen");
            SmallPortRed_2 = GameObject.Find("BlueSmallPortRed");
            BigPort_2 = GameObject.Find("BlueBigPort");
            BigPortGreen_2 = GameObject.Find("BlueBigPortGreen");
            BigPortRed_2 = GameObject.Find("BlueBigPortRed");
            NorthZone_2 = GameObject.Find("BlueNorthZone");
            SouthZone_2 = GameObject.Find("BlueSouthZone");
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

            SmallPort_2 = GameObject.Find("YellowSmallPort");
            SmallPortGreen_2 = GameObject.Find("YellowSmallPortGreen");
            SmallPortRed_2 = GameObject.Find("YellowSmallPortRed");
            BigPort_2 = GameObject.Find("YellowBigPort");
            BigPortGreen_2 = GameObject.Find("YellowBigPortGreen");
            BigPortRed_2 = GameObject.Find("YellowBigPortRed");
            NorthZone_2 = GameObject.Find("YellowNorthZone");
            SouthZone_2 = GameObject.Find("YellowSouthZone");
        }    
    }

    void OneSideUpdate()
    {
        // Cups:
        SmallPortCups = SmallPort.GetComponent<All_cup_detection>().CupsInsideCount;
        SmallPortGreenCups = SmallPortGreen.GetComponent<Green_cup_detection>().CupsInsideCount;
        SmallPortRedCups = SmallPortRed.GetComponent<Red_cup_detection>().CupsInsideCount;

        if (SmallPortGreenCups < SmallPortRedCups)
            SmallPortPairCups = SmallPortGreenCups;
        else SmallPortPairCups = SmallPortRedCups;

        BigPortCups = BigPort.GetComponent<All_cup_detection>().CupsInsideCount;
        BigPortGreenCups = BigPortGreen.GetComponent<Green_cup_detection>().CupsInsideCount;
        BigPortRedCups = BigPortRed.GetComponent<Red_cup_detection>().CupsInsideCount;

        if (BigPortGreenCups < BigPortRedCups)
            BigPortPairCups = BigPortGreenCups;
        else
            BigPortPairCups = BigPortRedCups;

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

        if ((racer) && (fatboy) && (racer_color_is_yellow == fatboy_color_is_yellow))
        {
            if ((insideNorth != 0) && (insideSouth != 0))
                mooring_score = 0;
            else
            {
                if (weathervaneStatus == "N")
                {
                    if (insideNorth != 0)
                        mooring_score = insideNorth * 5;
                    else if (insideSouth == 2)
                        mooring_score = 5;
                    else
                        mooring_score = 0;

                }
                else
                {
                    if (insideSouth != 0)
                        mooring_score = insideSouth * 5;
                    else if (insideNorth == 2)
                        mooring_score = 5;
                    else
                        mooring_score = 0;
                }
            }
        }
        else
        {
            if (weathervaneStatus == "N")
                mooring_score = insideNorth * 10 + insideSouth * 5;
            else
                mooring_score = insideSouth * 10 + insideNorth * 5;

        }

        //Lighthouse:
        if (lighthouse_yellow != null)
            if (lighthouse_yellow.GetComponent<LightHouseScript>().lightHouseIsActivated)
                if (side_color == "Yellow") lighthouse_score = 15;
        if (lighthouse_blue != null)
            if (lighthouse_blue.GetComponent<LightHouseScript1>().lightHouseIsActivated)
                if (side_color == "Blue") lighthouse_score = 15;

        //Fatboy flag:
        if ((racer) && (fatboy))
        {
            if (((racer_color_is_yellow) && (fatboy_color_is_yellow)) || ((!(racer_color_is_yellow)) && (!(fatboy_color_is_yellow))))
            {
                if ((t > 5.0f) && (FatboyFlag.fatboy_flag))
                    fatboy_flag_failed = true;
                if ((t < 5.0f) && (FatboyFlag.fatboy_flag) && (!(fatboy_flag_failed)))
                    fatboy_flag_score = 5;
            }
        }
        else
        {
            if ((t > 5.0f) && (FatboyFlag.fatboy_flag))
                fatboy_flag_failed = true;
            if ((t < 5.0f) && (FatboyFlag.fatboy_flag) && (!(fatboy_flag_failed)))
                fatboy_flag_score = 5;
        }

        // Sum score calculation
        Score = (SmallPortGreenCups + SmallPortRedCups) * 2 + SmallPortPairCups * 2 + (SmallPortCups - SmallPortGreenCups - SmallPortRedCups) * 1 + (BigPortGreenCups + BigPortRedCups) * 2 + BigPortPairCups * 2 + (BigPortCups - BigPortGreenCups - BigPortRedCups) * 1 + windsocks_score + mooring_score + lighthouse_score + fatboy_flag_score;
        
    }

    void SecondSideUpdate()
    {
        // Cups:
        SmallPortCups_2 = SmallPort_2.GetComponent<All_cup_detection>().CupsInsideCount;
        SmallPortGreenCups_2 = SmallPortGreen_2.GetComponent<Green_cup_detection>().CupsInsideCount;
        SmallPortRedCups_2 = SmallPortRed_2.GetComponent<Red_cup_detection>().CupsInsideCount;

        if (SmallPortGreenCups_2 < SmallPortRedCups_2)
            SmallPortPairCups_2 = SmallPortGreenCups_2;
        else SmallPortPairCups_2 = SmallPortRedCups_2;

        BigPortCups_2 = BigPort_2.GetComponent<All_cup_detection>().CupsInsideCount;
        BigPortGreenCups_2 = BigPortGreen_2.GetComponent<Green_cup_detection>().CupsInsideCount;
        BigPortRedCups_2 = BigPortRed_2.GetComponent<Red_cup_detection>().CupsInsideCount;

        if (BigPortGreenCups_2 < BigPortRedCups_2)
            BigPortPairCups_2 = BigPortGreenCups_2;
        else
            BigPortPairCups_2 = BigPortRedCups_2;

        // Windsocks:
        windsocksStatus = tableStateHandler.windsocksStatus;

        if (side_color_2 == "Blue")
        {
            if ((windsocksStatus[0]) && (windsocksStatus[1]))
                windsocks_score_2 = 15;
            else if ((windsocksStatus[0]) || (windsocksStatus[1]))
                windsocks_score_2 = 5;
            else
                windsocks_score_2 = 0;
        }
        else if (side_color_2 == "Yellow")
        {
            if ((windsocksStatus[2]) && (windsocksStatus[3]))
                windsocks_score_2 = 15;

            else if ((windsocksStatus[2]) || (windsocksStatus[3]))
                windsocks_score_2 = 5;
            else
                windsocks_score_2 = 0;
        }

        // Mooring zone:
        insideNorth_2 = NorthZone_2.GetComponent<Mooring_zone_detector>().RobotInside;
        insideSouth_2 = SouthZone_2.GetComponent<Mooring_zone_detector>().RobotInside;
        weathervaneStatus = tableStateHandler.weathervaneStatus;

        if ((racer) && (fatboy) && (racer_color_is_yellow == fatboy_color_is_yellow))
        {
            if ((insideNorth_2 != 0) && (insideSouth_2 != 0))
                mooring_score_2 = 0;
            else
            {
                if (weathervaneStatus == "N")
                {
                    if (insideNorth_2 != 0)
                        mooring_score_2 = insideNorth_2 * 5;
                    else if (insideSouth_2 == 2)
                        mooring_score_2 = 5;
                    else
                        mooring_score_2 = 0;

                }
                else
                {
                    if (insideSouth_2 != 0)
                        mooring_score_2 = insideSouth_2 * 5;
                    else if (insideNorth_2 == 2)
                        mooring_score_2 = 5;
                    else
                        mooring_score_2 = 0;
                }
            }
        }
        else
        {
            if (weathervaneStatus == "N")
                mooring_score_2 = insideNorth_2 * 10 + insideSouth_2 * 5;
            else
                mooring_score_2 = insideSouth_2 * 10 + insideNorth_2 * 5;

        }

        //Lighthouse:
        if (lighthouse_yellow != null)
            if (lighthouse_yellow.GetComponent<LightHouseScript>().lightHouseIsActivated)
                if (side_color_2 == "Yellow") lighthouse_score_2 = 15;
        if (lighthouse_blue != null)
            if (lighthouse_blue.GetComponent<LightHouseScript1>().lightHouseIsActivated)
                if (side_color_2 == "Blue") lighthouse_score_2 = 15;

        //Fatboy flag:
        if ((t > 5.0f) && (FatboyFlag.fatboy_flag))
            fatboy_flag_failed_2 = true;
        if ((t < 5.0f) && (FatboyFlag.fatboy_flag) && (!(fatboy_flag_failed)))
            fatboy_flag_score_2 = 5;

        // Sum score calculation
        Score_2 = (SmallPortGreenCups_2 + SmallPortRedCups_2) * 2 + SmallPortPairCups_2 * 2 + (SmallPortCups_2 - SmallPortGreenCups_2 - SmallPortRedCups_2) * 1 + (BigPortGreenCups_2 + BigPortRedCups_2) * 2 + BigPortPairCups_2 * 2 + (BigPortCups_2 - BigPortGreenCups_2 - BigPortRedCups_2) * 1 + windsocks_score_2 + mooring_score_2 + lighthouse_score_2 + fatboy_flag_score_2;
    }

    void ShowTextOneSide()
    {
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

    void ShowTextTwoSides()
    {
        // Text representation
        if (windsocks_score == 15)
            WindsocksText_racer.text = "2";
        else if (windsocks_score == 5)
            WindsocksText_racer.text = "1";
        else if (windsocks_score == 0)
            WindsocksText_racer.text = "0";
        if (lighthouse_score == 15)
            LighthouseText_racer.text = "1";
        else
            LighthouseText_racer.text = "0";
        RedCupsText_racer.text = (SmallPortRedCups + BigPortRedCups).ToString();
        GreenCupsText_racer.text = (SmallPortGreenCups + BigPortGreenCups).ToString();
        ScoreText_racer.text = "Score: " + Score.ToString();


        if (windsocks_score_2 == 15)
            WindsocksText_fatboy.text = "2";
        else if (windsocks_score_2 == 5)
            WindsocksText_fatboy.text = "1";
        else if (windsocks_score_2 == 0)
            WindsocksText_fatboy.text = "0";
        if (lighthouse_score_2 == 15)
            LighthouseText_fatboy.text = "1";
        else
            LighthouseText_fatboy.text = "0";
        RedCupsText_fatboy.text = (SmallPortRedCups_2 + BigPortRedCups_2).ToString();
        GreenCupsText_fatboy.text = (SmallPortGreenCups_2 + BigPortGreenCups_2).ToString();
        ScoreText_fatboy.text = "Score: " + Score_2.ToString();

        total_score_racer.text = "Racer score: " + Score.ToString(); ; // вывод на геймовер экран
        total_score_fatboy.text = "Fatboy score: " + Score_2.ToString(); // вывод на гйем овер экран
    }
}
