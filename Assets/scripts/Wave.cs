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

    public bool isWave = false;
    public int waveIndex = 0;
    private bool isboss;
    private Coroutine waveCoroutine;

    private void Start()
    {
        waveCoroutine = StartCoroutine(waveStart());
    }

    IEnumerator waveStart()
    {
        if (waveIndex == waveCount - 1) // Check if it's the last wave
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
                if (enemyIndex == 0)
                {
                    enemy.GetComponent<Enemy1>().on = true;
                }
                yield return new WaitForSeconds(1f);
            }

            if (GameManager.Instance.stage2)
            {
                enemyCount += Random.Range(4, 8);
            }
            else
            {
                enemyCount += Random.Range(2, 4);
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