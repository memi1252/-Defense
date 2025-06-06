using UnityEngine;

public class Enemy4 : EnemyBase
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
        if (GameManager.Instance.stage2)
        {
            road(GameManager.Instance.stage2MapPos2);
        }
        else
        {
            road(GameManager.Instance.MapPos2);
        }
        SpeedUpTimer();
        if(health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
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
                        enemy.health -= 5;
                        
                    }else if(collider2D.GetComponent<Enemy2>() != null)
                    {
                        Enemy2 enemy = collider2D.gameObject.GetComponent<Enemy2>();
                        enemy.health -= 5;
                    }
                    else if(collider2D.GetComponent<Enemy3>() != null)
                    {
                        Enemy3 enemy = collider2D.gameObject.GetComponent<Enemy3>();
                        enemy.health -= 5;
                    }
                    else if(collider2D.GetComponent<Enemy4>() != null)
                    {
                        Enemy4 enemy = collider2D.gameObject.GetComponent<Enemy4>();
                        enemy.health -= 5;
                    }
                }
            }
            
        }
        base.Die();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
}
