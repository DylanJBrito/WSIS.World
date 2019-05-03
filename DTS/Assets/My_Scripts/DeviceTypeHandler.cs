using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeviceTypeHandler : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject WaitPanel;
    // Start is called before the first frame update
    void Start()
    {

        OptionsPanel.SetActive(true);
        WaitPanel.SetActive(false);
    }

    public void ChangeScene(string SceneName)
    {
        OptionsPanel.SetActive(false);
        WaitPanel.SetActive(true);
        SceneManager.LoadScene(SceneName);
    }

}
