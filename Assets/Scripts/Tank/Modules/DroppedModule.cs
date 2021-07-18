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
    }

    public ModuleData PickUp(string team)
    {
        moduleType.ToString();
        return (ModuleData)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Modules/Hulls/HullData1.asset", typeof(ModuleData));
    }
}
