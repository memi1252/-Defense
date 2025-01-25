using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] public Transform[] MapPos1;
    [SerializeField] public Transform[] MapPos2;
    
    [SerializeField] public Wave wave;
    
    
    public List<GameObject> EnemyList = new List<GameObject>();
    public int gold = 0;
    public int protecthealth = 10;
}
