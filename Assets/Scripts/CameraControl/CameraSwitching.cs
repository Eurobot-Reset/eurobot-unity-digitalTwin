using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public Camera cameraRacer;
    public Camera cameraFatboy;
    public Camera cameraThirdPersonFatboy;
    public Camera cameraThirdPersonRacer;
    public Camera cameraTop;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameMode.robot[0]) {
            cameraRacer.enabled = true;
            cameraFatboy.enabled = false;
            cameraThirdPersonFatboy.enabled = false;
            cameraThirdPersonRacer.enabled = false;
            cameraTop.enabled = false;
        } else {
            cameraRacer.enabled = false;
            cameraFatboy.enabled = true;
            cameraThirdPersonFatboy.enabled = false;
            cameraThirdPersonRacer.enabled = false;
            cameraTop.enabled = false;
        }
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {     
            cameraRacer.enabled = true;
            cameraFatboy.enabled = false;
            cameraThirdPersonFatboy.enabled = false;
            cameraThirdPersonRacer.enabled = false;
            cameraTop.enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            cameraRacer.enabled = false;
            cameraFatboy.enabled = true;
            cameraThirdPersonFatboy.enabled = false;
            cameraThirdPersonRacer.enabled = false;
            cameraTop.enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            cameraRacer.enabled = false;
            cameraFatboy.enabled = false;
            cameraThirdPersonFatboy.enabled = true;
            cameraThirdPersonRacer.enabled = false;
            cameraTop.enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            cameraRacer.enabled = false;
            cameraFatboy.enabled = false;
            cameraThirdPersonFatboy.enabled = false;
            cameraThirdPersonRacer.enabled = true;
            cameraTop.enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            cameraRacer.enabled = false;
            cameraFatboy.enabled = false;
            cameraThirdPersonFatboy.enabled = false;
            cameraThirdPersonRacer.enabled = false;
            cameraTop.enabled = true;
        }
    }
}
