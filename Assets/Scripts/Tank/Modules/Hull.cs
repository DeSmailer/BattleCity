using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hull : Module, IAttacable
{
    public float speed;
    public Vector3 moveDir;
    public float goHorizontal;
    public float goVertical;
    public Rigidbody2D rb2d;

    public float maxHP;
    public float currentHP;

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        HullData t = (HullData)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ModulesData/BlueTeam/Hulls/HullData1.asset", typeof(HullData));
        Equip(t);
    }

    public override void Equip(ModuleData moduleData)
    {
        if (moduleData is HullData)
        {
            this.moduleData = moduleData;
            HullData hullData = (HullData)moduleData;

            speed = hullData.Speed;
            maxHP = currentHP = hullData.MaxHP;
            spriteRenderer.sprite = hullData.Sprite;
        }
        else
        {
            print("ошибочка");
        }
    }

    public void Move()
    {
        goHorizontal = Input.GetAxisRaw("Horizontal");
        goVertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(goHorizontal, goVertical).normalized;

        rb2d.velocity = moveDir * speed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
    }


}
