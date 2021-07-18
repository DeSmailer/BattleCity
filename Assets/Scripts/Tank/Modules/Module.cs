using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour, IEquipament
{
    public ModuleData moduleData;
    public abstract void Equip(ModuleData moduleData);
}
