using System;
using UnityEngine;
using UnityEngine.UI;

public class arrangementUI : UIBase
{
    [SerializeField] private Button BasicTurretButton;
    [SerializeField] private Button AttackTurretButton;
    [SerializeField] private Button SpeedDownTurretButton;
    [SerializeField] private Button MultiTurretButton;
    [SerializeField] private GameObject BasicTurret;
    [SerializeField] private GameObject AttackTurret;
    [SerializeField] private GameObject SpeedDownTurret;
    [SerializeField] private GameObject MultiTurret;

    public Transform spawnTransform;
    public GameObject clickGameObject;
    
    public bool isShow = false;

    private void Awake()
    {
        Hide();
        BasicTurretButton.onClick.AddListener(() =>
        {
            Debug.Log("BasicTurretButton");
            if (GameManager.Instance.gold >= 10)
            {
                GameManager.Instance.gold -= 10;
                Instantiate(BasicTurret, spawnTransform.position, Quaternion.identity);
                Destroy(clickGameObject);
            }
            Hide();
            isShow = false;
        });
        AttackTurretButton.onClick.AddListener(() =>
        {
            Debug.Log("AttackTurretButton");
            if (GameManager.Instance.gold >= 20)
            {
                GameManager.Instance.gold -= 20;
                Instantiate(AttackTurret, spawnTransform.position, Quaternion.identity);
                Destroy(clickGameObject);
            }
            Hide();
            isShow = false;
        });
        SpeedDownTurretButton.onClick.AddListener(() =>
        {
            Debug.Log("SpeedDownTurretButton");
            if (GameManager.Instance.gold >= 20)
            {
                GameManager.Instance.gold -= 20;
                Instantiate(SpeedDownTurret, spawnTransform.position, Quaternion.identity);
                Destroy(clickGameObject);
            }
            Hide();
            isShow = false;
        });
        MultiTurretButton.onClick.AddListener(() =>
        {
            Debug.Log("MultiTurretButton");
            if (GameManager.Instance.gold >= 20)
            {
                GameManager.Instance.gold -= 20;
                Instantiate(MultiTurret, spawnTransform.position, Quaternion.identity);
                Destroy(clickGameObject);
            }
            Hide();
            isShow = false;
        });
    }
}
