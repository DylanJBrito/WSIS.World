using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelHover : MonoBehaviour
{
    public GameObject Panel;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = Panel.GetComponent<Animator>();

    }



    
    void OnMouseOver()
    {
        anim.Play("TitleZoom");
    }

    void OnMouseExit()
    {
        anim.Play("TitleIdle");
    }

    void OnMouseDown()
    {

    }

   
    
}
