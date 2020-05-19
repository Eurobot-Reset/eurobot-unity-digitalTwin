using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public GameObject cameraMain;
    public GameObject cameraThirdPerson;
    public GameObject cameraFront;
    public int CameraNumber = 2;
    
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

        CameraViewChange(CameraNumber);
    }

    void CameraViewChange(int counter)
    {

        switch (counter)
        {
        case 1:
            cameraMain.SetActive(true);
            cameraThirdPerson.SetActive(false);
            cameraFront.SetActive(false);
            break;

        case 2:
            cameraMain.SetActive(false);
            cameraThirdPerson.SetActive(true);
            cameraFront.SetActive(false);
            break;
            
        case 3:
            cameraMain.SetActive(false);
            cameraThirdPerson.SetActive(false);
            cameraFront.SetActive(true);
            break;

        }

    }
}
