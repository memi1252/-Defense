using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mianMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button closebutton;
    [SerializeField] private GameObject helpPanel;

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            Debug.Log("startButton");
            GameManager.Instance.playTime = 0;
            Time.timeScale = 1;
            GameManager.Instance.gold = 20;
            GameManager.Instance.protecthealth = 10;
            SceneManager.LoadScene("stage1");
        });
        exitButton.onClick.AddListener(() =>
        {
            Debug.Log("exitButton");
            Application.Quit();
        });
        helpButton.onClick.AddListener(() =>
        {
            Debug.Log("helpButton");
            helpPanel.SetActive(true);
        });
        closebutton.onClick.AddListener(() =>
        {
            Debug.Log("closebutton");
            helpPanel.SetActive(false);
        });
    }
}
