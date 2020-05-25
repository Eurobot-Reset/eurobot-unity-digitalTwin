using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    public float ZoomSpeed = 200;
    public float speed=20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            // transform.localPosition -= new Vector3(Input.GetAxisRaw("Mouse ScrollWheel") * Time.deltaTime * ZoomSpeed, 0, 0);
            transform.position += transform.TransformDirection (0, 0, Input.GetAxisRaw("Mouse ScrollWheel") * Time.deltaTime * ZoomSpeed);
        }
        
    }
}

