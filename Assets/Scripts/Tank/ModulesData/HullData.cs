using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HullData", menuName = "TankData/HullDataScriptableObject", order = 51)]
public class HullData : ModuleData
{
    
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float speed;
    

    public float MaxHP => maxHP;
    public float Speed => speed;
    
}
