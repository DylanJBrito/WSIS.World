using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileArrowHandler : MonoBehaviour
{
    public GameObject[] Views;
    // Start is called before the first frame update
    void Start()
    {
        Views[0].SetActive(true);
        Views[1].SetActive(false);
        Views[2].SetActive(false);
        Views[3].SetActive(false);
    }

    public void ClickRight()
    {
        Views[0].SetActive(false);
        Views[1].SetActive(true);
        Views[2].SetActive(false);
        Views[3].SetActive(false);
    }

    public void ClickTop()
    {
        Views[0].SetActive(false);
        Views[1].SetActive(false);
        Views[2].SetActive(true);
        Views[3].SetActive(false);
    }

    public void ClickLeft()
    {
        Views[0].SetActive(false);
        Views[1].SetActive(false);
        Views[2].SetActive(false);
        Views[3].SetActive(true);
    }

    public void ClickBottom()
    {
        Views[0].SetActive(true);
        Views[1].SetActive(false);
        Views[2].SetActive(false);
        Views[3].SetActive(false);
    }

 
}
