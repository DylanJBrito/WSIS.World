using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolTrigger : MonoBehaviour
{
    public GameObject AnimSchoolCam;
    public GameObject InsideSchoolCam;
    public GameObject DetailsCanvas;


    // Start is called before the first frame update
    void Start()
    {
        InsideSchoolCam.SetActive(false);
        DetailsCanvas.SetActive(false);
       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AnimSchoolCam.SetActive(false);
            InsideSchoolCam.SetActive(true);
            
        }

    }
}
