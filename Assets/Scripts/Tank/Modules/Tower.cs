using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : Module
{
    public float shotAccuracy;

    public SpriteRenderer spriteRenderer;
    public void Start()
    {
        TowerData t = (TowerData)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ModulesData/BlueTeam/Towers/TowerData2.asset", typeof(TowerData));
        Equip(t);
    }
    public override void Equip(ModuleData moduleData)
    {
        if (moduleData is TowerData)
        {
            this.moduleData = moduleData;
            TowerData towerData = (TowerData)moduleData;

            shotAccuracy = towerData.ShotAccuracy;
            spriteRenderer.sprite = towerData.Sprite;
        }
        else
        {
            print("ошибочка");
        }
    }

    private void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);//немного магии на последок
    }
}


