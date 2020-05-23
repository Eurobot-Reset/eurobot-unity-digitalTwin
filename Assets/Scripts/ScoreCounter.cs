using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public GameObject[] green_cups;
    public GameObject[] red_cups;
    public float x_position;
    public float y_position;
    // Start is called before the first frame update
    void Start()
    {
        green_cups = GameObject.FindGameObjectsWithTag("GreenCups");
        red_cups = GameObject.FindGameObjectsWithTag("RedCups");
            
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject cup in green_cups)
        {
            x_position = cup.transform.position.x;
            y_position = cup.transform.position.y;
        }
    }
}
