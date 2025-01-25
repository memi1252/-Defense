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
    public bool speedDown = false;
    

    public virtual void SpeedUpTimer()
    {
        if(speedUp)
        {
            StartCoroutine(SpeedUp());
        }

        if (speedDown)
        {
            StartCoroutine(SpeedDown());
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
        if(other.gameObject.CompareTag("Ammo"))
        {
            //Ammo ammo = other.gameObject.GetComponent<Ammo>();
            //TakeDamage(ammo.damage);
            //Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("SpeedDownAmmo"))
        {
            SpeedDownAmmo ammo = other.gameObject.GetComponent<SpeedDownAmmo>();
            TakeDamage(ammo.damage);
            if (this.GetComponent<Enemy1>())
            {
                if (ammo.speedDownpercent == 10)
                {
                    speed = 0.0045f;
                }else if (ammo.speedDownpercent == 20)
                {
                    speed = 0.004f;
                }
                else if (ammo.speedDownpercent == 30)
                {
                    speed = 0.0035f;
                }
            }
            else if (this.GetComponent<Enemy2>())
            {
                if (ammo.speedDownpercent == 10)
                {
                    speed = 0.0036f;
                }else if (ammo.speedDownpercent == 20)
                {
                    speed = 0.0032f;
                }
                else if (ammo.speedDownpercent == 30)
                {
                    speed = 0.0028f;
                }
            }else if (GetComponent<Enemy3>())
            {
                if (ammo.speedDownpercent == 10)
                {
                    speed = 0.0018f;
                }else if (ammo.speedDownpercent == 20)
                {
                    speed = 0.0016f;
                }
                else if (ammo.speedDownpercent == 30)
                {
                    speed = 0.0014f;
                }
            }else if (GetComponent<Enemy4>())
            {
                if (ammo.speedDownpercent == 10)
                {
                    speed = 0.0027f;
                }else if (ammo.speedDownpercent == 20)
                {
                    speed = 0.0024f;
                }
                else if (ammo.speedDownpercent == 30)
                {
                    speed = 0.0021f;
                }
            }
            speedDown = true;
            Destroy(ammo.gameObject);
        }
    }
    
    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5);
        speed = defaultSpeed;
        speedUp = false;
    }
    
    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(5);
        speed = defaultSpeed;
        speedDown = false;
    }
}
