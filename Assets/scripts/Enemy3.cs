using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy3 : EnemyBase
{
    [SerializeField] private GameObject[] items;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health <= 0)
        {
            //int index = Random.Range(0, items.Length);
            //Instantiate(items[index], transform.position, Quaternion.identity);
            Die();
        }
    }

    private void Update()
    {
        if (GameManager.Instance.stage2)
        {
            road(GameManager.Instance.stage2MapPos1);
        }
        else
        {
            road(GameManager.Instance.MapPos1);
        }
        SpeedUpTimer();
        if(health <= 0)
        {
            Die();
        }
    }
}

