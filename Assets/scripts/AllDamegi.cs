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
        Instantiate(pung, new Vector3(0,0,0), Quaternion.identity);
        SoundManager.Instance.pungSource.Play();
        GameManager.Instance.allDamage = true;
        UIManger.Instance.statsUI.allDamageImage.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
