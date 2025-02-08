using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Warehouse : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.protecthealth -= Random.Range(2, 3);
            GameManager.Instance.EnemyList.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
