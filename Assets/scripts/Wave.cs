using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Wave : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] boss;
    [SerializeField] private Transform spawnPoints;
    [SerializeField] private int waveCount = 5;
    [SerializeField] private int enemyCount = 3;
    [SerializeField] public float[] waveTime;
    [SerializeField] public int hpPlus = 0;

    public bool isWave = false;
    public int waveIndex = 0;
    private bool isboss;
    private Coroutine waveCoroutine;

    private void Start()
    {
        waveCoroutine = StartCoroutine(waveStart());
    }

    public IEnumerator waveStart()
    {
        if (waveIndex == waveCount)
        {
            yield break;
        }
        if (waveIndex == waveCount - 1)
        {
            isWave = true;
            Instantiate(boss[0], spawnPoints.position, Quaternion.Euler(0, 0, 90));
            yield return new WaitForSeconds(waveTime[waveIndex]);
        }
        else
        {
            
            for (int j = 0; j < enemyCount; j++)
            {
                isWave = true;
                int enemyIndex = Random.Range(0, enemies.Length);

                var enemy = Instantiate(enemies[enemyIndex], spawnPoints.position, Quaternion.Euler(0, 0, 90));
                GameManager.Instance.EnemyList.Add(enemy);
                enemy.GetComponent<EnemyBase>().health += hpPlus;
                if (enemyIndex == 0)
                {
                    enemy.GetComponent<Enemy1>().on = true;
                }

                if (Time.timeScale == 1)
                {
                    yield return new WaitForSeconds(1f);
                }else if (Time.timeScale == 2)
                {
                    yield return new WaitForSeconds(0.5f);
                }
                
            }

            if (GameManager.Instance.stage2)
            {
                enemyCount += Random.Range(6, 12);
                hpPlus += 7;
            }
            else
            {
                enemyCount += Random.Range(5, 9);
                hpPlus += 4;
            }
            yield return new WaitForSeconds(waveTime[waveIndex]);
        }
    }

    private void Update()
    {
        if (isWave)
        {
            waveTime[waveIndex] -= Time.deltaTime;
            if (waveTime[waveIndex] <= 0)
            {
                waveIndex++;
                waveCoroutine = StartCoroutine(waveStart());
            }
        }
    }

    public void SkipToNextWave()
    {
        if (waveIndex >= waveCount - 1) 
        {
            Debug.Log("Cannot skip the last wave");
            return;
        }

        if (waveCoroutine != null)
        {
            StopCoroutine(waveCoroutine);
        }
        waveIndex++;
        waveCoroutine = StartCoroutine(waveStart());
    }
}