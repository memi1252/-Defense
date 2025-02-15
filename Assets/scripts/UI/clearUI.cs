using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clearUI : UIBase
{
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button NextButton;
    
    private void Awake()
    {
        Hide();
        MainMenuButton.onClick.AddListener(() =>
        {
            Debug.Log("MainMenuButton");
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.stage2 = false;
            GameManager.Instance.gold = 20;
            GameManager.Instance.protecthealth = 10;
            GameManager.Instance.EnemyList.Clear();
            SceneManager.LoadScene("MainLobby");
        });
        NextButton.onClick.AddListener(() =>
        {
            Debug.Log("NextButton");
            GameManager.Instance.playTime = 0;
            Time.timeScale = 1;
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.gold = 20;
            GameManager.Instance.protecthealth = 10;
            GameManager.Instance.stage2 = true;
            GameManager.Instance.EnemyList.Clear();
            SceneManager.LoadScene("stage2");
        });
    }
}
