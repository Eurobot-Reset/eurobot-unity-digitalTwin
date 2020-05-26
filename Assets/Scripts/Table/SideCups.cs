using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCups : MonoBehaviour
{   
    public GameObject GreenCup;
    public GameObject RedCup;
    
    private float shiftZ = 7f;
    private Vector3 firstCupCoordsY1 = new Vector3(-7f, 16f, 145.26f);
    private Vector3 firstCupCoordsY2 = new Vector3(100f, 16f, -7f); 
    private Vector3 firstCupCoordsB1 = new Vector3(307f, 16f, 175f);
    private Vector3 firstCupCoordsB2 = new Vector3(230f, 16f, -7f);
    private Quaternion angle = Quaternion.Euler(180, 0, 0); 
    // If pattern is true, than we have 3 red and 2 green cups for top side;
    private bool patternY = false;
    private bool patternB = false;

    // Start is called before the first frame update
    void Start()
    {
        patternY = (Random.value > 0.5f);
        patternB = (Random.value > 0.5f);

        // For yellow side
        if(patternY) {
            // Setting 3 red cups on top and 2 red cups at side (Yellow)
            // Side
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(GreenCup, firstCupCoordsY1 + new Vector3(0, 0, i*shiftZ), angle);
                else
                    Instantiate(RedCup, firstCupCoordsY1 + new Vector3(0, 0, i*shiftZ), angle);
            } 
            // Top
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(RedCup, firstCupCoordsY2 + new Vector3(-i*shiftZ, 0, 0), angle);
                else
                    Instantiate(GreenCup, firstCupCoordsY2 + new Vector3(-i*shiftZ, 0, 0), angle);
            } 
        } else {
            //Setting 3 green cups on top and 2 green cups at side (Yellow)
            // Side
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(RedCup, firstCupCoordsY1 + new Vector3(0, 0, i*shiftZ), angle);
                else
                    Instantiate(GreenCup, firstCupCoordsY1 + new Vector3(0, 0, i*shiftZ), angle);
            }
            // Top
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(GreenCup, firstCupCoordsY2 + new Vector3(-i*shiftZ, 0, 0), angle);
                else
                    Instantiate(RedCup, firstCupCoordsY2 + new Vector3(-i*shiftZ, 0, 0), angle);
            }   
        }
        // For blue side
        if(patternB) {
            // Setting 3 red cups on top and 2 red cups at side (Yellow)
            // Side
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(GreenCup, firstCupCoordsB1 + new Vector3(0, 0, -i*shiftZ), angle);
                else
                    Instantiate(RedCup, firstCupCoordsB1 + new Vector3(0, 0, -i*shiftZ), angle);
            } 
            // Top
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(RedCup, firstCupCoordsB2 + new Vector3(-i*shiftZ, 0, 0), angle);
                else
                    Instantiate(GreenCup, firstCupCoordsB2 + new Vector3(-i*shiftZ, 0, 0), angle);
            } 
        } else {
            //Setting 3 green cups on top and 2 green cups at side (Yellow)
            // Side
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(RedCup, firstCupCoordsB1 + new Vector3(0, 0, -i*shiftZ), angle);
                else
                    Instantiate(GreenCup, firstCupCoordsB1 + new Vector3(0, 0, -i*shiftZ), angle);
            }
            // Top
            for (int i = 0; i < 5; i++)
            {
                if(i%2 == 0)
                    Instantiate(GreenCup, firstCupCoordsB2 + new Vector3(-i*shiftZ, 0, 0), angle);
                else
                    Instantiate(RedCup, firstCupCoordsB2 + new Vector3(-i*shiftZ, 0, 0), angle);
            }   
        }
        
    }
}
