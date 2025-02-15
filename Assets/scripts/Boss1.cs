using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : EnemyBase
{
    private void Awake()
    {
        defaultSpeed = speed;
    }

    private void Update()
    {
        SpeedUpTimer();
        if(health <= 0)
        {
            Die();
        }
        if(SceneManager.GetActiveScene().name == "stage1")
        {
            road(GameManager.Instance.MapPos2);
        }
        else if(SceneManager.GetActiveScene().name == "stage2")
        {
            road(GameManager.Instance.stage2MapPos2);
        }
    }

    public override void Die()
    {
        UIManger.Instance.clearUI.Show();
        base.Die();
    }
}
