using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy1 : EnemyBase{
    [SerializeField] private GameObject Enemy1Prefab;
    [SerializeField] private int count;
    [SerializeField] public bool on = false;
    [SerializeField] private Vector3 pos;
    private void Awake()
    {
        count = Random.Range(3, 5);
        defaultSpeed = speed;
        
    }
    private void Update()
    {
        if (count > 0 && on)
        {
            StartCoroutine(spawnEnemy());
            on = false;
        }

        if (GameManager.Instance.stage2)
        {
            road(GameManager.Instance.stage2MapPos2);
        }
        else
        {
            road(GameManager.Instance.MapPos2);
        }
        SpeedUpTimer();
        if(health <= 0)
        {
            Die();
        }
    }
    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(0.2f);
        var enemy = Instantiate(Enemy1Prefab, transform.position+ pos, Quaternion.Euler(0, 0, 90));
        GameManager.Instance.EnemyList.Add(enemy);
        pos = new Vector3(0, 0, pos.z + 0.5f);
        count--;
        on = true;
    }
    
}
