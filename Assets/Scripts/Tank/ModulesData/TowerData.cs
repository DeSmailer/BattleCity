using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TankData/TowerDataScriptableObject", order = 51)]
public class TowerData : ModuleData
{
    [SerializeField]
    [Range(0, 1)]
    private float shotAccuracy;

    public float ShotAccuracy => shotAccuracy;
}
