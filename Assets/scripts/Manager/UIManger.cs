using System;
using UnityEngine;

public class UIManger : MonoSingleton<UIManger>
{
    [SerializeField] public arrangementUI arrangementUI;
    [SerializeField] public StatsUI statsUI;
    [SerializeField] public GoldUpUI goldUpUI;
    [SerializeField] public shopUI shopUI;
    [SerializeField] public clearUI clearUI;

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
        if(shopUI == null)
            shopUI = GameObject.Find("Canvas").transform.Find("shopUI").gameObject
                .GetComponent<shopUI>();
        if(clearUI == null)
            clearUI = GameObject.Find("Canvas").transform.Find("clearUI").gameObject
                .GetComponent<clearUI>();
    }
}
