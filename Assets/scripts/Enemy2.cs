using System;
using UnityEngine;

public class Enemy2 : EnemyBase
{
    [SerializeField] private Collider2D[] colliders;
    [SerializeField] private float colliderRadius = 1;

    private void Awake()
    {
        defaultSpeed = speed;
    }

    private void Update()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, colliderRadius);
        if (colliders.Length > 0)
        {
            foreach (Collider2D collider2D in colliders)
            {
                if(collider2D == GetComponent<Collider2D>()) continue;
                
                if (collider2D.CompareTag("Enemy"))
                {
                    if(collider2D.GetComponent<Enemy1>() != null)
                    {
                        Enemy1 enemy = collider2D.gameObject.GetComponent<Enemy1>();
                        if(enemy.speedUp) continue;
                        enemy.speed += enemy.speed / 30 * 100;
                        enemy.speedUp = true;
                        
                    }else if(collider2D.GetComponent<Enemy2>() != null)
                    {
                        Enemy2 enemy = collider2D.gameObject.GetComponent<Enemy2>();
                        if(enemy.speedUp) continue;
                        enemy.speed += enemy.speed / 30 * 100;
                        enemy.speedUp = true;
                    }
                    else if(collider2D.GetComponent<Enemy3>() != null)
                    {
                        Enemy3 enemy = collider2D.gameObject.GetComponent<Enemy3>();
                        if(enemy.speedUp) continue;
                        enemy.speed += enemy.speed / 30 * 100;
                        enemy.speedUp = true;
                    }
                    else if(collider2D.GetComponent<Enemy4>() != null)
                    {
                        Enemy4 enemy = collider2D.gameObject.GetComponent<Enemy4>();
                        if(enemy.speedUp) continue;
                        enemy.speed += enemy.speed / 30 * 100;
                        enemy.speedUp = true;
                    }
                }
            }
            
        }
        if (GameManager.Instance.stage2)
        {
            road(GameManager.Instance.stage2MapPos1);
        }
        else
        {
            road(GameManager.Instance.MapPos1);
        }
        SpeedUpTimer();
        if(health <= 0)
        {
            Die();
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
    
}
