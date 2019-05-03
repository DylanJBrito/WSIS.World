//Attach this script to a GameObject
//This script checks what device type the Application is running on and outputs this to the console

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeviceTypeExample : MonoBehaviour
{
    public Text deviceTypeText;
    //This is the Text for the Label at the top of the screen
    string m_DeviceType;

    void Update()
    {
        //Output the device type to the console window
       // Debug.Log("Device type : " + m_DeviceType);

        //Check if the device running this is a console
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            //Change the text of the label
            m_DeviceType = "Console";
            deviceTypeText.text = "Operating on a console";
        }

        //Check if the device running this is a desktop
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            m_DeviceType = "Desktop";
            deviceTypeText.text = "Operating on a desktop";
            SceneManager.LoadScene("Main_Scene");

        }

        //Check if the device running this is a handheld
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_DeviceType = "Handheld";
            deviceTypeText.text = "Operating on a handheld";
            SceneManager.LoadScene("Mobile_Scene");
        }

        //Check if the device running this is unknown
        if (SystemInfo.deviceType == DeviceType.Unknown)
        {
            m_DeviceType = "Unknown";
            deviceTypeText.text = "Operating on an unknown device";
            SceneManager.LoadScene("Mobile_Scene");
        }
    }
}