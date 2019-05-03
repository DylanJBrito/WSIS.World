using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamMenu : MonoBehaviour
{

    public Transform currentMount;
    public float speedFactor = 0.3f;
    public float zoomFactor = 1.0f;
    public Camera cameraComp;
    private Vector3 lastPosition;
    public Transform schoolCam;
    public GameObject Labels;
    private GameObject SchoolCanvas;
    public Transform BirdCamPos;
    public GameObject MainCamera;
    public GameObject Button;
    public GameObject ComingSoonPanel;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
       
 
        Labels.SetActive(true);
        SchoolCanvas = GameObject.Find("SchoolCanvas");
        SchoolCanvas.SetActive(false);
        ComingSoonPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {


            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit) && !SchoolCanvas.activeInHierarchy)
                {
                if (hit.transform.name == "SchoolHover")
                {
                    currentMount = schoolCam;


                    if (Labels != null & SchoolCanvas != null)
                    {

                        Labels.SetActive(false);
                        SchoolCanvas.SetActive(true);
                    }

                }
                else
                if (hit.transform.CompareTag("ComingSoon"))
                {
                    ComingSoonPanel.SetActive(true);
                }
                   
                }
            }

        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);

        float velocity = Vector3.Magnitude(transform.position - lastPosition);
        cameraComp.fieldOfView = 60 + velocity * zoomFactor;

        lastPosition = transform.position;

    }

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void setMount(Transform newMount)
    {
        currentMount = newMount;
    }

    public void close()
    {
        ComingSoonPanel.SetActive(false);
    }

   
}
