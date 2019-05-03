using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChange : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Button;
    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }

      IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = Panel.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;

        if(Panel!=null)
        Panel.SetActive(false);

        if(Button!=null)
        Button.SetActive(false);

        yield return null;
    }

}
