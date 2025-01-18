using System;
using TMPro;
using UnityEngine;

public class BasicTurret : TurrentBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float colliderRadius = 10;
    [SerializeField] private Collider2D[] colliders;
    [SerializeField] private int damage;
    [SerializeField] private float[] fireLevelTimer;
    [SerializeField] private int level =1;
    [SerializeField] private int price = 10;
    [SerializeField] private GameObject UpgradeWindow;
    
    [Header("Text")]
    [SerializeField] private TextMeshPro goldText;
    [SerializeField] private TextMeshPro damageText;
    [SerializeField] private TextMeshPro delayText;
    
    private bool isFiring = false;
    private float fireTimer;

    private void Update()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, colliderRadius);
        if (!isFiring)
        {
            if (colliders.Length > 0)
            {
                firing(bulletPrefab, colliders[0], damage);
                isFiring = true;
            }
        }

        if (isFiring)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireLevelTimer[level-1])
            {
                isFiring = false;
                fireTimer = 0;
            }
        }
        if(level == 1)
        {
            damage =3;
            price = 10;
            goldText.text = "Gold: 20";
            damageText.text = "Damage: 5";
            delayText.text = "Delay: " + fireLevelTimer[1];
        }
        else if(level == 2)
        {
            damage = 5;
            price = 20;
            goldText.text = "Gold: 30";
            damageText.text = "Damage: 7";
            delayText.text = "Delay: " + fireLevelTimer[2];
        }
        else if(level == 3)
        {
            damage = 7;
            price = 30;
            goldText.gameObject.SetActive(false);
            damageText.gameObject.SetActive(false);
            delayText.gameObject.SetActive(false);
            UpgradeWindow.SetActive(false);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
    
    public void UpgradeOpenAndClose()
    {
        if(UpgradeWindow.activeSelf)
        {
            UpgradeWindow.SetActive(false);
        }
        else
        {
            UpgradeWindow.SetActive(true);
        }
    }
    
    public void Upgrade()
    {
        if(GameManager.Instance.gold >= price)
        {
            level++;
            GameManager.Instance.gold -= price;
        }
    }
}
