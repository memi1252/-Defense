using UnityEngine;

public class UIManger : MonoBehaviour
{
    public static UIManger Instance {get; private set;}
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
