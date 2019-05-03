using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SchoolMenuManager : MonoBehaviour
{
    public GameObject Main_cam;
    private GameObject MainMenuCanvas;
    public GameObject SchoolCanvas;
    public GameObject AnimSchoolCam;
    private Animator anim;

    void Start()
    {

        MainMenuCanvas = GameObject.Find("Labels");
        anim = AnimSchoolCam.GetComponent<Animator>();
    }


    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }


    public void Inside()
    {
         Main_cam.SetActive(false);
        AnimSchoolCam.SetActive(true);
        //MainMenuCanvas.SetActive(false);
        //SchoolCanvas.SetActive(false);
        anim.Play("SchoolCamZoom");
        StartCoroutine(NextScene());

    }


    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("School_Scene");
    }
}
