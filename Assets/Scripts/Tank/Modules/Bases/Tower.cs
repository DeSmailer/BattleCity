using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Tower : Module
{
    public float shotAccuracy;

    public SpriteRenderer spriteRenderer;

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

    public virtual void LookAt(Vector3 targetPosition)
    {
        var angle = Vector2.Angle(Vector2.right, targetPosition - transform.position);//угол между вектором от объекта к таргету и осью х
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < targetPosition.y ? angle : -angle);
    }
    
}


