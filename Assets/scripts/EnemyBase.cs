using System;
using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private int currentWaypointIndex = 0;
    private float progress = 0f;
    public int health;
    public int gold;
    public float speed;
    public float defaultSpeed;
    public bool speedUp = false;
    

    public virtual void SpeedUpTimer()
    {
        if(speedUp)
        {
            StartCoroutine(SpeedUp());
        }
    }

    public virtual void road(Transform[] targetWay)
    {
        Transform targetWaypoint = targetWay[currentWaypointIndex];
        progress += speed * Time.deltaTime / Vector3.Distance(transform.position, targetWaypoint.position);
        transform.position = Vector3.Lerp(transform.position, targetWaypoint.position, progress); 

        if (progress >= 1f) 
        {
            progress = 0f; 
            currentWaypointIndex = (currentWaypointIndex + 1) % targetWay.Length;
        }
    }
    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die()
    {
        GameManager.Instance.gold += gold;
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            Ammo ammo = other.gameObject.GetComponent<Ammo>();
            TakeDamage(ammo.damage);
            Destroy(other.gameObject);
        }
    }
    
    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5);
        speed = defaultSpeed;
        speedUp = false;
    }
}
