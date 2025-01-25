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
        if(GameManager.Instance.protecthealth < 99)
        { 
            GameManager.Instance.protecthealth += 1;
        }
        else if(GameManager.Instance.protecthealth < 98)
        {
            GameManager.Instance.protecthealth += 2;
        }else if(GameManager.Instance.protecthealth < 97)
        {
            GameManager.Instance.protecthealth += 3;
        }
        Destroy(gameObject);
    }
}
