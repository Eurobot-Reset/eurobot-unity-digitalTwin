using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gripper : MonoBehaviour
{
    public bool go_down = false;
    public bool go_up = false;

    public float velocity = 4.0f;
    public float y_gripper_down = 6.4f;
    public float y_gripper_up = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go_down)
       {
           if (transform.position.y > y_gripper_down)
           {
               transform.position -= transform.up * Time.deltaTime * velocity;
           }
           else
           {
               go_down = false;
	   }
       }

       if ((go_up) && (!(go_down)))
       {
           if (transform.position.y < y_gripper_up)
           {
               transform.position += transform.up * Time.deltaTime * velocity;
           }
           else
           {
               go_up = false;
           } 
       }
    }
}
