using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEquipmentManager : MonoBehaviour
{
    public ModuleData[] Hulls;
    public ModuleData[] Towers;
    public ModuleData[] Cannons;

    public ModuleData GetHull()
    {
        int rand = Random.Range(0, Hulls.Length);
        return Hulls[rand];
    }

    public ModuleData GetTower()
    {
        int rand = Random.Range(0, Towers.Length);
        return Towers[rand];
    }

    public ModuleData GetCannon()
    {
        int rand = Random.Range(0, Cannons.Length);
        return Cannons[rand];
    }
}
