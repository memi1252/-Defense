using UnityEngine;

public class AllDamegi : itemBase
{
    [SerializeField] private GameObject pung;
    
    private void Update()
    {
        click("AllDamegi");
    }

    public override void item()
    {
        Debug.Log("AllDamegi");
        foreach (var enemy in GameManager.Instance.EnemyList)
        {
            enemy.GetComponent<EnemyBase>().health /= 2;
        }
        Instantiate(pung, new Vector3(0,0,0), Quaternion.identity);
        Destroy(gameObject);
    }
}
