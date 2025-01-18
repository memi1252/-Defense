using UnityEngine;

public class TurrentBase : MonoBehaviour
{
    public virtual void firing(GameObject target, Collider2D collider2D, int damage)
    {
            if (collider2D.gameObject.tag == "Enemy")
            {
                var Ammo = Instantiate(target, transform.position, Quaternion.identity);
                Ammo.GetComponent<Ammo>().damage = damage;
                Vector3 direction = collider2D.transform.position - Ammo.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Ammo.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
    }
}
