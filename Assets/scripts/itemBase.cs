using UnityEngine;

public class itemBase : MonoBehaviour
{
    public virtual void click(string tag)
    {
        RaycastHit2D hit;
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.CompareTag(tag) && GameManager.Instance.isItemCoolTime == false)
                {
                    item();
                }
            }
        }
    }
    public virtual void item()
    {
        
    }
}
