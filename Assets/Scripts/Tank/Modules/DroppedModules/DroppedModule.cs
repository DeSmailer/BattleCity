using UnityEditor;
using UnityEngine;

public class DroppedModule : MonoBehaviour, IPickUp
{
    public SpriteRenderer spriteRenderer;
    public new string name;
    public ModulesTypes moduleType;

    public void Drop(ModuleData moduleData)
    {
        spriteRenderer.sprite = moduleData.Sprite;
        name = moduleData.Name;
        moduleType = moduleData.ModuleType;

    }

    public ModuleData PickUp(Teams team)
    {
        moduleType.ToString();
        Destroy(gameObject, Time.deltaTime);
        return (ModuleData)AssetDatabase.LoadAssetAtPath($"Assets/Prefabs/ModulesData/{team}Team/{moduleType}s/{name}.asset", typeof(ModuleData));
    }
}
