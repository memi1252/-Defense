using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shopUI : UIBase
{
    [SerializeField] private GameObject GoldUp;
    [SerializeField] private GameObject allDamage;
    [SerializeField] private GameObject heal;
    [SerializeField] private GameObject stop;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private int count =1;
    [SerializeField] private int price;
    [SerializeField] private GameObject pung;
    
    private void Awake()
    {
        Hide();
        buyButton.onClick.AddListener(() =>
        {
            if(GameManager.Instance.gold >= price && GameManager.Instance.itemconut < 3 && count < 4)
            {
                GameManager.Instance.gold -= price;
                GameManager.Instance.itemconut++;
                int index = UnityEngine.Random.Range(0, 4);
                count++;
                switch (index)
                {
                    case 0:
                        GameManager.Instance.GoldUp = true;
                        SoundManager.Instance.coinSource.Play();
                        UIManger.Instance.statsUI.goldUpImage.gameObject.SetActive(true);
                        GoldUp.SetActive(true);
                        UIManger.Instance.goldUpUI.timer = 0;
                        break;
                    case 1:
                        if(GameManager.Instance.protecthealth < 99)
                        { 
                            GameManager.Instance.protecthealth += 1;
                        }
                        else if(GameManager.Instance.protecthealth < 98)
                        {
                            GameManager.Instance.protecthealth += 2;
                        }else if(GameManager.Instance.protecthealth < 97)
                        {
                            GameManager.Instance.protecthealth += 3;
                        }
                        UIManger.Instance.statsUI.healthImage.gameObject.SetActive(true);
                        heal.SetActive(true);
                        break;
                    case 2:
                        foreach (var enemy in GameManager.Instance.EnemyList)
                        {
                            enemy.GetComponent<EnemyBase>().health /= 2;
                        }
                        Instantiate(pung, new Vector3(0,0,0), Quaternion.identity);
                        SoundManager.Instance.pungSource.Play();
                        UIManger.Instance.statsUI.allDamageImage.gameObject.SetActive(true);
                        allDamage.SetActive(true);
                        break;
                    case 3:
                        GameManager.Instance.speedStop = true;
                        UIManger.Instance.statsUI.EnemySpeedImage.gameObject.SetActive(true);
                        stop.SetActive(true);
                        break;
                }
            }
        });
        closeButton.onClick.AddListener(() =>
        {
            Camera.main.GetComponent<Physics2DRaycaster>().enabled = true;
            Hide();
        });
    }

    private void Update()
    {
        if (count == 1)
        {
            price = 10;
        }
        else if (count == 2)
        {
            price = 15;
        }
        else if (count == 3)
        {
            price = 20;
        }
        else if (count == 4)
        {
            buyButton.interactable = false;
        }
    }
}
