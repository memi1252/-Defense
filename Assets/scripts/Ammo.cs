using System.Collections;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int Speed = 10;

    public int damage;
    
    private void Start()
    {
        StartCoroutine(DestroyAmmo());
    }
    private void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
    
    IEnumerator DestroyAmmo()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
