using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Hull : Module, IAttacable
{
    public float speed;
    public Vector3 moveDir;
    public Vector3 lookDir;
    public float goHorizontal;
    public float goVertical;
    public Rigidbody2D rb2d;

    public float maxHP;
    public float currentHP;

    public SpriteRenderer spriteRenderer;

    public abstract void Dead();

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

    public Teams GetTeam()
    {
        return team;
    }

    public abstract void Move();

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Dead();
        }
    }




}
