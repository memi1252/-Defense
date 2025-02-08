using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class arrangement : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit;
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("TurretPoint") && !UIManger.Instance.arrangementUI.isShow)
                {
                    UIManger.Instance.arrangementUI.Show();
                    UIManger.Instance.arrangementUI.spawnTransform = hit.collider.transform;
                    UIManger.Instance.arrangementUI.clickGameObject = hit.collider.gameObject;
                    UIManger.Instance.arrangementUI.isShow = true;
                    Camera.main.GetComponent<Physics2DRaycaster>().enabled = false;
                }
            }
        }
    }
}
