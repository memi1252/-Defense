using TMPro;
using UnityEngine;

public class AttackTurret : TurrentBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float colliderRadius = 10;
    [SerializeField] private Collider2D[] colliders;
    [SerializeField] private int damage;
    [SerializeField] private int[] RangeLevel;
    [SerializeField] private TextMeshPro RangeText;
    
    
    private bool isFiring = false;
    private float fireTimer;

    private void Update()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, colliderRadius, layerMask);
        if (!isFiring)
        {
            if (colliders.Length > 0)
            {
                Vector3 direction = colliders[0].transform.position - transform.GetChild(1).position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.GetChild(1).rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
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
            damage =damages[0];
            price = Prices[1];
            colliderRadius = RangeLevel[0];
            goldText.text = "Gold: "+ Prices[1];
            damageText.text = "Damage: " + damages[1];
            delayText.text = "Delay: " + fireLevelTimer[1];
        }
        else if(level == 2)
        {
            damage = damages[1];
            price = Prices[2];
            colliderRadius = RangeLevel[1];
            goldText.text = "Gold: " + Prices[2];
            damageText.text = "Damage: " + damages[2];
            delayText.text = "Delay: " + fireLevelTimer[2];
        }
        else if(level == 3)
        {
            damage = damages[2];
            colliderRadius = RangeLevel[2];
            goldText.gameObject.SetActive(false);
            damageText.gameObject.SetActive(false);
            delayText.gameObject.SetActive(false);
            RangeText.gameObject.SetActive(false);
            UpgradeWindow.SetActive(false);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
}
