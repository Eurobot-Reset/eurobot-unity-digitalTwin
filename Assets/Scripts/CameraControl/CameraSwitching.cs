using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public GameObject cameraMain;
    public GameObject cameraThirdPersonFatboy;
    public GameObject cameraThirdPersonRacer;
    public GameObject cameraTop;
    public int CameraNumber = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            CameraNumber = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            CameraNumber = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            CameraNumber = 3;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            CameraNumber = 4;
        }

        CameraViewChange(CameraNumber);
    }

    void CameraViewChange(int counter)
    {

        switch (counter)
        {
        case 1:
            cameraMain.SetActive(true);
            cameraThirdPersonFatboy.SetActive(false);
            cameraThirdPersonRacer.SetActive(false);
            cameraTop.SetActive(false);
            break;

        case 2:
            cameraMain.SetActive(false);
            cameraThirdPersonFatboy.SetActive(true);
            cameraThirdPersonRacer.SetActive(false);
            cameraTop.SetActive(false);
            break;
            
        case 3:
            cameraMain.SetActive(false);
            cameraThirdPersonFatboy.SetActive(false);
            cameraThirdPersonRacer.SetActive(true);
            cameraTop.SetActive(false);
            break;

        case 4:
            cameraMain.SetActive(false);
            cameraThirdPersonFatboy.SetActive(false);
            cameraThirdPersonRacer.SetActive(false);
            cameraTop.SetActive(true);
            break;

        }

    }
}
