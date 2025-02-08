using System;
using UnityEngine;

public class UIManger : MonoSingleton<UIManger>
{
    [SerializeField] public arrangementUI arrangementUI;
    [SerializeField] public StatsUI statsUI;
    [SerializeField] public GoldUpUI goldUpUI;

    private void Update()
    {
        if (arrangementUI == null)
            arrangementUI = GameObject.Find("Canvas").transform.Find("arrangementUI").gameObject
                .GetComponent<arrangementUI>();
        if(statsUI == null)
            statsUI = FindObjectOfType<StatsUI>();
        if(goldUpUI == null)
            goldUpUI = GameObject.Find("Canvas").transform.Find("GoldUP").gameObject
                .GetComponent<GoldUpUI>();
    }
}
