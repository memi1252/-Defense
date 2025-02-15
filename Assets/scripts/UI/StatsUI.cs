using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatsUI : UIBase
{
    [SerializeField] private TextMeshProUGUI GoldText;
    [SerializeField] public TextMeshProUGUI WaveText;
    [SerializeField] public TextMeshProUGUI protecthealthText;
    [SerializeField] private TextMeshProUGUI x1Text;
    [SerializeField] public Button x1;
    [SerializeField] private Button nextWaveButton;
    [SerializeField] private Button shopButton;
    [SerializeField] public Image goldUpImage;
    [SerializeField] public Image allDamageImage;
    [SerializeField] public Image EnemySpeedImage;
    [SerializeField] public Image healthImage;

    private void Awake()
    {
        x1.onClick.AddListener(() =>
        {
            if(x1Text.text == "x1")
            {
                Time.timeScale = 4f;
                x1Text.text = "x2";
            }else if (x1Text.text == "x2")
            {
                Time.timeScale = 1f;
                x1Text.text = "x1";
            }
        });
        nextWaveButton.onClick.AddListener(()=>
        {
            GameManager.Instance.wave.SkipToNextWave();
        });
        shopButton.onClick.AddListener(() =>
        {
            if(UIManger.Instance.shopUI.gameObject.activeSelf)
            {
                UIManger.Instance.shopUI.Hide();
                Camera.main.GetComponent<Physics2DRaycaster>().enabled = true;
            }else if(!UIManger.Instance.shopUI.gameObject.activeSelf)
            {
                UIManger.Instance.shopUI.Show();
                Camera.main.GetComponent<Physics2DRaycaster>().enabled = false;
            }
        });
    }

    private void Update()
    {
        GoldText.text = $"Gold: {GameManager.Instance.gold}";
        protecthealthText.text = $"Protect Health: {GameManager.Instance.protecthealth}";
        if (GameManager.Instance.wave.isWave)
        {
            WaveText.text = $"Wave: {GameManager.Instance.wave.waveIndex + 1}\n" +
                            $"Timer: {GameManager.Instance.wave.waveTime[GameManager.Instance.wave.waveIndex]:F2}";
        }
        
    }
}
