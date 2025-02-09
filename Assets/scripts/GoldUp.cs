using System;
using UnityEngine;

public class GoldUp : itemBase
{
    private void Update()
    {
        click("GoldUp");
    }
    
    public override void item()
    {
        Debug.Log("GoldUp");
        GameManager.Instance.GoldUp = true;
        SoundManager.Instance.coinSource.Play();
        UIManger.Instance.statsUI.goldUpImage.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
