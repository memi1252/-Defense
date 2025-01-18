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
                }
            }
            
        }
        road(GameManager.Instance.MapPos1);
        if(transform.position == GameManager.Instance.MapPos1[GameManager.Instance.MapPos1.Length - 1].position)
        {
            GameManager.Instance.protecthealth -= 1;
            Destroy(gameObject);
        }
        SpeedUpTimer();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
}
