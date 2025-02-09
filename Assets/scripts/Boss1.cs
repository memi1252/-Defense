using System;
using UnityEngine;

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
        road(GameManager.Instance.stage2MapPos2);
    }

    public override void Die()
    {
        UIManger.Instance.clearUI.Show();
        base.Die();
    }
}
