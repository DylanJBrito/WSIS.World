using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelHandler : MonoBehaviour
{
    public GameObject StatsPanel;
    public GameObject RankPanel;
    // Start is called before the first frame update
    void Start()
    {
        StatsPanel.SetActive(true);
        RankPanel.SetActive(false);
    }

    public void OnRankBtn()
    {
        StatsPanel.SetActive(false);
        RankPanel.SetActive(true);
    }

    public void OnStatsBtn()
    {
        StatsPanel.SetActive(true);
        RankPanel.SetActive(false);
    }


}
