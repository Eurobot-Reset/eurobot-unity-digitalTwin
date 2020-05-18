using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_gripper_main_robot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cups" && collision.impulse.magnitude > 0.01)
        {
            Destroy(collision.gameObject);

            //collision.gameObject.transform.position = new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));

        }

    }


}
