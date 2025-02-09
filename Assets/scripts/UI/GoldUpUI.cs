using TMPro;
using UnityEngine;

public class GoldUpUI : UIBase
{
    [SerializeField] private TextMeshProUGUI timetext;
    private float time = 3;
    public float timer;
    
    private void Awake()
    {
        Hide();
    }
    
    private void Update()
    {
        if (GameManager.Instance.GoldUp)
        {
            Show();
            timer += Time.deltaTime;
            timetext.text = $"{time - timer:F2}";
            if (timer >= time)
            {
                Hide();
                timer = 0;
                GameManager.Instance.itemconut--;
                GameManager.Instance.GoldUp = false;
            }
        }
    }
    
    
}
