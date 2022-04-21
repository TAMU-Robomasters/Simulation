using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraSwitch : MonoBehaviour
{
    public bool CameraActive = false;
    public GameObject TopDownCamera;
    public GameObject POVCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Checks if user has inputed they want to switch cameras to top down
        if(Input.GetButtonDown("Jump")) {
            CameraActive = !CameraActive;
        }
        
        //switches between the top down and pov camera
        if(CameraActive){
            POVCamera.SetActive(false);            
            TopDownCamera.SetActive(true);
        }
        else{
            TopDownCamera.SetActive(false);
            POVCamera.SetActive(true);
        }
    }
}
