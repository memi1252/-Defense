using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] public GameObject Map;
    [SerializeField] public Transform[] MapPos1;
    [SerializeField] public Transform[] MapPos2;
    [SerializeField] public Transform[] stage2MapPos1;
    [SerializeField] public Transform[] stage2MapPos2;
    
    [SerializeField] public Wave wave;
    
    
    public List<GameObject> EnemyList = new List<GameObject>();
    public int gold = 0;
    public int protecthealth = 10;
    public int itemconut = 0;
    public bool GoldUp = false;
    public bool speedStop = false;
    public bool allDamage = false;
    
    public bool stage2 = false;
    
    public bool isItemCoolTime = false;
    public float itemCoolTime = 5;
    public float itemCoolTimer;


    private int speedStoptime = 10;
    private float speedStopTimer;

    public float playTime;
    public int enemyKill;
    

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(Map);
    }


    private void Update()
    {
        if (isItemCoolTime)
        {
            itemCoolTimer += Time.deltaTime;
            if (itemCoolTimer >= itemCoolTime)
            {
                isItemCoolTime = false;
                itemCoolTimer = 0;
            }
        }
        
        if(wave == null)
        {
            wave = FindObjectOfType<Wave>();
        }
        
        if (GoldUp)
        {
            UIManger.Instance.goldUpUI.Show();
            foreach (var enemy in EnemyList)
            {
                if (!enemy.GetComponent<EnemyBase>().goldUp)
                {
                    enemy.GetComponent<EnemyBase>().gold *= 2;
                    enemy.GetComponent<EnemyBase>().goldUp = true;
                }
            }
        }else if (!GoldUp && SceneManager.GetActiveScene().name != "MainLobby")
        {
            foreach (var enemy in EnemyList)
            {
                if (enemy.GetComponent<EnemyBase>().goldUp)
                {
                    enemy.GetComponent<EnemyBase>().gold /= 2;
                    enemy.GetComponent<EnemyBase>().goldUp = false;
                    UIManger.Instance.statsUI.goldUpImage.gameObject.SetActive(false);
                    itemconut--;
                    UIManger.Instance.goldUpUI.Hide();
                    
                }
            }
        }
        
        if(speedStop)
        {
            speedStopTimer += Time.deltaTime;
            foreach (var enemy in EnemyList)
            {
                enemy.GetComponent<EnemyBase>().speed = 0;
            }
            if (speedStopTimer >= speedStoptime)
            {
                speedStop = false;
                speedStopTimer = 0;
                itemconut--;
                foreach (var enemy in EnemyList)
                {
                    enemy.GetComponent<EnemyBase>().speed = enemy.GetComponent<EnemyBase>().defaultSpeed;
                    UIManger.Instance.statsUI.EnemySpeedImage.gameObject.SetActive(false);
                    itemconut--;
                }
            }
        }
        
        if(allDamage)
        {
            foreach (var enemy in EnemyList)
            {
                if(!enemy.GetComponent<EnemyBase>().allDemage)
                {
                    enemy.GetComponent<EnemyBase>().health /= 2;
                    enemy.GetComponent<EnemyBase>().allDemage = true;
                    StartCoroutine(allDamageImageHide());
                }
            }
        }
        
       
        playTime += Time.deltaTime;
        
        
        if(protecthealth <= 0)
        {
            UIManger.Instance.gameOverUI.Show();
            Time.timeScale = 0;
        }

        if (SceneManager.GetActiveScene().name == "MainLobby")
        {
            UIManger.Instance.gameOverUI.Hide();
        }
        
        if(UIManger.Instance.statsUI.healthImage.gameObject.activeSelf)
        {
            StartCoroutine(healthImageHide());
        }
    }
    
    IEnumerator allDamageImageHide()
    {
        yield return new WaitForSeconds(3);
        allDamage = false;
        itemconut--;
        UIManger.Instance.statsUI.allDamageImage.gameObject.SetActive(false);
    }

    IEnumerator healthImageHide()
    {
        yield return new WaitForSeconds(3);
        itemconut--;
        UIManger.Instance.statsUI.healthImage.gameObject.SetActive(false);
    }
    
}
