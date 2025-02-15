using System;
using UnityEngine;

public class heal : itemBase
{
    private void Update()
    {
        click("heal");
    }
    
    public override void item()
    {
        Debug.Log("Heal");
        if(GameManager.Instance.protecthealth == 9)
        { 
            GameManager.Instance.protecthealth += 1;
        }
        else if(GameManager.Instance.protecthealth == 8)
        {
            GameManager.Instance.protecthealth += 2;
        }else if(GameManager.Instance.protecthealth <= 7)
        {
            GameManager.Instance.protecthealth += 3;
        }
        UIManger.Instance.statsUI.healthImage.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
