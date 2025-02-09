using UnityEngine;

public class EnemyStop : itemBase
{
    private void Update()
    {
        click("EnemyStop");
    }
    
    public override void item()
    {
        Debug.Log("EnemyStop");
        GameManager.Instance.speedStop = true;
        UIManger.Instance.statsUI.EnemySpeedImage.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}

