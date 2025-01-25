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
        road(GameManager.Instance.MapPos1);
        if(transform.position == GameManager.Instance.MapPos1[GameManager.Instance.MapPos1.Length - 1].position)
        {
            GameManager.Instance.protecthealth -= 1;
            Destroy(gameObject);
        }
        SpeedUpTimer();
    }
}

