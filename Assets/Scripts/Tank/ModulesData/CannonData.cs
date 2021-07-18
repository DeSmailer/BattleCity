using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CannonData", menuName = "TankData/CannonDataScriptableObject", order = 51)]
public class CannonData : ModuleData
{
    [SerializeField]
    private int gunsCount;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float shotDistance;
    [SerializeField]
    private Vector2[] firePoints;


    public int GunsCount => gunsCount;
    public float Damage => damage;
    public float ShotDistance => shotDistance;
    public Vector2[] FirePoints => firePoints;
}
