using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobileMenuController : MonoBehaviour
{
    public GameObject MainMenucanvas;
    public GameObject SchoolMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        MainMenucanvas.SetActive(true);
        SchoolMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {


                if (raycastHit.collider.name == "School")
                {
                    MainMenucanvas.SetActive(false);
                    SchoolMenuCanvas.SetActive(true);
                    Debug.Log("HIT");
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "School")
                {
                    MainMenucanvas.SetActive(false);
                    SchoolMenuCanvas.SetActive(true);
                    Debug.Log("HIT");

                }
            }
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
