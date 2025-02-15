using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : UIBase
{
    [SerializeField] private TextMeshProUGUI playTimeText;
    [SerializeField] private TextMeshProUGUI enemyKillText;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        Hide();
        mainMenuButton.onClick.AddListener(() =>
        {
            Debug.Log("MainMenuButton");
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.stage2 = false;
            GameManager.Instance.gold = 20;
            GameManager.Instance.protecthealth = 10;
            GameManager.Instance.EnemyList.Clear();
            SceneManager.LoadScene("MainLobby");
        });
        restartButton.onClick.AddListener(() =>
        {
            Debug.Log("RestartButton");
            GameManager.Instance.playTime = 0;
            Time.timeScale = 1;
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.gold = 20;
            GameManager.Instance.protecthealth = 10;
            GameManager.Instance.EnemyList.Clear();
            if(SceneManager.GetActiveScene().name == "stage1")
            {
                SceneManager.LoadScene("stage1");
            }
            else if(SceneManager.GetActiveScene().name == "stage2")
            {
                SceneManager.LoadScene("stage2");
            }
        });
    }

    private void Update()
    {
        playTimeText.text = $"Play Time: {GameManager.Instance.playTime:F2}";
        enemyKillText.text = $"Enemy Kill: {GameManager.Instance.enemyKill}kill";
    }
}
