using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;

    private int index;
    private int spawnTimer = 5;

    private void Awake()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        
        index = Random.Range(0, enemyPrefab.Length);
        var Enemy = Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
        if (index == 0)
        {
            Enemy.GetComponent<Enemy1>().on = true;
            spawnTimer = 5;
        }else if(index == 1)
        {
            spawnTimer = 8;
        }
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(spawnEnemy());
    }
    
}
