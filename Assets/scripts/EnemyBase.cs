using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public bool goldUp = false;
    public bool allDemage = false;
    public bool goldgive = true;
    public bool move = true;
    

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
        if (move)
        {
            Transform targetWaypoint = targetWay[currentWaypointIndex];
            progress += speed * Time.deltaTime / Vector3.Distance(transform.position, targetWaypoint.position);
            transform.position = Vector3.Lerp(transform.position, targetWaypoint.position, progress);

            if (progress >= 1f)
            {
                progress = 0f;
                if (targetWay == GameManager.Instance.MapPos1 && targetWaypoint == targetWay[0])
                    transform.Rotate(0, 0, -90);
                else if (targetWay == GameManager.Instance.MapPos1 && targetWaypoint == targetWay[targetWay.Length - 2])
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                else if (targetWay == GameManager.Instance.MapPos1)
                    transform.Rotate(0, 0, 90);
                else if (targetWay == GameManager.Instance.MapPos2 && targetWaypoint == targetWay[0])
                    transform.Rotate(0, 0, 90);
                else if (targetWay == GameManager.Instance.MapPos2 && targetWaypoint == targetWay[targetWay.Length - 2])
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                else if (targetWay == GameManager.Instance.MapPos2)
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos1 && targetWaypoint == targetWay[0])
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos1 && targetWaypoint == targetWay[1])
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos1 && targetWaypoint == targetWay[2])
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos1 && targetWaypoint == targetWay[3])
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos1 && targetWaypoint == targetWay[4])
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos1 && targetWaypoint == targetWay[5])
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[0] && currentWaypointIndex <9)
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[1] && currentWaypointIndex <9)
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[2] && currentWaypointIndex <9)
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[3] && currentWaypointIndex <9)
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[4] && currentWaypointIndex <9)
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[5]&& currentWaypointIndex <9)
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[6] && currentWaypointIndex <9)
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[7]&& currentWaypointIndex <9)
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[8]&& currentWaypointIndex <9)
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[9])
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[10])
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[11])
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[12])
                    transform.Rotate(0, 0, -90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[13])
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[14])
                    transform.Rotate(0, 0, 90);
                else if(targetWay == GameManager.Instance.stage2MapPos2 && targetWaypoint == targetWay[15])
                    transform.Rotate(0, 0, -90);
                currentWaypointIndex = (currentWaypointIndex + 1) % targetWay.Length;
            }
        }
    }
    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }
    
    public virtual void Die()
    {
        if (goldgive)
        {
            GameManager.Instance.gold += gold;
        }
        GameManager.Instance.EnemyList.Remove(gameObject);
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
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
