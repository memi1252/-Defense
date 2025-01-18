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
        if(transform.position ==GameManager.Instance.MapPos2[GameManager.Instance.MapPos2.Length - 1].position)
        {
            GameManager.Instance.protecthealth -= 2;
            Destroy(gameObject);
        }
        road(GameManager.Instance.MapPos2);
        SpeedUpTimer();
    }
    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(Enemy1Prefab, transform.position+ pos, Quaternion.identity);
        pos = new Vector3(0, 0, pos.z + 0.5f);
        count--;
        on = true;
    }
    
}
