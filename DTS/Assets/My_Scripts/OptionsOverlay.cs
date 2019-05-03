using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsOverlay : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject InformationPanel;
    public GameObject SettingPanel;
    private Animator anim;

    public void On_OptionsBtn_Press(string ButtonName)
    {

        if(ButtonName == "LoginBtn")
        {
            anim = LoginPanel.GetComponent<Animator>();
        }     
        else
        if(ButtonName == "InformationBtn")
        {
            anim = InformationPanel.GetComponent<Animator>();
        }           
        else
        if(ButtonName == "SettingBtn")
        {
            anim = SettingPanel.GetComponent<Animator>();
        }
            
        if(ButtonName == "BackBtn")
        anim.Play("OverLayBack");
        else
        anim.Play("OptionsOverlay");
    }




}
