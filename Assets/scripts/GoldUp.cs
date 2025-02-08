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
        Destroy(this.gameObject);
    }
}
