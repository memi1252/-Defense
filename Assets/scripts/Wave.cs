using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wave : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform spawnPoints;
    [SerializeField] private int waveCount = 5;
    [SerializeField] private int enemyCount= 2;
    [SerializeField] public float[] waveTime;
    
    public bool isWave = false;
    public int waveIndex = 0;
    
    private void Start()
    {
        StartCoroutine(waveStart());
    }

    IEnumerator waveStart()
    {
        for (int i = 0; i < waveCount; i++)
        {
            for (int j = 0; j < enemyCount; j++)
            {
                isWave = true;
                int enemyIndex = Random.Range(0, enemies.Length);
                
                var enemy = Instantiate(enemies[enemyIndex], spawnPoints.position, Quaternion.identity);
                if(enemyIndex == 0)
                {
                    enemy.GetComponent<Enemy1>().on = true;
                }
                yield return new WaitForSeconds(1f); 
            }
            
            yield return new WaitForSeconds(waveTime[i]);
            enemyCount += Random.Range(2, 4);
        }
    }

    private void Update()
    {
        if(waveIndex == waveCount)
        {
            isWave = false;
            Debug.Log("Game Clear");
        }
        if (isWave)
        {
            waveTime[waveIndex] -= Time.deltaTime;
            if (waveTime[waveIndex] <= 0)
            {
                UIManger.Instance.statsUI.WaveText.text = "Clear";
                waveIndex++;
                isWave = false;
            }
        }
    }
}
