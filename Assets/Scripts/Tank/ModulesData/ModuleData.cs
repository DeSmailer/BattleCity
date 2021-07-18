using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleData : ScriptableObject
{
    [SerializeField]
    private int level;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private ModulesTypes moduleType;
    [SerializeField]
    private Teams team;

    public string Name => this.name;
    public int Level => level;
    public Sprite Sprite => sprite;
    public ModulesTypes ModuleType => moduleType;
    public Teams Team => team;
}
