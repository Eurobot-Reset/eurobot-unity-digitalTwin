using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public static bool isNorth = false;
    public int rotationCount = 3;
    public int speed = 5;

    private float angle = 0;
    private bool stop;
    // Start is called before the first frame update
    void Start()
    {
        isNorth = (Random.value > 0.5f);
        stop = false;
        if(isNorth)
            tableStateHandler.weathervaneStatus = "N";
        else
            tableStateHandler.weathervaneStatus = "S";
    }

    // Update is called once per frame
    void Update()
    {     
        if (!stop){
            float deltaAngle = speed * Time.deltaTime;
            transform.Rotate(deltaAngle, 0, 0);
            angle += deltaAngle;
        }

        int Rotations = (int)(angle / 360.0f);
        
        if (Rotations >= rotationCount && isNorth)
            stop = true;
        else if (!isNorth && Rotations >= rotationCount && transform.rotation.eulerAngles.x >= 180f)
            stop = true;
    }
}
