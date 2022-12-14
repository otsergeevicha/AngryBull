using System;
using UnityEngine;

[Serializable]
public class Wave : MonoBehaviour
{
    public Villian[] Villians;
    public int VillianCapacity;
    
    public Enemy[] EnemyPrefabs;
    public int EnemyCapacity;
    public Transform TargetEnemy;
    public Transform[] SafePoints;
    
    public OutdoorItems[] OutdoorItemsPrefabs;
    public int OutdoorItemsCapacity;

    public string Name;
}
