using TMPro;
using UnityEngine;

public class TurrentBase : MonoBehaviour
{
    [SerializeField] public float[] fireLevelTimer;
    [SerializeField] public int[] Prices;
    [SerializeField] public int[] damages;
    [SerializeField] public int level =1;
    [SerializeField] public int price = 10;
    [SerializeField] public GameObject UpgradeWindow;
    
    [Header("Text")]
    [SerializeField] public TextMeshPro goldText;
    [SerializeField] public TextMeshPro damageText;
    [SerializeField] public TextMeshPro delayText;
    
    [SerializeField] public LayerMask layerMask;
    
    
    public virtual void firing(GameObject target, Collider2D collider2D, int damage)
    {
            if (collider2D.gameObject.tag == "Enemy")
            {
                var Ammo = Instantiate(target, transform.position, Quaternion.identity);
                SoundManager.Instance.turretSource.Play();
                Ammo.GetComponent<Ammo>().damage = damage;
                Vector3 direction = collider2D.transform.position - Ammo.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Ammo.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
    }
    public void UpgradeOpenAndClose()
    {
        if(UpgradeWindow.activeSelf)
        {
            UpgradeWindow.SetActive(false);
        }
        else
        {
            UpgradeWindow.SetActive(true);
        }
    }
    
    public void Upgrade()
    {
        if(GameManager.Instance.gold >= price)
        {
            level++;
            GameManager.Instance.gold -= price;
        }
    }
}
