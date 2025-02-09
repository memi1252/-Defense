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
            SceneManager.LoadScene("MainLobby");
        });
        NextButton.onClick.AddListener(() =>
        {
            Debug.Log("NextButton");
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.stage2 = true;
            SceneManager.LoadScene("stage2");
        });
    }
}
