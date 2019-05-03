using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Details : MonoBehaviour
{

    public GameObject DetailCanvas;
    public Text ClassLabel;
    public Text GameExplain;
    public GameObject exitMenu;
    public Text Level;
    public Text Score;
    public Text Questions;

  

    // Start is called before the first frame update
    void Start()
    {
        DetailCanvas.SetActive(false);
        exitMenu.SetActive(false);
    }

    private void Update()
    {
        if (DetailCanvas.activeInHierarchy && ClassLabel.text == "Geography 1")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Game_Scene");               
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitMenu.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Geography1")
        {
            DetailCanvas.SetActive(true);
            ClassLabel.text = "Geography 1";
            GameExplain.text = "Game: Match the national flag to its country. ";

            if(PlayerPrefs.HasKey("Score"))
            {
                Score.text = "Highscore: " + PlayerPrefs.GetInt("Score").ToString();
            }

            if (PlayerPrefs.HasKey("Level"))
            {
                Level.text = "Current level: " + PlayerPrefs.GetString("Level").ToString();
            }

            if (PlayerPrefs.HasKey("Total"))
            {
                Questions.text = "Questions Done: " + PlayerPrefs.GetInt("Total").ToString();
            }

        }
        else
            if(other.tag == "Geography2")
        {
            DetailCanvas.SetActive(true);
            ClassLabel.text = "Geography 2";
            GameExplain.text = "Game: Match the country to its position on the map template. ";
        }
    }

    void OnTriggerExit(Collider other)
    {
        DetailCanvas.SetActive(false);
    }

    public void exitButtons(string buttonName)
    {
        if(buttonName == "yes")
        {
            SceneManager.LoadScene("Home_scene");
        }
        else
        if(buttonName == "no")
        {
            exitMenu.SetActive(false);
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }


}
