using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    [SerializeField] public Transform[] MapPos1;
    [SerializeField] public Transform[] MapPos2;
    
    
    public List<GameObject> EnemyList = new List<GameObject>();
    public int gold = 0;
    
    public int protecthealth = 10;
    

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
